import React, {Component} from 'react';
import Paper from '@material-ui/core/Paper';
import { makeStyles } from '@material-ui/core/styles';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import PhoneIcon from '@material-ui/icons/Phone';
import FavoriteIcon from '@material-ui/icons/Favorite';
import PersonPinIcon from '@material-ui/icons/PersonPin';
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';
import Homepage from "./components/Homepage"
import Navbar from "./components/Navbar"
import Home from './components/pages/Home';

const useStyles = makeStyles({
  root: {
    flexGrow: 1,
    maxWidth: 500,
  },
});



class App extends Component {
  render() {
    return (
      <>
      <Router>
      <Navbar/>
      <Switch>
      <Route path='/' exact component={Home} />
      </Switch>
      </Router>
      </>
      /*<div>
        <Navbar/>
        <Homepage />
        
      </div>*/
    );
  }
}


export default App;
