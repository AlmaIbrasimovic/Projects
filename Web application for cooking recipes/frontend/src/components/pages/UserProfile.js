import React, {Component} from 'react'
import Test from './Test'
import Dashboard from '../Dashboard';
import Navbar from '../Navbar'
import {Link} from 'react-router-dom'
export default class UserProfile extends Component {
    render() {
        return (
            <Dashboard
                info = {this.props.location.state.firstName + " " + this.props.location.state.lastName}
                id = {this.props.location.state.id}
            />
            
        );
    }
}