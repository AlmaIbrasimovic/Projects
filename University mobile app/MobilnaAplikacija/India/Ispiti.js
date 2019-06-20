import React from 'react';
import {
  createStackNavigator,
  createMaterialTopTabNavigator,
  createAppContainer,
} from 'react-navigation';
import {Alert} from 'react-native';

import AktivniIspiti from './aktivniIspiti'
import PrijavljeniIspiti from './prijavljeniIspiti'
import SviPrijavljeniIspiti from './sviPrijavljeniIspiti'
import Notifikacija from './notifikacije'

let inicijalniAktivni ={ispiti_info:[], ispiti: [{ key: 0, predmet: "Vjestacka inteligencija", tip: "Prvi parcijalni", datum: "10.2.2019. 13:00", aktivan: 1, prijavljen: 1, popunjen: null },
{ key: 1, predmet: "Organizacija softverskog projekta", tip: "Drugi parcijalni", datum: "13.6.2019. 18:00", aktivan: 0, prijavljen: 0, popunjen: null },
{ key: 2, predmet: "Softverski inzenjering", tip: "Prvi parcijalni", datum: "15.4.2019. 10:30", aktivan: 0, prijavljen: 1, popunjen: 13 },
{ key: 3, predmet: "Projektovanje informacionih sistema", tip: "Usmeni", datum: "16.7.2019. 13:00", aktivan: 1, prijavljen: 0, popunjen: 0 },
{ key: 4, predmet: "Projektovanje informacionih sistema", tip: "Usmeni", datum: "16.7.2019. 11:00", aktivan: 1, prijavljen: 1, popunjen: 1 },
{ key: 5, predmet: "Softverski inzenjering", tip: "Drugi parcijalni", datum: "24.6.2019. 09:00", aktivan: 1, prijavljen: 1, popunjen: null }], 
kopijaIspiti: []
} 
let inicijalniPrijavljeni ={ispiti_info:[], ispiti: [{ key: 0, predmet: "Vjestacka inteligencija", tip: "Prvi parcijalni", datum: "10.2.2019. 13:00", aktivan: 1, prijavljen: 1, popunjen: null },
{ key: 1, predmet: "Organizacija softverskog projekta", tip: "Drugi parcijalni", datum: "13.6.2019. 18:00", aktivan: 1, prijavljen: 1, popunjen: null },
{ key: 2, predmet: "Softverski inzenjering", tip: "Prvi parcijalni", datum: "15.6.2019. 10:30", aktivan: 0, prijavljen: 1, popunjen: 55 },
{ key: 3, predmet: "Projektovanje informacionih sistema", tip: "Usmeni", datum: "16.6.2019. 13:00", aktivan: 1, prijavljen: 0, popunjen: null },
{ key: 4, predmet: "Projektovanje informativnih sistema", tip: "Usmeni", datum: "16.6.2019. 11:00", aktivan: 1, prijavljen: 1, popunjen: 1 }], 
kopijaIspiti: []
}
let naRender = () => {
  let k = 0;
  inicijalniAktivni.ispiti.map((ispit) => {
    let porukaa = '';
    let statusPrijave = '';
    if (ispit.prijavljen) {
        porukaa = 'Odjavi'
        statusPrijave = 'Prijavljen'
    } 
    else {
        porukaa = 'Prijavi'            
        statusPrijave = 'Aktivan'
    } 
    if(ispit.popunjen == null || ispit.popunjen == 0)
        statusPrijave += '\nPopunjen'
    
    inicijalniAktivni.ispiti_info[k] = { ind: k, key: ispit.key, prijavaTekst: porukaa, statusPrijave: statusPrijave }
    k++;
  })
}

let onPressAktivni = (ispit, promijeniTekstButtona) => {
  j = inicijalniAktivni.ispiti.indexOf(ispit);
    
  greska = 0;
  //console.log(ispit);
  inicijalniAktivni.ispiti.map((item) => {
    if (item.key != ispit.key && item.predmet === ispit.predmet && item.tip === ispit.tip && item.prijavljen == 1) {
      greska = 1;
    }
  });
  if (greska) {
        alert('Prijavljeni ste na drugi termin ovog ispita, odjavite ga kako bi se mogli prijavili na ovaj!');
    }
    else if((ispit.popunjen == null || ispit.popunjen == 0) && ispit.prijavljen == 0) {
        alert('Termin ispita je nažalost popunjen!');
    }
    else if (ispit.prijavljen) {
        Alert.alert(
            "Upozorenje",
            "Jeste li sigurni da se želite odjaviti?",
            [
              { text: "Da", onPress: () => {
                
                inicijalniAktivni.ispiti[j].prijavljen = 0;
                if(ispit.popunjen == null || ispit.popunjen == 0)
                    inicijalniAktivni.ispiti[j].popunjen = 1;
                inicijalniPrijavljeni.ispiti = inicijalniPrijavljeni.ispiti.filter(ispit => ispit.predmet == inicijalniAktivni.ispiti[j].predmet && ispit.datum == inicijalniAktivni.ispiti[j].datum)
                //ovdje treba obrisati iz tabele StudentIspit
        promijeniTekstButtona(j);
        alert('Ispit uspješno odjavljen!');
    } },
              {
                text: "Otkaži",
                onPress: () => console.log("Ipak se ne želim odjaviti"),
                style: "cancel"
              },
            ],
            { cancelable: false }
          );
        
    }
    else {
        inicijalniAktivni.ispiti[j].prijavljen = 1;
        promijeniTekstButtona(j);
        inicijalniAktivni.ispiti[j].popunjen = inicijalniAktivni.ispiti[j].popunjen - 1; 
        inicijalniPrijavljeni.ispiti.push(inicijalniAktivni.ispiti[j]);
        //ovdje treba dodati u tabelu StudentIspit 
        //console.log(inicijalniPrijavljeni.ispiti);
        alert('Ispit uspješno prijavljen!');
    }
}
const TabScreen = createMaterialTopTabNavigator(
  {
  'Aktivni ispiti': { screen: props => <AktivniIspiti {...props} 
  propovi={{'inicijalni':inicijalniAktivni, 'onPressAktivni':onPressAktivni,'naRender':naRender}} /> },//onPressAktivni={onPressAktivni} naRender={naRender}  /> },
  'Prijavljeni ispiti': { screen: props => <PrijavljeniIspiti {...props}
    propovi={{'inicijalni':inicijalniPrijavljeni}}/>},
  'Svi prijavljeni ispiti' : { screen: SviPrijavljeniIspiti},
  },
  {
    tabBarPosition: 'top',
    swipeEnabled: true,
    animationEnabled: true,
    tabBarOptions: {
      activeTintColor: '#376ff2',
      inactiveTintColor: 'gray',
      style: {
        backgroundColor: '#FFFFFF',
      },
      labelStyle: {
        textAlign: 'center',
        

      },
      indicatorStyle: {
        borderBottomColor: '#376ff2',
        borderBottomWkeyth: 2,
      },
    },
    navigationOptions: {
      header: props => <Notifikacija/>, 
    }
  }
);
const IspitiTab = createStackNavigator({
  TabScreen: {
    screen: TabScreen,
    
  },
});

export default createAppContainer(IspitiTab);
