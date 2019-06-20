import React, { Component } from 'react'
import { View, Text, Button, Image, TouchableOpacity, StyleSheet } from 'react-native'
import { ImagePicker } from 'expo';

class Slika extends React.Component  { 
  state = {
    image: null,
  };
render() {  
  let { image } = this.state;

return (
<View>
<Text style = {styles.podnaslov}>
  Slika
</Text>
{image && <Image source={{ uri: image }} style={styles.slika} />}
  <TouchableOpacity style={styles.buttonChoose} onPress={this._pickImage}>
  <Text style = {styles.dugmeTekst}>
    Choose file
  </Text>
  </TouchableOpacity>
    
  <TouchableOpacity style={styles.buttonChoose}>
  <Text style = {styles.dugmeTekst}>
    Dodaj sliku
  </Text>
  </TouchableOpacity>
        
      </View>
);
}
_pickImage = async () => {
  let result = await ImagePicker.launchImageLibraryAsync({
    allowsEditing: true,
    aspect: [4, 3],
  });

  console.log(result);

  if (!result.cancelled) {
    this.setState({ image: result.uri });
  }
};
}

export default Slika

const styles = StyleSheet.create({
    container: {
    flex: 1,
    flexDirection: 'row',
    justifyContent: 'space-between'
    },
    buttonChoose: {
    backgroundColor: '#2097F3', 
    alignItems: 'center', 
    justifyContent: 'center', 
    borderRadius: 4,
    padding: 10,
    marginTop: 10,
    marginLeft: '8%',
    marginRight: '8%'
    },
    buttonAdd: {
    backgroundColor: 'lightgrey', 
    alignItems: 'center', 
    justifyContent: 'center', 
    borderRadius: 2,
    padding: 20,
    marginTop: 10,
    marginRight: '8%'
    },      
    podnaslov: {
    backgroundColor: '#195dc4',
    color: 'white',
    padding: 5,
    fontSize: 15,
    fontWeight: 'bold',
    marginTop: 10,
    },
    slika: { 
    alignItems: 'center', 
    justifyContent: 'center', 
    height: 200,
    width: '50%',
    marginTop: 10,
    marginLeft: '25%',
    marginRight: '25%'
    },
    imagestyle: {
    justifyContent: 'center',
    alignItems: 'center',
    },
    dugmeTekst: {
       color: '#ffffff',
       fontWeight: 'bold',
      },
   })