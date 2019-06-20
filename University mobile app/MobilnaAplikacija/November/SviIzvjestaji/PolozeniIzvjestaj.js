import React, { Component } from 'react';
import {View,Text,StyleSheet, FlatList, TouchableOpacity, ScrollView} from 'react-native';
import { ListItem } from 'react-native-elements';
import axios from 'axios';
const API_BASE_URL= 'https://si2019november.herokuapp.com';
let http=axios.create();
http.defaults.timeout = 200;
class PolozeniIzvjestaj extends Component {

  // default State object
  state = {
    polozeni: []
  };

  dohvatiPolozene()
  {
    fetch(API_BASE_URL+`/November/dohvatiPolozene/${global.idStudenta}`,
    {
      headers:{
        Authorization: global.token
      }
    }).then(res=>res.json())
    .then(response => {
      this.setState({
        polozeni: response
      })
    }).catch(e=>{
       console.log('Error', e);
    })
  }

  
    componentWillMount() 
    {
        this.dohvatiPolozene();   
    }


  render() {
    return (
      <ScrollView >
      <Text style={styles.tekstov}>Položili ste predmete:</Text>
      <FlatList
          data={this.state.polozeni}
          keyExtractor = {item => item.key}
          renderItem={({ item }) => (
            <ListItem
            title={item.naziv}
             />
          )}
        />
      </ScrollView>
    );
  }
  
}

//Hardkodirani podaci Za slučaj kad se ne može konektovati na bazu
export default PolozeniIzvjestaj;


const styles = StyleSheet.create({
  item: {
    padding: 5,
    margin: 5,
    fontSize: 16,
    height: 80,
  },
  Viewitem: {
    flexDirection: 'row',
    alignItems: 'center',
  },
  Viewitem1: {
    borderWidth: 1,  
    borderColor: "black",
    backgroundColor: "#ededed",
    flex: 1,
    flexDirection: 'row',
    justifyContent: 'flex-start',
    width: '70%'
  },
  Viewitem2: {
    borderWidth: 1,  
    borderColor: "black",
    backgroundColor: "#ededed",
    flex: 1,
    flexDirection: 'row',
    justifyContent: 'flex-end',
  },
  tekstov:
  {
      fontSize: 24,
      
  }
});

