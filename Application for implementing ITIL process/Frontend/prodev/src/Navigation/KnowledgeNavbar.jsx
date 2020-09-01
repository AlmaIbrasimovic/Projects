import React, { Component } from 'react'
import axios from 'axios'
import DatePicker from "react-datepicker";
import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';
import "react-datepicker/dist/react-datepicker.css";
import { Link } from "react-router-dom"



export class KnowledgeNavbar extends Component {



    render() {
        return (
            <nav className="navbar">
                <ul>
                    <Link to="/knowledge/tipovi-vjestina">
                        <li>Tipovi vještina</li>
                    </Link>
                    <Link to="/knowledge/vjestine">
                        <li>Vještine</li>
                    </Link>
                    <Link to="/knowledge/dodavanje-vjestine">
                        <li>Dodavanje vještine</li>
                    </Link>
                    <Link to="/knowledge/tipovi-edukacija">
                        <li>Tipovi edukacija</li>
                    </Link>
                    <Link to="/knowledge/edukacije">
                        <li>Edukacije</li>
                    </Link>
                    <Link to="/knowledge/dodavanje-edukacije">
                        <li>Dodavanje Edukacije</li>
                    </Link>
                    <Link to="/knowledge/certifikati">
                        <li>Certifikati</li>
                    </Link>
                    <Link to="/knowledge/uposlenici">
                        <li>Uposlenici</li>
                    </Link>
                </ul>
            </nav>
        )
    }
}