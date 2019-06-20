import React, { Component } from 'react';
import { ScrollView, View, Text, Button, TouchableOpacity, StyleSheet, TextInput } from 'react-native'
import axios from 'axios'
import * as res from './pomocniPodaciOStudentu'
export default class PodaciOStudentu extends Component {


state= { 
    id: "",
    ime:"",
    prezime:"",
    adresa:"",
    ciklus:null,
    datumRodjenja:"",
    drzavljanstvo:"",
    email:"",
    fotografija:"",
    imePrezimeMajke:"",
    imePrezimeOca:"",
    indeks:null,
    kanton:"",
    linkedin:"",
    mjestoRodjenja:"",
    password:"",
    semestar:"",
    spol:true,
    telefon:"",
    titula:null,
    username:"",
    website:"",
    idOdsjek:1,
    idUloga:1
} 

APIpoziv = () =>
{
axios.get(`https://si2019november.herokuapp.com/November/dohvatiPodatke/${global.idStudenta}`).then(res =>{ //Staviti ovdje id ulogovanog studenta
   this.dodajPodatke(res.data);
}).catch(error => {
    alert("Problem sa konekcijom na bazu");
});
}
//Privremeno dodavanje dummy podataka
dodajPodatke = (res) => {
this.setState({
    id: res[0].id,
    ime: res[0].ime,
    prezime: res[0].prezime,
    adresa: res[0].adresa,
    ciklus:res[0].ciklus,
    datumRodjenja: res[0].datumRodjenja,
    drzavljanstvo:res[0].drzavljanstvo,
    email: res[0].email,
    fotografija: res[0].fotografija,
    imePrezimeMajke: res[0].imePrezimeMajke,
    imePrezimeOca: res[0].imePrezimeOca,
    indeks: res[0].indeks,
    kanton: res[0].kanton,
    linkedin:res[0].linkedin,
    mjestoRodjenja:res[0].mjestoRodjenja,
    password: res[0].password,
    semestar: res[0].semestar,
    spol:res[0].spol,
    telefon:res[0].telefon,
    titula:res[0].titu,
    username:"",
    website:"",
    idOdsjek:1,
    idUloga:1
   /* adresa: res.user[0].adresa,
    ciklus:res.user[0].ciklus,
    datumRodjenja: res.user[0].datumRodjenja,
    drzavljanstvo:res.user[0].drzavljanstvo,
    email: res.user[0].email,
    fotografija: res.user[0].fotografija,
    imePrezimeMajke: res.user[0].imePrezimeMajke,
    imePrezimeOca: res.user[0].imePrezimeOca,
    indeks: res.user[0].indeks,
    kanton: res.user[0].kanton,
    linkedin:res.user[0].linkedin,
    mjestoRodjenja:res.user[0].mjestoRodjenja,
    password: res.user[0].password,
    semestar: res.user[0].semestar,
    spol:res.user[0].spol,
    telefon:res.user[0].telefon,
    titula:res.user[0].titu,
    username:"",
    website:"",
    idOdsjek:1,
    idUloga:1  */

 });
}
spolToString = (spol) => {
    if (spol==true) return "muški"
    else return "ženski"
}
  render() { 
      
  return (   
  <ScrollView> 
      {this.APIpoziv()}
      <View>
          <Text style = {styles.podnaslov}>
          Osnovni podaci
          </Text>
          <Text style = {styles.tekst1}>
          Ime:
          </Text>
          <TextInput style = {styles.input}
           value={this.state.ime}
           onChangeText={(text) => this.setState({ime: text})}/>
          <Text style = {styles.tekst1}>
          Prezime:
          </Text>
          <TextInput style = {styles.input}
           value={this.state.prezime}
           onChangeText={(text) => this.setState({prezime: text})}/>
          <Text style = {styles.tekst1}>
          Spol:
          </Text>
          <TextInput style = {styles.input}
           value={this.spolToString(this.state.spol)}/>
           <Text style = {styles.tekst1}>
          Broj indeksa:
          </Text>
          <TextInput style = {styles.input}
           value={this.state.indeks}
           onChangeText={(text) => this.setState({indeks: text})}/>
      </View> 
      <View>
        <Text style = {styles.podnaslov}>
        Kontakt podaci
        </Text>
        <Text style = {styles.tekst1}>
        Adresa:
        </Text>
        <TextInput style = {styles.input}
       value={this.state.adresa}
       onChangeText={(text) => this.setState({adresa: text})}/>
        <Text style = {styles.tekst1}>
        Kontaks telefon:
        </Text>
        <TextInput style = {styles.input}
        value={this.state.telefon}
        onChangeText={(text) => this.setState({telefon: text})}/>
        <Text style = {styles.tekst1}>
        Kontakt e-mail:
        </Text>
        <TextInput style = {styles.input}
        value={this.state.email}
        onChangeText={(text) => this.setState({email: text})}/>
        <Text style = {styles.tekst1}>
        Linkedin:
        </Text>
        <TextInput style = {styles.input}
        value={this.state.linkedin}
        onChangeText={(text) => this.setState({linkedin: text})}/>
        <Text style = {styles.tekst1}>
        Web stranica:
        </Text>
        <TextInput style = {styles.input}
        value={this.state.website}
        onChangeText={(text) => this.setState({website: text})}/>
    </View>
    <View>
        <Text style = {styles.podnaslov}>
        Lični podaci
        </Text>
        <Text style = {styles.tekst1}>
        Ime i prezime oca:
        </Text>
        <TextInput style = {styles.input}
       value={this.state.imePrezimeOca}
       onChangeText={(text) => this.setState({imePrezimeOca: text})}/>
        <Text style = {styles.tekst1}>
        Ime i prezime majke:
        </Text>
        <TextInput style = {styles.input}
        value={this.state.imePrezimeMajke}
        onChangeText={(text) => this.setState({imePrezimeMajke: text})}/>
        <Text style = {styles.tekst1}>
        Datum rođenja:
        </Text>
        <TextInput style = {styles.input}
        value = {this.state.datumRodjenja}
        onChangeText={(text) => this.setState({datumRodjenja: text})}/>
        <Text style = {styles.tekst1}>
        Mjesto rođenja:
        </Text>
        <TextInput style = {styles.input}
        value = {this.state.mjestoRodjenja}
        onChangeText={(text) => this.setState({mjestoRodjenja: text})}/>
        <Text style = {styles.tekst1}>
        Kanton:
        </Text>
        <TextInput style = {styles.input}
        value={this.state.kanton}
        onChangeText={(text) => this.setState({kanton: text})}/>
        <Text style = {styles.tekst1}>
        Državljanstvo
        </Text>
        <TextInput style = {styles.input}
        value={this.state.drzavljanstvo}
        onChangeText={(text) => this.setState({drzavljanstvo: text})}/>
    </View>   
      <TouchableOpacity  style = {styles.button} >
          <Text style={styles.dugmeTekst}>
          Pošalji zahtjev
          </Text>
      </TouchableOpacity>  
   </ScrollView>
  );
  }
  }
  
  const styles = StyleSheet.create({
    container: {
    flex: 1,
    flexDirection: 'row'
    },
    button: {
    backgroundColor: '#2097F3', 
    alignItems: 'center', 
    justifyContent: 'center', 
    borderRadius: 4,
    padding: 12,
    marginTop: 10,
    marginLeft: '18%',
    marginRight: '18%',
    marginBottom: 20
    },      
    podnaslov: {
    backgroundColor: '#195dc4',
    color: 'white',
    padding: 5,
    fontSize: 15,
    fontWeight: 'bold',
    marginTop: 10,
    },
    input: {
    marginLeft: 7,
    height: 40,
    borderWidth: 1,
    width: '90%',
    borderColor: 'lightgrey'
    },
    tekst1: {
    color: '#737373',
    fontSize: 13,
    marginTop: 7,
    marginLeft: 10
    },
    dugmeTekst: {
        color: '#ffffff',
        fontWeight: 'bold',
       },
   })