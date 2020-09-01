import React, { Component } from 'react'
import 'react-dropdown/style.css';
import "react-datepicker/dist/react-datepicker.css";
import { Link } from "react-router-dom"

 export class AdminNavbar extends React.Component {
    render() {
        return (
            <nav className="navbar">
                <ul>
                    <Link to="/admin/zivotinje">
                        <li>Životinje</li>
                    </Link>
                    <Link to="/admin/kreiraj-zivotinju">
                        <li>Kreiraj životinju</li>
                    </Link>
                    <Link to="/admin/kreiraj-vakcinu">
                        <li>Kreiraj vakcinu</li>
                    </Link>
                    <Link to="/admin/kreiraj-veterinara">
                        <li>Kreiraj veterinara</li>
                    </Link>
                    <Link to="/admin/kreiraj-bolest">
                        <li>Kreiraj bolest</li>
                    </Link>
                    <Link to="/admin/kreiraj-anketu">
                         <li>Kreiraj anketu</li>
                    </Link>
                </ul>
            </nav>
        )
    }
}
