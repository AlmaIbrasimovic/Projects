import React, {Component} from 'react';
import Paper from '@material-ui/core/Paper';
import {makeStyles} from '@material-ui/core/styles';
import Tabs from '@material-ui/core/Tabs';
import Tab from '@material-ui/core/Tab';
import PhoneIcon from '@material-ui/icons/Phone';
import FavoriteIcon from '@material-ui/icons/Favorite';
import PersonPinIcon from '@material-ui/icons/PersonPin';
import {BrowserRouter as Router, Switch, Route} from 'react-router-dom';
import Homepage from "./components/Homepage"
import Navbar from "./components/Navbar"
import Home from './components/pages/Home';
import SignIn from './components/pages/Signin';
import SignUp from './components/pages/Signup';
import './App.css'
import UserProfile from '././components/pages/UserProfile'
import Test from '././components/pages/Test'
import CreateRecipe from '././components/pages/CreateRecipe'
function App() {
    return (
        <Router>
            <Navbar/>
            <Switch>
                <Route path='/' exact component={Home}/>
                <Route path='/sign-in' component={SignIn}/>
                <Route path='/sign-up' component={SignUp}/>
                <Route exact path="/user-profile" component = {UserProfile}/>
                <Route exact path="/create-recipe" component = {CreateRecipe}/>
            </Switch>
        </Router>

    );
}


export default App;
/*   <Route path='/user-profile' component={UserProfile}/>*/