import React from 'react';
import { StyleSheet, Text, View, ScrollView } from 'react-native';
import PodaciOStudentu from './PodaciOStudentu';
import Slika from './Slika';

class Student extends React.Component
  {
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
      return(
      <ScrollView>   
          <Slika />
          <PodaciOStudentu/>
      </ScrollView> );
 }
}
  
export default Student