import React, { Component } from 'react';

import { StyleSheet, View, ScrollView, Text, Image, TouchableOpacity, Linking, Button } from 'react-native';
import { SubjectsList } from './SubjectsList';
import { Divider } from 'react-native-elements';
import Obavijesti from './NewsFeed/Obavijesti';
import { NavigationActions } from 'react-navigation';

export default class Dashboard extends Component {


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
      <ScrollView>
      <View style={styles.MainContainer}>
           <Text style={styles.subHeader}>Predmeti aktuelnog semestra:</Text>
         <View style={styles.subjectsContainer}>
           <SubjectsList navigation={this.props.navigation}/>
         </View>
         <TouchableOpacity style={styles.buttonChoose}  onPress={() => this.props.navigation.navigate("odslusaniPredmeti", 1)}>
         <Text style = {styles.dugmeTekst}>
            Odslušani predmeti
          </Text>
          </TouchableOpacity>
          
          <Text style={{ fontSize: 10 }}></Text>
          <Text style={styles.subHeader}>Aktuelne obavijesti:</Text>
          <ScrollView style={styles.notificationsContainer}>
              <Obavijesti id={1}/>
          </ScrollView>
     
         
          <View style={styles.Down}>
              <TouchableOpacity activeOpacity = { .5 } onPress={ ()=>{ Linking.openURL('https://e5.onthehub.com/WebStore/Security/Signin.aspx?ws=f7e15a22-e060-e211-a88c-f04da23e67f4')}}>
                  <Image source={require('../assets/DreamSpark.png')} style = {styles.Icon} />
              </TouchableOpacity>
              <TouchableOpacity activeOpacity = { .5 } onPress={ ()=>{ Linking.openURL('https://mail.etf.unsa.ba')}}>
                <Image source={require('../assets/icons/Zimbra.png')} style = {styles.Icon} />
              </TouchableOpacity>
              <TouchableOpacity activeOpacity = { .5 } onPress={ ()=>{ Linking.openURL('https://c9.etf.unsa.ba')}}>
                <Image source={require('../assets/icons/c9.png')} style = {styles.Icon} />
              </TouchableOpacity>
          </View>
      </View>
      </ScrollView>
    );
  }
}

const styles = StyleSheet.create({
  MainContainer: {
    flex: 1,
    alignItems: 'center',
    marginTop: 0,
    marginBottom: 0,
    padding:0
  },
  subjectsContainer: {
    //height: '32%',
    width: '100%',
    justifyContent: 'center'
  },
  divider: {
    width: '90%',
    borderBottomWidth: 1,
    borderBottomColor: 'black'
  },
  notificationsContainer: {
  
    marginBottom: 55
  },
  Icon: {
    width: 55,
    height: 55
  },
  Down: {
    flex: 1,
    flexDirection: 'row',
    position: 'absolute',
    left: 0,
    bottom: 0,
    margin:0,
    padding:0,
  },
  subHeader:{
    backgroundColor: '#195dc4',
    color: 'white',
    padding: 5,
    fontSize: 15,
    fontWeight: 'bold',
 
    width: '100%'
  },
  button:{
    backgroundColor: 'lightgrey', 
    alignItems: 'center', 
    justifyContent: 'center', 
    borderRadius: 5,
    padding: 7,
    marginTop: 10,
    marginLeft: '18%',
    marginRight: '18%',
    marginBottom: 10
  },
  button2: {
    width: '50%',
    marginBottom: 10,
  },
  buttonChoose: {
    backgroundColor: '#2097F3', 
    alignItems: 'center', 
    justifyContent: 'center', 
    borderRadius: 4,
    padding: 10,
    marginTop: 10,
    marginLeft: '8%',
    marginRight: '8%'
    },
    dugmeTekst: {
      color: '#ffffff',
      fontWeight: 'bold',
     },

});
