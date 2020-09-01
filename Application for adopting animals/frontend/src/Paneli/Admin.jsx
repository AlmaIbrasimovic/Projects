import React from "react";
import { withRouter, Redirect } from 'react-router-dom';
import {AdminNavbar} from '../Navigation/AdminNavbar'
import { BrowserRouter as Router, Route, Switch } from "react-router-dom"
import { Zivotinje, KreirajZivotinju } from '../Zivotinje/index'
import { KreirajVakcinu } from '../Vakcine/index'
import { KreirajVeterinara } from '../Veterinari/index'
import {Register} from "../Korisnik/Register"
import { KreirajBolest } from '../Bolesti/index'
import CreateSurvey from '../Anketa/CreateSurvey';
import './style.scss';

export class Admin extends React.Component {
    render() {
        return (
            <Router>
                <div>
                    <AdminNavbar />
                    <Route path="/admin/zivotinje" component={Zivotinje} />
                    <Route path="/admin/kreiraj-zivotinju" component={KreirajZivotinju} />
                    <Route path="/admin/kreiraj-vakcinu" component={KreirajVakcinu} />
                    <Route path="/admin/kreiraj-veterinara" component={KreirajVeterinara} />
                    <Route path="/admin/kreiraj-bolest" component={KreirajBolest} />
                    <Route path="/admin/kreiraj-anketu" component={CreateSurvey}/>
                    <a className = "odjavaLink" href="/">Odjava</a>
                </div>
            </Router>
        )
    }
}