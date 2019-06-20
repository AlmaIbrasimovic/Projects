import React from "react";
import {
  StyleSheet,
  Text,
  ScrollView,
  FlatList,
  TouchableOpacity,
  ActivityIndicator
} from "react-native";
import { ListItem } from 'react-native-elements';

import Zavrsni from './Zavrsni';


const API_BASE_URL= 'https://si2019november.herokuapp.com';
export class SubjectsList extends React.Component {
  constructor(props) {
    super(props);

    this.state = {
      subjects: []
    };
  }

  componentWillMount() {
    fetch(API_BASE_URL+`/November/predmeti?idStudenta=${global.idStudenta}`,
    {
      headers:{
        Authorization: global.token
      }
    }).then( res => res.json()).
    then(response=>{
      this.setState({
        subjects: response
      })
    }).catch(e =>{
      console.log("Error", e);
    })
  }
  render() {
    return (
      <ScrollView>
        <FlatList
          data={this.state.subjects}
          keyExtractor={item => item.id.toString()}
          renderItem={({ item }) => (
            <ListItem
              title={item.title}
              onPress={() => this.props.navigation.navigate("Predmet", item)}
              chevron
            />
          )}
        />
        <TouchableOpacity>
          <Text style={styles.iteme}  onPress={() => this.props.navigation.navigate("Zavrsni",1)}>Završni rad</Text>
        </TouchableOpacity>
      </ScrollView>
    );
  }
}


const styles = StyleSheet.create({
  item: {
    padding: 5,
    fontSize: 16,
    height: 32
  },
  iteme: {
    padding: 5,
    marginTop: 5,
    marginLeft: 10,
    fontSize: 17,
    height: 50
  },
});
