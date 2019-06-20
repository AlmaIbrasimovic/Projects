import React from "react";
import { View, Text } from "react-native";
import Zadaca from "./Zadaca";
const Zadace = (props) => {
    return (
        <View>
            <Text style={{fontWeight: 'bold'}}>Zadaće: </Text>
            {props.zadace.map((zadaca, index) => {
                return <Zadaca key={index} zadaca={zadaca} />;
            })}
        </View>
    );
};

export default Zadace;
