import React from 'react';
import { Button, Alert, StyleSheet, Text, View, ScrollView, Picker } from 'react-native';
import RF from "react-native-responsive-fontsize"
import Naslov from './naslov'
import Zahtjev from './prikazPotvrda'
var podaci = [
  {key: 'Potvrda o regulisanju stipendije', value: '25.01.2019', status: 'Neobrađen'}, {key: 'Potvrda o regulisanju zdravstvenog osiguranja', value:'02.02.2019.', status: 'Obrađen'}
];

class Potvrde extends React.Component {
  
  constructor(props) {
    super(props);

    this.state = {
      pickerSelection: 0,
      svrha: 0, 
      data: podaci,
      besplatne_potvrde: 5
    }
    this.handleClick = this.handleClick.bind(this);
  } 

  handleClick(tip,svrha) {
    var today = new Date();
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    today = dd + '.' + mm + '.' + yyyy;
    Alert.alert(
      'Odabrani zahtjev',
      'Potvrda: '+ tip.label +'\nSvrha: '+ svrha.label,
      [
        {text: 'Predaj', onPress: () => Alert.alert(
		'Upozorenje', 'Da li ste sigurni?',
		[
		  {text: 'Da', onPress: () => {
            Alert.alert("Uspješno ste poslali zahtjev za obradu potvrde")
            podaci.push({'key': svrha.label, 'value': today, 'status': 'Neobrađen'});
            this.setState({
              data: podaci
            })
        }},
			{text: 'Ne', onPress: () => Alert.alert('Uspješno ste otkazali slanje zahtjeva!')}
		
		]
		)},
        {text: 'Poništi',onPress: () => console.log('Poništio'), style: 'cancel'},
      ],
      {cancelable: false},
    );
  }

  render() {
    const lista = [{ label: "Potvrda o redovnom studiju", value: "potvrda" },
    { label: "Uvjerenje o položenim ispitima", value: "uvjerenje" }];
    const svrhe = [{ label: "Regulisanje zdravstvenog osiguranja", value: "zdravstveno" },
    { label: "Ostvarivanje prava na stipendiju", value: "stipendija" },
    { label: "Upis na drugi fakultet", value: "upis" }];
   
    return (
      <ScrollView> 
        <Text style={{ fontSize: RF(3.5), margin: 70, alignSelf: 'center' }}>Zahtjev za izdavanje ovjerenog uvjerenja</Text>
        <Naslov/>
        <Zahtjev data={this.state.data} besplatne_potvrde = {this.state.besplatne_potvrde}/> 
        <Text style={{ fontSize: RF(2.5), alignSelf: 'center' }}>Izaberite tip potvrde: </Text>
        <Picker
          selectedValue={lista[this.state.pickerSelection].value}
          mode='dropdown'
          style={{ height: 80, width: 320, alignSelf: 'center' }}
          onValueChange={(itemValue, itemIndex) => { this.setState({ pickerSelection: itemIndex }) }}
        >
          {lista.map(element => {
            return (
              <Picker.Item key={element.value} label={element.label} value={element.value} />
            );
          })}
        </Picker>

        <Text style={{ fontSize: RF(2.5), alignSelf: 'center' }}>Odaberite svrhu uvjerenja: </Text>
        <Picker
          selectedValue={svrhe[this.state.svrha].value}
          mode='dropdown'
          style={{ height: 80, width: 320, alignSelf: 'center' }}
          onValueChange={(itemValue, itemIndex) => this.setState({ svrha: itemIndex })}>

          {svrhe.map(svrha => {
            return (
              <Picker.Item key={svrha.value} label={svrha.label} value={svrha.value} />
            );
          })}
        </Picker>
        <Button
       
          onPress= {() => this.handleClick(lista[this.state.pickerSelection],svrhe[this.state.svrha] )}
          title="Pošalji zahtjev"
          accessibilityLabel="Pošalji zahtjev studentskoj službi"
        />
      </ScrollView>
    );
  }
}
export default Potvrde;

