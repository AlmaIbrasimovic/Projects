import React, { Component } from 'react';

import { StyleSheet, View, Text } from 'react-native';
import { FlatList, ScrollView } from 'react-native-gesture-handler';
import { ListItem } from 'react-native-elements';
import PropTypes from 'prop-types';

const API_BASE_URL= 'https://si2019november.herokuapp.com';
//const API_BASE_URL= 'localhost:31914';
export default class odslusaniPredmeti extends React.Component {
   
  constructor(props)
  {
       super(props);
       this.state = 
       {
           lista: [],
           predmet: {}
       }
  }


  dohvatiPredmete()
    {
        
      fetch(API_BASE_URL+`/November/odslusaniPredmeti/${global.idStudenta}`,
      {
        headers:{
          Authorization: global.token
        }
      }).then(res=>res.json())
      .then(response => {
        this.setState({
          lista: response
        })
      }).catch(e=>{
         console.log('Error', e);
      })



      fetch(API_BASE_URL+`/November/dajOdslusani/1/1`,
      {
        headers:{
          Authorization: global.token
        }
      }).then(res=>res.json())
      .then(response => {
        this.setState({
          predmet: response
        })
      }).catch(e=>{
         console.log('Error', e);
      })
    

    }   
    
    
    componentWillMount()
    {
        this.dohvatiPredmete();
    }

    renderItem = ({item}) => {
          return (
              <ScrollView style={{width: "100%"}}>
                   <Text style={styles.subHeader}> {item.Naziv}</Text>
                   <FlatList
                        data = {item.Predmeti}
                        keyExtractor={item=>item.predmet}
                        renderItem = {({item}) => (
                            <ListItem
                                title={item.predmet}
                                onPress={() => this.props.navigation.navigate("Predmet", this.state.predmet)}
                                chevron
                            />
                        )}
                       
                   />
              </ScrollView>
          )
    }
  
  render() {
        return (
      <View style={styles.MainContainer}>
           <FlatList
            data = {this.state.lista}
            keyExtractor = {item => item.Naziv}
            renderItem = {this.renderItem}
           />
      </View>
    );
  }
}

const styles = StyleSheet.create({
  MainContainer: {
    flex: 1,
    
    
  },
  subHeader:{
    flex: 1,
    backgroundColor: '#195dc4',
    color: 'white',
    padding: 5,
    fontSize: 16,
    fontWeight: 'bold',
    width: '100%',
    paddingLeft: 20,
    paddingRight: 20,
  },
});
