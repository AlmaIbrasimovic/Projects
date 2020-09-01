import React, { Component } from 'react'
import axios from 'axios'
import DatePicker from "react-datepicker";
import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';
import "react-datepicker/dist/react-datepicker.css";
import { Link } from "react-router-dom"
import { withRouter, Redirect } from 'react-router-dom';
import { browserHistory } from 'react-router';



class KorisnikNavbar extends React.Component {

    render() {
        return (
            <nav className="navbar">
                <ul>
                    <Link to="/korisnik/zivotinje">
                        <li>Životinje</li>
                    </Link>
                    <Link to="/korisnik/userProfile">
                        <li>Profil</li>
                    </Link>
                </ul>
            </nav>
        )
    }
}

export default KorisnikNavbar