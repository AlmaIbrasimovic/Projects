import React, { Component } from 'react';
import {View,Text,StyleSheet} from 'react-native';
import PropTypes from 'prop-types';
import  ReadMore from 'react-native-read-more-text';
 class Obavijest extends Component {
  render() {
    return (
      <View style={styles.container}>
          <Text style={styles.tekst1}>Obavijest: {this.props.naziv}</Text>
          <ReadMore 
           numberOfLines={2}
           renderTruncatedFooter={this.prikaziVise}
           renderRevealedFooter={this.prikaziManje}>
          <Text style={styles.text}>{this.props.tekst}</Text>
          </ReadMore>
         
      </View>
    )
  }
  prikaziVise = (handlePress) => {
    return (
        <Text style={{  color: 'blue', marginTop: 5}} onPress={handlePress}>
            Prikaži više
        </Text>
    );
  }
  prikaziManje = (handlePress) => {
    return (
        <Text style={{color: 'blue', marginTop: 5}} onPress={handlePress}>
            Prikaži manje
        </Text>
    );
  }
}
Obavijest.propTypes={
    naziv:PropTypes.string.isRequired,
    tekst:PropTypes.string.isRequired
}

const styles = StyleSheet.create({
    container: {
        marginTop:5,
        width: "100%",
        textAlign:"left",
        borderWidth: 1,
        borderColor: 'lightgrey'
    },
    text:{
      marginLeft: 7,
      height: 'auto',
      width: '90%',
    },
    tekst1: {
      color: '#737373',
      fontSize: 13,
      marginTop: 7,
      marginLeft: 10
      }
    ,
  });
export default Obavijest;