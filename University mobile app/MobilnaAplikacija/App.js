import React, { Component } from 'react';
import { View, Image, TouchableOpacity, Text, StyleSheet } from 'react-native';

import {
  createDrawerNavigator,
  createStackNavigator,
  createAppContainer,
} from 'react-navigation';

import Screen1 from './November/Dashboard';
import Screen2 from './November/Student';
import Screen3 from './November/Izvjestaji';
import Screen4 from './India/Ispiti';
import Screen5 from './India/Potvrde';
import Screen6 from './India/Raspored';
import Screen7 from  './November/login';
import Zavrsni from './November/Zavrsni';
import Screen8 from  './November/SortiranjeGodina';
import Predmet from './November/Predmet/Predmet';
import Izvjestaj from './November/SviIzvjestaji/Izvjestaj';
import screen9 from './changelog';
import odslusaniPredmeti from './November/odslusaniPredmeti';
import screenLogin from './November/login2';

/*
export default class App extends React.Component {
  render() {
    return (
      <View style={styles.container}>
        <AktivniIspiti></AktivniIspiti>
   </View>
      <View>
        <Screen1/>
      </View>
    );
  }
}
*/

class NavigationDrawerStructure extends Component {
  toggleDrawer = () => {
    this.props.navigationProps.toggleDrawer();
  };

 

  render() {

    return (
      <>
        <View style={{ flexDirection: 'row' }}>
          <TouchableOpacity onPress={this.toggleDrawer.bind(this)}>
            {}
            <Image
              source={require('./image/drawer.png')}
              style={{ width: 25, height: 25, marginLeft: 5 }}
            />
          </TouchableOpacity>
        </View>
      </>
    ); 
  }
}


const FirstActivity_StackNavigator = createStackNavigator({
  First: {
    screen: Screen1,
    navigationOptions: ({ navigation }) => ({
      title: 'Dashboard',
      headerLeft: <NavigationDrawerStructure navigationProps={navigation} />,
      headerStyle: {
        backgroundColor: '#376ff2',
      },
      headerTintColor: '#fff',
    }),
  },
  Zavrsni: {
    screen : Zavrsni,
    navigationOptions: ({ navigation }) => ({
      title: 'Završni rad',
      headerStyle: {
        backgroundColor: '#376ff2',
      },
      headerTintColor: '#fff',
    }),
  },
  Predmet: {
    screen: Predmet,

  },
  odslusaniPredmeti: {
    screen: odslusaniPredmeti,
    navigationOptions: ({ navigation }) => ({
      title: 'Odslušani predmeti',
      headerStyle: {
        backgroundColor: '#376ff2',
      },
      headerTintColor: '#fff',
    }),
  },
});


const Screen2_StackNavigator = createStackNavigator({
  Second: {
    screen: Screen2,
    navigationOptions: ({ navigation }) => ({
      title: 'Student',
      headerLeft: <NavigationDrawerStructure navigationProps={navigation} />,

      headerStyle: {
        backgroundColor: '#376ff2',
      },
      headerTintColor: '#fff',
    }),
  },
});


const Screen3_StackNavigator = createStackNavigator({
  First: {
    screen: Screen3,
    navigationOptions: ({ navigation }) => ({
      title: 'Izvještaji',
      headerLeft: <NavigationDrawerStructure navigationProps={navigation} />,
      headerStyle: {
        backgroundColor: '#376ff2',
      },
      headerTintColor: '#fff',
    }),
  },
  Izvjestaj: {
    screen: Izvjestaj
  }
});


const Screen4_StackNavigator = createStackNavigator({
  Third: {
    screen: Screen4,
    navigationOptions: ({ navigation }) => ({
      title: 'Ispiti',
      headerLeft: <NavigationDrawerStructure navigationProps={navigation} />,
      headerStyle: {
        backgroundColor: '#376ff2',
      },
      headerTintColor: '#fff',
    }),
  },
});


const Screen5_StackNavigator = createStackNavigator({
  Third: {
    screen: Screen5,
    navigationOptions: ({ navigation }) => ({
      title: 'Potvrde',
      headerLeft: <NavigationDrawerStructure navigationProps={navigation} />,
      headerStyle: {
        backgroundColor: '#376ff2',
      },
      headerTintColor: '#fff',
    }),
  },
});


const Screen6_StackNavigator = createStackNavigator({
  Third: {
    screen: Screen6,
    navigationOptions: ({ navigation }) => ({
      title: 'Raspored',
      headerLeft: <NavigationDrawerStructure navigationProps={navigation} />,
      headerStyle: {
        backgroundColor: '#376ff2',
      },
      headerTintColor: '#fff',
    }),
  },
});

const Screen8_StackNavigator = createStackNavigator({
  Third: {
    screen: Screen8,
    navigationOptions: ({ navigation }) => ({
      title: 'Prosjeci',
      headerLeft: <NavigationDrawerStructure navigationProps={navigation} />,
      headerStyle: {
        backgroundColor: '#376ff2',
      },
      headerTintColor: '#fff',
    }),
  },
});

const Screen9_StackNavigator = createStackNavigator({
  Third: {
    screen: screen9,
    navigationOptions: ({ navigation }) => ({
      title: 'Changelog',
      headerLeft: <NavigationDrawerStructure navigationProps={navigation} />,
      headerStyle: {
        backgroundColor: '#376ff2',
      },
      headerTintColor: '#fff',
    }),
  },
});

const loginNavigator = createStackNavigator({
  login: {
    screen: screenLogin,
    navigationOptions: ({ navigation }) => ({
      title: '',
      headerStyle: {
        backgroundColor: '#376ff2',
      },
      headerTintColor: '#fff',
    }),
  },
});


const DrawerNavigatorExample = createDrawerNavigator({
  //Drawer Optons and indexing
   
  loginScreen: {
    screen: loginNavigator,
    navigationOptions: {
      drawerLabel: 'Prijava/odjava',
    },
  },

  Screen1: {
    screen: FirstActivity_StackNavigator,
    navigationOptions: {
      drawerLabel: 'Dashboard',
    },
  },

  Screen2: {
    screen: Screen2_StackNavigator,
    navigationOptions: {
      drawerLabel: 'Student',
    },
  },

  Screen3: {
    screen: Screen3_StackNavigator,
    navigationOptions: {
      drawerLabel: 'Izvještaji',
    },
  },

  Screen4: {
    screen: Screen4_StackNavigator,
    navigationOptions: {
      drawerLabel: 'Ispiti',
    },
  },

  Screen5: {
    screen: Screen5_StackNavigator,
    navigationOptions: {
      drawerLabel: 'Potvrde',
    },
  },

  Screen6: {
    screen: Screen6_StackNavigator,
    navigationOptions: {
      drawerLabel: 'Raspored',
    },
  },
  Screen8: {
    screen: Screen8_StackNavigator,
    navigationOptions: {
      drawerLabel: 'Prosjeci',
    },
  },
  Screen9: {
    screen: Screen9_StackNavigator,
    navigationOptions: {
      drawerLabel: 'Changelog',
    },
  },
  
});

export default createAppContainer(DrawerNavigatorExample);
