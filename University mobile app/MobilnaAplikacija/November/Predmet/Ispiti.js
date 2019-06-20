import React from "react";
import { View, Text } from "react-native";
import Ispit from "./Ispit";
const Ispiti = (props) => {
  return (
    <View>
      <Text style={{fontWeight: 'bold'}}>Ispiti: </Text>
      {props.ispiti.map((ispit, index) => {
        return <Ispit key={index} ispit={ispit} />;
      })}
    </View>
  );
};

export default Ispiti;
