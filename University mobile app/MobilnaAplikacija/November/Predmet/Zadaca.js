import React from 'react'
import {Text} from 'react-native';

const Zadaca = (props) => {
    const {naziv,bodovi}=props.zadaca;
    return (
        <Text>{naziv} : {bodovi} bodova</Text>
    )
}

export default Zadaca;