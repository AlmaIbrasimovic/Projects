import React, {Component} from 'react'
import Test from './Test'
import Dashboard from '../Dashboard';
import Navbar from '../Navbar'

export default class UserProfile extends Component {
    render() {
        return (
            <Dashboard
                info = {this.props.location.state.firstName + " " + this.props.location.state.lastName}
            />
            
        );
    }
}