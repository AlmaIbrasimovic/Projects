import React, { Component } from 'react';

import { StyleSheet, View, Text } from 'react-native';
import { ScrollView } from 'react-native-gesture-handler';


export default class changelog extends Component {
  componentDidMount()
  {
      this.load()
      this.props.navigation.addListener('willFocus', this.load)
      
  }

  load = () => {
    if(global.logovan != true)
    {
        this.props.navigation.navigate("loginScreen", {})
    }  
  }

  render() {
    return (
    
        <ScrollView style={styles.MainContainer}>
          <Text style={styles.subHeader}>1.2.0</Text>
          <Text style={{ fontSize: 20, fontWeight:"bold" }}>November:</Text>
          <Text>-Dodane kategorije različitih izvještaja</Text>
          <Text>-Dodano računanje bodova i progress bar na pregledu predmeta</Text>
          <Text>-Urađen prikaz izvještaja o bodovima za prvu i drugu parcijalu</Text>
          <Text>-Dodan pregled završnog rada</Text>

          <Text style={styles.subHeader}>1.1.0</Text>
          <Text style={{ fontSize: 20, fontWeight:"bold" }}>November:</Text>
          <Text>-Dodana ikonica za preusmjeravanje na C9</Text>
          <Text>-Na dashboard dodano dugme za prikaz odslušanih predmeta</Text>
          <Text>-Dodan pregled odslušanih predmeta</Text>
          <Text>-Omogućen pregled nekog od aktuelnih predmeta klikom na njega</Text>


          <Text style={styles.subHeader}>1.0.0</Text>
          <Text style={{ fontSize: 20, fontWeight:"bold" }}>November:</Text>
          <Text>-Urađen prikaz studentovih ličnih podataka</Text>
          <Text>-Na dashboard dodani predmeti koje student sluša kao i obaviještenja</Text>
          <Text>-Dodane ikonice za preusmjeravanje na webmail/dreamspark</Text>
          <Text>-Dodane informacije o prosjeku studenta</Text>
        </ScrollView>

    );
  }
}

const styles = StyleSheet.create({
  MainContainer: {
    flex: 1,
    //paddingLeft: 10,
    //paddingTop: 20,
    //alignItems: 'left',
    //marginTop: 50,
//    justifyContent: 'center',
  },
  subHeader:{
    backgroundColor: '#195dc4',
    color: 'white',
    fontSize: 15,
    fontWeight: 'bold',
    width: '100%',
    padding: 5,
  },
});