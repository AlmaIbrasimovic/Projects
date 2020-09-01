import React, { Component } from 'react'
import axios from 'axios'
import DatePicker from "react-datepicker";
import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';
import "react-datepicker/dist/react-datepicker.css";
import { Link } from "react-router-dom"
import { withRouter, Redirect } from 'react-router-dom';
import { browserHistory } from 'react-router';



class SuplierNavbar extends React.Component {

    render() {
        return (
            <nav className="navbar">
                <ul>
                    <Link to="/suplier/dobavljaci">
                        <li>Dobavljači</li>
                    </Link>
                    <Link to="/suplier/ugovori">
                        <li>Ugovori</li>
                    </Link>
                    <Link to="/suplier/ocjene">
                        <li>Ocjene</li>
                    </Link>
                    <Link to="/suplier/kriteriji">
                        <li>Kriteriji</li>
                    </Link>
                </ul>
            </nav>
        )
    }
}

export default SuplierNavbar