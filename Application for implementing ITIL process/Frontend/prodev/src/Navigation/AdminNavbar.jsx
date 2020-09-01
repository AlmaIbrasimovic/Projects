import React, { Component } from 'react'
import axios from 'axios'
import DatePicker from "react-datepicker";
import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';
import "react-datepicker/dist/react-datepicker.css";
import { Link } from "react-router-dom"



class AdminNavbar extends React.Component {
    constructor(props) {
        super(props);
    }
    render() {
        return (
            <nav className="navbar">
                <ul>
                    <Link to="/admin/korisnici">
                        <li>Korisnici</li>
                    </Link>
                    <Link to="/admin/uposlenici">
                        <li>Uposlenici</li>
                    </Link>
                    <Link to="/admin/dobavljaci">
                        <li>Dobavljači</li>
                    </Link>
                    <Link to="/admin/ugovori">
                        <li>Ugovori</li>
                    </Link>
                </ul>
            </nav>
        )
    }
}

export default AdminNavbar