import React, { Component } from 'react'
import {View,Text,StyleSheet,ScrollView} from 'react-native';
import UkupanBrojBodova from './UkupanBrojBodova'
import PrviParcijalniIzvjestaj from './PrviParcijalniIzvjestaj';
import DrugiParcijalniIzvjestaj from './DrugiParcijalniIzvjestaj';
import ZavrsniIspitIzvjestaj from './ZavrsniIspitIzvjestaj';
import PrisustvoIzvjestaj from './PrisustvoIzvjestaj';
import PolozeniIzvjestaj from './PolozeniIzvjestaj';
import NepolozeniIzvjestaj from './NepolozeniIzvjestaj';
import ZadaceIzvjestaj from './ZadaceIzvjestaj';
export default class Izvjestaj extends Component {
  render() {
    const {id, title}=this.props.navigation.state.params;
    console.log(title);

    //Izvjestaj za bodove ukupno ...
    if(id==2)
    return (
    <ScrollView style={style.container}>
      <Text style={style.text}>Izvještaj: {title}{"\n"}</Text>  
      <UkupanBrojBodova /> 
    </ScrollView>
    )
    //Izvjestaj o bodovima za prisustvo...
    else if(id==1)
    return (
      <ScrollView style={style.container}>
        <Text style={style.text}>Izvještaj: {title}{"\n"}</Text>
        <PrisustvoIzvjestaj/>
      </ScrollView>
      )
      
    //Izvjestaj o bodovima za prvu parcijalu...
      else if(id==3)
    return (
      <ScrollView style={style.container}>
        <Text style={style.text}>Izvještaj: {title}{"\n"}</Text>
        <PrviParcijalniIzvjestaj/>
      </ScrollView>
      )
      
    //Izvjestaj o bodovima za drugu parcijalu...
      else if(id==4)
    return (
      <ScrollView style={style.container}>
        <Text style={style.text}>Izvještaj: {title}{"\n"}</Text>
        <DrugiParcijalniIzvjestaj/>
      </ScrollView>
      )
      
    //Izvjestaj o bodovima za zavrsni...
      else if(id==5)
    return (
      <ScrollView style={style.container}>
        <Text style={style.text}>Izvještaj: {title}{"\n"}</Text>
        <ZavrsniIspitIzvjestaj/>
      </ScrollView>
      )

      //Izvjestaj o bodovima na zadacama...
      else if(id==6)
    return (
      <ScrollView style={style.container}>
        <Text style={style.text}>Izvještaj: {title}{"\n"}</Text>
        <ZadaceIzvjestaj/>
      </ScrollView>
      )

      //Izvjestaj o polozenim predmetima...
      else if(id==7)
    return (
      <ScrollView style={style.container}>
        <Text style={style.text}>Izvještaj: {title}{"\n"}</Text>
        <PolozeniIzvjestaj/>
      </ScrollView>
      )


      //Izvjestaj o nepolozenim predmetima...
      else if(id==8)
    return (
      <ScrollView style={style.container}>
        <Text style={style.text}>Izvještaj: {title}{"\n"}</Text>
        <NepolozeniIzvjestaj/>
      </ScrollView>
      )
  }
}
const style=StyleSheet.create({
  container: {
    margin: 10
  }, 
  text:{
        fontSize:19
    }
})