import React from "react";
import { View, Text, StyleSheet, Dimensions } from "react-native";

const Ocjena = (props) => {
    state = {
        bodoviZadace: 0,
        bodoviIspiti: 0,
        kOcjena: 0
    };
    konacnaOcjena = (ocjena) => {
        if (ocjena < 55) this.state.kOcjena = "Niste položili predmet!";
        else if (ocjena>=55 && ocjena<65) this.state.kOcjena = "Konačna ocjena: " + 6;
        else if (ocjena>=65 && ocjena<75) this.state.kOcjena = "Konačna ocjena: " + 7;
        else if (ocjena>=75 && ocjena<85) this.state.kOcjena ="Konačna ocjena: " + 8;
        else if (ocjena>=85 && ocjena<95) this.state.kOcjena = "Konačna ocjena: " + 9;
        else if (ocjena>=95 && ocjena<=100) this.state.kOcjena = "Konačna ocjena: " + 10;
    }
    zbirBodovaNajboljiRezultat = (ispiti) =>
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
        }
        else {
            this.state.bodoviIspiti = prviParc + drugiParc
        }
    }
    return (
        <View style={styles.text1}>
            {props.zadace.map((zadaca, index) => {
                this.state.bodoviZadace = this.state.bodoviZadace + zadaca.bodovi
            })}
            {this.zbirBodovaNajboljiRezultat(props.ispiti)}
            {this.konacnaOcjena(this.state.bodoviZadace + this.state.bodoviIspiti)}
            <Text style={styles.ocjene}>{(this.state.kOcjena)}</Text>
        </View>
    );
};
export default Ocjena;
const styles = StyleSheet.create({
    text1: {
        marginTop:43,
        textAlign: 'center',
        fontWeight: 'bold'

    },
    ocjene: {
        textAlign:'center',
        fontWeight: 'bold',
        fontSize: 20
    }
});
