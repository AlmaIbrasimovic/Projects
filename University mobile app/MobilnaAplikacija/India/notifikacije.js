import React from 'react';
import {Switch, Text, View, StyleSheet } from 'react-native';
export default class Notifikacija extends React.Component {
    
    constructor(props) {
        super(props);
        this.state = {
            notifikacije:false
        }
        inicijalizovanjeSwitcha = () => {
            this.setState(inicijalni)
        }
        this.promijeniSwitch = this.promijeniSwitch.bind(this);
    }
    promijeniSwitch = () => {
        //ovdje bi se trebala promijeniti i vrijednost u bazi
        this.setState(() => {
            let switch_vrijednost = false;
            if(this.state.notifikacije==false)
                switch_vrijednost=true;
            return {
                notifikacije:switch_vrijednost
            };
        });
    };
    render(){
        //ovdje bi se trebala pročitati vrijednost iz baze
    //    this.inicijalizovanjeSwitcha;
        return(
            <View style={styles.header_container}>
       <View style={styles.header_tekst_view}>
       <Text style={[(this.state.notifikacije)?{color:'#376ff2', fontWeight: 'bold'}:{color:'gray'}, styles.header_tekst]}>{this.state.notifikacije?'Notifikacije su uključene':'Notifikacije su isključene'}</Text>
       </View>
        <View style={styles.header_switch_view}>
        <Switch
          trackColor={{ true: '#376ff2', false: '#d3d3d3'  }}
          thumbColor='white'
          style={[this.notifikacije ?styles.switchEnableBorder:styles.switchDisableBorder]}
          onValueChange = {this.promijeniSwitch}
          value = {this.state.notifikacije}/>
        </View>
        
      </View>
        );
    }
}
const styles = StyleSheet.create({
    header_container:{
      flexDirection: 'row', 
      justifyContent:'space-between', 
      paddingTop: 20,
      paddingBottom: 10
    },
    header_tekst:{
        textAlign: 'center',
      fontSize: 16,
      justifyContent: 'center',
      marginLeft: 5
      
    } ,
    header_switch_view:{
        flex: 1/3,
        alignItems: 'center'
    },
    header_tekst_view:{
        flex: 2/3,
        paddingTop:1,
        alignItems:'stretch'
      },
      switchEnableBorder: {
        borderColor: '#6fa6d3',
        borderWidth: 1},
        
        switchDisableBorder: {
        borderColor: '#f2f2f2',
        borderWidth: 1,  }
  });