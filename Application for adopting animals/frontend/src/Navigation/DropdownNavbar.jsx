import React, { Component } from 'react'
import axios from 'axios'
import DatePicker from "react-datepicker";
import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';
import "react-datepicker/dist/react-datepicker.css";
import { Link } from "react-router-dom"



class DropNav extends Component {

    render() {
        return (
            <nav className="navbar">
                <ul>
                    <li class="dropdown">
                        <Link to="/vjestine">
                            <li class="dropbtn">Vještine</li>
                        </Link>
                        <div class="dropdown-content">
                            <Link to="/tipovi-vjestina">
                                <li>Tipovi vještina</li>
                            </Link>
                        </div>
                    </li>
                    <li class="dropdown">
                        <Link to="/edukacije">
                            <li class="dropbtn">Edukacije</li>
                        </Link>
                        <div class="dropdown-content">
                            <Link to="/tipovi-edukacija">
                                <li>Tipovi edukacija</li>
                            </Link>
                        </div>
                    </li>
                </ul>
            </nav >
        )
    }
}

export default DropNav