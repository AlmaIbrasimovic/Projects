import React, { Component } from 'react';
import {
    StyleSheet,
    Text,
    View,
    FlatList,
    ScrollView,
    TouchableOpacity
} from 'react-native';
import axios from 'axios';

const API_BASE_URL= 'https://si2019november.herokuapp.com';

export default class SortiranjeGodina extends Component {

    racunanjeProsjeka(nizOcjena) {
        var prosjek= 0;
        for (var i = 0; i < nizOcjena.length; i++) {
            prosjek += nizOcjena[i];
        }
        prosjek = parseFloat(prosjek / nizOcjena.length).toFixed(2);
        return prosjek;
    }
    constructor(props) {
        super(props)
        this.state = {
            prva: [0],//[6, 6, 6, 7, 6, 9, 8, 8, 8, 6],
            druga: [0],//[6, 7, 8, 8, 7, 9, 7, 8, 8, 7, 7, 9],
            treca: [0],
            cetvrta: [0],
            peta: [0],
            godine:[],
            semestri: [],
            nesortiraniSemestri: 1,
            tekstButtonaSortSemestre: "Prikaži semestre sortirano po prosjeku"
        }
    }

    componentDidMount() {
        this.load()
        this.props.navigation.addListener('willFocus', this.load)//ovo ne brisati ni slucajno


            fetch(API_BASE_URL+`/November/dohvatiProsjeke/${global.idStudenta}`,
            {
              headers:{
                Authorization: global.token
              }
            }).then(res=>res.json()).then(response=>{
                console.log(response)
            console.log(response[0].prva)
              this.setState({
                prva: response[0].prva,      
                druga: response[1].druga,
                treca: response[2].treca,
                godine: response[3].godine,
                semestri: response[4].godine,
              })
              //console.log(this.state)
            }).catch(e =>{
              console.log("Error", e);
            })
          
        //this.setState({
        //    godine: getMarks,
        //    semestri: getSemester
        //});
    }
       
    load = () => {
        if(global.logovan != true)
        {
            this.props.navigation.navigate("loginScreen", {})
        }  
    }

    promjenaSemestara = (data) => {
        if(data=='1') {
        this.setState({ 
            nesortiraniSemestri: data,
            tekstButtonaSortSemestre: "Prikaži semestre sortirano po prosjeku"
         });
        }
        else  {
        this.setState({ 
            nesortiraniSemestri: data,
            tekstButtonaSortSemestre: "Prikaži semestre redom"
            });
        }
    }


    render() {
        var prosjekPrve = this.racunanjeProsjeka(this.state.prva);
        var prosjekDruge = this.racunanjeProsjeka(this.state.druga);
        var prosjekTrece = this.racunanjeProsjeka(this.state.treca);
        var godineProsjek = [
            {
                godina : 'Prva godina',
                prosjek : prosjekPrve
            },
            {
                godina : 'Druga godina',
                prosjek : prosjekDruge
            },
            {
                godina : 'Treća godina',
                prosjek : prosjekTrece
            }
        ];
        var godineProsjekNesortirano=Object.assign({}, godineProsjek); //Dodajemo vrijednost objekta, ne referencu

        var prviSemestar = this.racunanjeProsjeka(this.state.prva.slice(0, this.state.prva.length/2));
        var drugiSemestar = this.racunanjeProsjeka(this.state.prva.slice(this.state.prva.length/2, this.state.prva.length));
        var treciSemestar = this.racunanjeProsjeka(this.state.druga.slice(0, this.state.druga.length/2));
        var cetvrtiSemestar = this.racunanjeProsjeka(this.state.druga.slice(this.state.druga.length/2, this.state.druga.length));
        var petiSemestar = this.racunanjeProsjeka(this.state.treca.slice(0, this.state.treca.length/2));
        var sestiSemestar = this.racunanjeProsjeka(this.state.treca.slice(0, this.state.treca.length/2, this.state.treca.length));
        var sveOcjene = this.state.prva.concat(this.state.druga, this.state.treca);
        var ukupniProsjek = this.racunanjeProsjeka(sveOcjene);
       
        var semestriProsjek = [
            {
                id: 1,
                title: ' 1. semestar: ',
                prosjek: prviSemestar
            },
            {
                id: 2,
                title: ' 2. semestar: ',
                prosjek: drugiSemestar
            },
            {
                id: 3,
                title: ' 3. semestar: ',
                prosjek: treciSemestar
            },
            {
                id: 4,
                title: ' 4. semestar: ',
                prosjek: cetvrtiSemestar
            },
            {
                id: 5,
                title: ' 5. semestar: ',
                prosjek: petiSemestar
            },
            
            {
                id: 6,
                title: ' 6. semestar: ',
                prosjek: sestiSemestar
            }
            
        ];
        var semestriProsjekNesortirano = [
            {
                id: 1,
                title: ' 1. semestar: ',
                prosjek: prviSemestar
            },
            {
                id: 2,
                title: ' 2. semestar: ',
                prosjek: drugiSemestar
            },
            {
                id: 3,
                title: ' 3. semestar: ',
                prosjek: treciSemestar
            },
            {
                id: 4,
                title: ' 4. semestar: ',
                prosjek: cetvrtiSemestar
            },
            {
                id: 5,
                title: ' 5. semestar: ',
                prosjek: petiSemestar
            },
            
            {
                id: 6,
                title: ' 6. semestar: ',
                prosjek: sestiSemestar
            }
            
        ];

        godineProsjek.sort(function(a,b){
            return parseFloat(b.prosjek)  - parseFloat(a.prosjek);
        })
        semestriProsjek.sort(function(a,b){
            return parseFloat(b.prosjek)  - parseFloat(a.prosjek);
        })
        prosjeciPoSemestruSort = (
            <View testID="semestri">
            <Text style={styles.subHeader}> Prosjeci po semestrima sortirani</Text>
            <FlatList
                data={semestriProsjek}
                keyExtractor={item => item.id.toString()}
                renderItem={({item}) => (
                    <Text style={styles.item}>
                        {item.title} {item.prosjek}
                    </Text>
                )}                     
            />
            </View>
        )
        
        prosjeciPoSemestruNesort = (
            
            <View>
            <Text style={styles.subHeader}> Prosjeci po semestrima</Text>
            <FlatList
            data={semestriProsjekNesortirano}
                keyExtractor={item => item.id.toString()}
                renderItem={({item}) => (
                    <Text style={styles.item}>
                        {item.title} {item.prosjek}
                    </Text>
                )}                    
            />
            </View>
            
        )
        return (
            <ScrollView>
            <View style={styles.MainContainer}>  
                <View testID="ukupni">
                    <Text style={{ fontSize: 18, fontWeight: 'bold', marginTop: 10 }}> Ukupan prosjek: {ukupniProsjek}</Text>
                </View>
                <View
                    style={{
                        borderBottomColor: 'black',
                        borderBottomWidth: 1,
                    }}
                />
                <View testID="godine">
                    <Text style={styles.subHeader}> Prosjeci po godinama</Text>
                    <FlatList
                        data = {[
                            {key:godineProsjekNesortirano[0].godina, value:godineProsjekNesortirano[0].prosjek},
                            {key:godineProsjekNesortirano[1].godina, value:godineProsjekNesortirano[1].prosjek},
                            {key:godineProsjekNesortirano[2].godina, value:godineProsjekNesortirano[2].prosjek}
                        ]}
                        renderItem={({item}) => (
                            <Text style={styles.item}>
                                {item.key}: {item.value}
                            </Text>
                        )}                     
                    />
                </View>
                <View
                    style={{
                        borderBottomColor: 'black',
                        borderBottomWidth: 1,
                    }}
                    />
                <View>
                    <Text style={styles.subHeader}> Prosjeci po godinama sortirani</Text>
                    <FlatList
                        data = {[
                            {key:godineProsjek[0].godina, value:godineProsjek[0].prosjek},
                            {key:godineProsjek[1].godina, value:godineProsjek[1].prosjek},
                            {key:godineProsjek[2].godina, value:godineProsjek[2].prosjek}
                        ]}
                        renderItem={({item}) => <Text style={styles.item}>{item.key}: {item.value}</Text>}
                        renderItem={({item}) => <Text style={styles.item}>{item.key}: {item.value}</Text>}
                        renderItem={({item}) => <Text style={styles.item}>{item.key}: {item.value}</Text>}
                    />
                </View>
                <View testID="semestri">
                <View
                    style={{
                        borderBottomColor: 'black',
                        borderBottomWidth: 1,
                    }}
                    />
                {this.state.nesortiraniSemestri == '1' ? prosjeciPoSemestruNesort : prosjeciPoSemestruSort}
                </View>
                <View>
                     <TouchableOpacity 
                     onPress={()=>{
                        if(this.state.nesortiraniSemestri=='1')
                        this.promjenaSemestara('2')
                        else
                        this.promjenaSemestara('1')}} 
                     style = {styles.button} >
                        <Text style={{color: 'white', fontWeight:'bold'}}>
                        {this.state.tekstButtonaSortSemestre}
                        </Text>
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
        
    },
    item: {
        padding: 3,
        fontSize: 14,
        height: 25,
    },
    button: {
        backgroundColor: '#2097F3', 
        alignItems: 'center', 
        justifyContent: 'center', 
        borderRadius: 4,
        padding: 8,
        marginTop: 6,
        marginBottom: 10
    },
    subHeader:{
        backgroundColor: '#195dc4',
        color: 'white',
        padding: 5,
        fontSize: 15,
        fontWeight: 'bold',
     
        width: '100%'
      },
});