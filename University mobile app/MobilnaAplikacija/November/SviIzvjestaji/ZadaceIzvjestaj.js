import React, { Component } from 'react';
import {View,Text,StyleSheet, FlatList, TouchableOpacity, ScrollView} from 'react-native';
import axios from 'axios';
const API_BASE_URL= 'https://si2019november.herokuapp.com';
let http=axios.create();
http.defaults.timeout = 200;
class ZadaceIzvjestaj extends Component {

  // default State object
  state = {
    subjects: []
  };

  componentDidMount() {
    
    fetch(API_BASE_URL+`/November/dohvatiZadace/${global.idStudenta}`,
    {
      headers:{
        Authorization: global.token
      }
    }).then(res=>res.json())
    .then(response => {
      this.setState({
        subjects: response
      })
    }).catch(e=>{
       console.log('Error', e);
    })

  }

  render() {
    return (
      <ScrollView >
      <FlatList
          data={this.state.subjects}
          keyExtractor={item => item.predmet.toString()}
          renderItem={({ item }) => (
            <View style={styles.Viewitem}>
            <View style={styles.Viewitem1}>
              <Text style={styles.item}>
                {item.predmet}
              </Text>
              </View>
              <View style={styles.Viewitem2}>
              <Text style={styles.item}>
                {item.bodovi}
              </Text>
              </View>
              </View>
          )}
        />
      </ScrollView>
    );
  }
  
}

//Hardkodirani podaci Za slučaj kad se ne može konektovati na bazu
export default ZadaceIzvjestaj;

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
  }
});

