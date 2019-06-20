import React from 'react';
//import { createBottomTabNavigator, createAppContainer } from 'react-navigation';
import {Alert,Text, View, Image, TouchableOpacity, StyleSheet, Button } from 'react-native';
import moment from 'moment';
import { NativeViewGestureHandler } from 'react-native-gesture-handler';


/*let inicijalni ={ispiti_info:[], ispiti: [{ key: 0, predmet: "Vjestacka inteligencija", tip: "Prvi parcijalni", datum: "10.2.2019. 13:00", aktivan: 1, prijavljen: 1, popunjen: 0 },
{ key: 1, predmet: "Organizacija softverskog projekta", tip: "Drugi parcijalni", datum: "13.6.2019. 18:00", aktivan: 1, prijavljen: 0, popunjen: 0 },
{ key: 2, predmet: "Softverski inzenjering", tip: "Prvi parcijalni", datum: "15.6.2019. 10:30", aktivan: 0, prijavljen: 1, popunjen: 1 },
{ key: 3, predmet: "Projektovanje informacionih sistema", tip: "Usmeni", datum: "16.6.2019. 13:00", aktivan: 1, prijavljen: 0, popunjen: 0 },
{ key: 4, predmet: "Projektovanje informacionih sistema", tip: "Usmeni", datum: "16.6.2019. 11:00", aktivan: 1, prijavljen: 1, popunjen: 1 },
{ key: 4, predmet: "Softverski inzenjering", tip: "Drugi parcijalni", datum: "24.6.2019. 09:00", aktivan: 1, prijavljen: 0, popunjen: 1 }], 
kopijaIspiti: []
} */
let notifikacije = true;

class AktivniIspiti extends React.Component {
    
    constructor(props) {
        super(props);
        this.state = this.props.propovi.inicijalni
        inicijalizovanjeIspita = () => {
            this.setState(this.props.propovi.inicijalni)
        }
        this.promijeniTekstButtona = this.promijeniTekstButtona.bind(this);
        this.filtrirajPopunjene = this.filtrirajPopunjene.bind(this);
    }
    
    detalji() {
      Alert.alert(
        'Detalji o ispitu',
        'Profesor: Richard Feynman \nSala: MA',
        [
          {text: 'Nazad'},
        ],
          {cancelable: false}
      );
    }

    filtrirajPopunjene() {
        if(this.state.kopijaIspiti.length === 0) {
            this.setState({kopijaIspiti: this.state.ispiti}, () => {
                this.setState({ispiti: this.state.ispiti.filter(ispit => ispit.popunjen === null)});
                this.setState({ispiti: this.state.ispiti.filter(ispit => ispit.popunjen === 0)});
            });
        } else {
            this.setState({ispiti: this.state.ispiti.filter(ispit => ispit.popunjen === null)});
            this.setState({ispiti: this.state.ispiti.filter(ispit => ispit.popunjen === null)});
        }
    }

    filtrirajPrijavljene() {
        var prijavljeni = [];
        let k = 0;
        for(let i in this.state.ispiti) {
            for(let j in this.state.ispiti) {
                if(this.state.ispiti[i].prijavljen) {
                    if (this.state.ispiti[i] == this.state.ispiti[j] || (this.state.ispiti[i].predmet == this.state.ispiti[j].predmet && this.state.ispiti[i].tip == this.state.ispiti[j].tip))
                    {
                        prijavljeni[k] = this.state.ispiti[j];    
                        k++;
                    } 
                    else continue;
                }
            }
        }
        if(this.state.kopijaIspiti.length === 0) {
            this.setState({kopijaIspiti: this.state.ispiti}, () => {
                this.setState({ispiti: this.state.ispiti.filter( ( el ) => !prijavljeni.includes( el ))});
            });
        } else
            this.setState({ispiti: this.state.ispiti.filter( ( el ) => !prijavljeni.includes( el ))});
    }

    prikaziSve() {
        //console.log(this.state.kopijaIspiti);
        if (this.state.kopijaIspiti.length !== 0) 
            this.setState({ispiti: this.state.kopijaIspiti});
    }
    promijeniTekstButtona = i => {
        this.setState(() => {
            const list = this.state.ispiti_info.map((item, j) => {
              
                if (j === i) {
                    if (item.prijavaTekst === 'Prijavi') {
                        item.prijavaTekst = 'Odjavi'
                        item.statusPrijave = 'Prijavljen'
                    }
                    else {
                        item.prijavaTekst = 'Prijavi'
                        item.statusPrijave = 'Aktivan'
                    }   
                } 
                return item;
            });
            return {
                list,
            };
        });
      };
    render() {
        
        this.props.propovi.naRender();
        /*
        let k = 0;
        this.state.ispiti.map((ispit) => {
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
            if(ispit.popunjen)
                statusPrijave += '\nPopunjen'
                                    greska = 0; 
                                    this.state.ispiti.map((item) => {
                                        if (item.key != ispit.key && item.predmet === ispit.predmet && item.tip === item.tip && item.prijavljen == 1) {
                                            greska = 1;
                                        }
                                    });	
			if(greska) statusPrijave += '\nDrugi'
            inicijalni.ispiti_info[k] = { ind: k, key: ispit.key, prijavaTekst: porukaa, statusPrijave: statusPrijave }
            k++;
        })*/
        this.inicijalizovanjeIspita;
        let j, greska;
        ispisAktivnihIspita = this.state.ispiti.map((ispit) => {
            const dateLimit = moment(ispit.datum, 'DD.MM.YYYY hh:mm');
            const now = moment();

            if (ispit.aktivan && dateLimit.isValid() && !now.isAfter(dateLimit)) {
                return (

                    <View style={{ flexDirection: 'row' }}>
                        <View style={styles.elementi_tabele}><Text style={styles.elementi_tabele_tekst}>{ispit.predmet}</Text></View>
                        <View style={styles.elementi_tabele}><Text style={styles.elementi_tabele_tekst}>{ispit.tip}</Text></View>
                        <View style={styles.elementi_tabele}><Text style={styles.elementi_tabele_tekst}>{ispit.datum}</Text></View>
                        <View style={styles.elementi_tabele}>
                            <TouchableOpacity>
                                <Text style={[styles.elementi_tabele_tekst, { color: 'blue' }]} onPress={() => this.props.propovi.onPressAktivni(ispit, this.promijeniTekstButtona)}>{this.state.ispiti_info[this.state.ispiti.indexOf(ispit)].prijavaTekst}</Text>
                            </TouchableOpacity></View>
                            <View style={styles.elementi_tabele}><Text style={styles.elementi_tabele_tekst}>{this.state.ispiti_info[this.state.ispiti.indexOf(ispit)].statusPrijave}</Text></View>
                    </View>
                );
            }
        }) 

        return (

            <View style={styles.container}>
                <View style={styles.header_container}>
                    <View style={styles.header}><Text style={styles.header_tekst}>Predmet</Text></View>
                    <View style={styles.header}><Text style={styles.header_tekst}>Tip</Text></View>
                    <View style={styles.header}><Text style={styles.header_tekst}>Datum</Text></View>  
                    <View style={styles.header}><Text style={styles.header_tekst}>Prijava</Text></View>
                    <View style={styles.header}><Text style={styles.header_tekst}>Status</Text></View>
                </View>
                <View>
                    {ispisAktivnihIspita}
                </View>
                <View style = {styles.Button}>
                    <Button onPress={() => this.filtrirajPopunjene()} title="Sakrij popunjene termine"/>
                </View>
                <View style = {styles.Button}>
                    <Button onPress={() => this.filtrirajPrijavljene()} title="Sakrij prijavljene termine"/>
                </View>
                <View style = {styles.Button}>
                    <Button onPress={() => this.prikaziSve()} title="Prikaži sve"/>
                </View>
            </View>
        );
    }
}
export default AktivniIspiti;
const styles = StyleSheet.create({
    container:{
      flex: 1, 
      flexDirection: 'column'
    },
    elementi_tabele_tekst:{
      textAlign: 'center',
      paddingTop:5, 
    },
    elementi_tabele:{ 
      flex: 1, 
      alignItems:'center' 
  },
    header_tekst:{
      textAlign: 'center',
      color: 'black',
      fontSize: 16,
      fontWeight: 'bold',
      top: '20%',
      bottom: '20%'
    },
    header_container:{
      flexDirection: 'row', 
      justifyContent:'space-between', 
      paddingTop: 10,
      paddingBottom: 10
    },
    header:{
      flex: 1,
      textAlign: 'center'
    }, 
    Button: {
        padding: 10
    },
  });