import React from "react";
import { View, Text, StyleSheet, Dimensions } from "react-native";
import ProgressBarAnimated from "react-native-progress-bar-animated";
import AnimatedBar from "react-native-progress-bar-animated";
import { tsConstructorType } from "@babel/types";


const ProgressBar = (props) => {

    state = {
        bodoviZadace: 0,
        bodoviIspiti: 0
      };
    
      zbirBodovaPoNajboljemRezultatu = (ispiti) =>
      {
      prviParc=-1;
      drugiParc=-1;
      integralno=-1;
      ispiti.map((ispit, index) => {
        if (prviParc<ispit.bodovi && ispit.naziv=="Prvi parcijalni") {
            prviParc=ispit.bodovi
        }
        if (drugiParc<ispit.bodovi && ispit.naziv=="Drugi parcijalni") {
            drugiParc=ispit.bodovi
        }
        if (integralno<ispit.bodovi && ispit.naziv=="Integralni") {
            integralno=ispit.bodovi
        }

      })
      if(prviParc==-1) {
          prviParc=0
      }
      if(drugiParc==-1) {
          drugiParc=0
      }
      if(integralno!=-1) {
          this.state.bodoviIspiti = integralno
          //return integralno;
      }
      else {
          this.state.bodoviIspiti = prviParc + drugiParc
            //return prviParc+drugiParc;
        }
    } 
    promjenaBojeProgressBara = (bodovi) => 
    {
        if(bodovi<33) 
        {
            progressCustomStyles.backgroundColor='red';
        }
        else if (bodovi<66)
        {
            progressCustomStyles.backgroundColor= 'yellow'
        }
        else 
        {
            progressCustomStyles.backgroundColor= 'green';
        }
    }
    const progressCustomStyles= {
        backgroundColor: 'green',
        height: 30,
        borderColor: 'black',
        borderRadius: 50
      }
    return (
        <View style={styles.text1}>
            {props.zadace.map((zadaca, index) => {
                    this.state.bodoviZadace = this.state.bodoviZadace + zadaca.bodovi
            })}
            {this.zbirBodovaPoNajboljemRezultatu(props.ispiti)}
            
            <Text style= {styles.text1}>Osvojili ste: {this.state.bodoviZadace+this.state.bodoviIspiti+props.prisustvo} bodova</Text> 
            {this.promjenaBojeProgressBara(this.state.bodoviZadace+this.state.bodoviIspiti)}
           
            <ProgressBarAnimated
            {...progressCustomStyles}
            width= {Dimensions.get('screen').width - 45}
            value={this.state.bodoviZadace+this.state.bodoviIspiti+props.prisustvo}            
            backgroundColorOnComplete="green"
          >
          </ProgressBarAnimated>
          <Text style={styles.text2}>
          što je {(this.state.bodoviZadace+this.state.bodoviIspiti+props.prisustvo)}% od ukupno mogućih 100 bodova.
          </Text>
        </View>
    );
};

export default ProgressBar;

const styles = StyleSheet.create({
   text1: {
    textAlign: 'center', 
    fontWeight: 'bold',
    margin: 10
   },
   text2: {
    textAlign: 'center',
    margin: 7
   }
  });
