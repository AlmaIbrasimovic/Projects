import React, { Component } from 'react';
import {View, Text, ScrollView} from 'react-native';
import Obavijest from './Obavijest';
import PropTypes from 'prop-types';

const API_BASE_URL= 'https://si2019november.herokuapp.com';
class Obavijesti extends Component {
  state={
    obavijesti:[]
  }
  componentWillMount(){
    

    fetch(API_BASE_URL+`/November/novosti?idStudenta=${global.idStudenta}`,
    {
      headers:{
        Authorization: global.token
      }
    }).then(res=>res.json())
    .then(response => {
      this.setState({
        obavijesti: response
      })
    }).catch(e=>{
       console.log('Error', e);
    })
  }
  
  render() {
    let obavijesti=this.state.obavijesti.map((obavijest, index)=>{
      return <Obavijest key={index} naziv={obavijest.naziv} tekst= {obavijest.tekst}/>
    });

    return obavijesti;
    
  }
}
Obavijesti.propTypes={
  id:PropTypes.number.isRequired
}

   
export default Obavijesti;