import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import RF from "react-native-responsive-fontsize"

export default class Naslov extends React.Component {
  render() {
    return (
      <View style={styles.regform}>
        <Text style={styles.header}> Poslani zahtjevi za potvrde </Text> 
      </View>
    );
  }
}


const styles = StyleSheet.create({
  regform: {
    alignSelf: 'stretch',    
  },
  header:{
    fontSize: RF(2.5),
    paddingBottom: 10, 
    paddingTop: 2,
    alignSelf: 'center'
  }
});