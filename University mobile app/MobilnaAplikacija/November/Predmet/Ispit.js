import React from 'react'
import {View,Text} from 'react-native';

const Ispit = (props) => {
  //  console.log(props.ispit);
    const {naziv,datum,bodovi}=props.ispit;
  return (
    <Text>{naziv}({datum}): {bodovi} bodova</Text>
  )
}

export default Ispit;