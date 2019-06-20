import React from "react";
import {
  StyleSheet,
  Text,
  View,
  FlatList,
  TouchableOpacity,
  ActivityIndicator
} from "react-native";
// import axios from 'axios';

export class ListaIzvjestaja extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      izvjestaji: []
    };
  }

  componentDidMount() {
    this.setState({
      izvjestaji: getIzvjestaji
    });
  }
  render() {
    return (
      <View>
        <FlatList
          data={this.state.izvjestaji}
          keyExtractor={item => item.id.toString()}
          renderItem={({ item }) => (
            <TouchableOpacity style={styles.buttonStyle}>
              <Text
                style={styles.item}
                onPress={() => this.props.navigation.navigate("Izvjestaj", item)}
              >
                {item.title}
              </Text>
            </TouchableOpacity>
          )}
        />
      </View>
    );
  }

  _getSubjectsFromApi = async endpoint => {
    try {
      const response = await fetch(endpoint);
      const data = await response.json();
      return data;
    } catch (error) {
      console.error(error);
    }
  };
}

const getIzvjestaji = [
  {
    id: 1,
    title: "Izvještaj o bodovima za prisustvo za pojedinu godinu"
  },
  {
    id: 2,
    title: "Izvještaj o ukupno ostvarenom broju bodova za pojedine predmete"
  },
  {
    id: 3,
    title: "Izvještaj o ostvarenom broju bodova na prvom parcijalnom za pojedine predmete"
  },
  {
    id: 4,
    title: "Izvještaj o ostvarenom broju bodova na drugom parcijalnom za pojedine predmete"
  },
  {
    id: 5,
    title: "Izvještaj o ostvarenom broju bodova na završnom ispitu za pojedine predmete"
  },
  {
    id: 6,
    title: "Izvještaj o ostvarenom broju bodova na zadaćama za pojedine predmete"
  },
  {
    id: 7,
    title: "Izvještaj o položenim predmetima za tekuću akademsku godinu"
  },
  {
    id: 8,
    title: "Izvještaj o nepoloženim predmetima za tekuću akademsku godinu"
  },
];

const styles = StyleSheet.create({
  item: {
    padding: 5,
    fontSize: 16,
    height: 70,
    textAlign: 'center',
    color: 'white',
  },
  buttonStyle: {
    padding:1,
    backgroundColor: '#2097F3',
    borderRadius:4,
    margin: 10
    }
});
