import React from "react";
import { withRouter, Redirect } from 'react-router-dom';
import KorisnikNavbar from '../Navigation/KorisnikNavbar'
import { BrowserRouter as Router, Route, Switch } from "react-router-dom"
import { Zivotinje } from "../Zivotinje/index"
import {UserProfile} from "../Korisnik/UserProfile"
import {Register} from "../Korisnik/Register"
import {ResetPassword} from "../Korisnik/ResetPassword"
import './style.scss'; 

export class Korisnik extends React.Component {
    render() {
        return (
            <Router>
                <div>
                    <KorisnikNavbar />
                    <Route path="/korisnik/zivotinje" component={Zivotinje} />
                    <Route path="/korisnik/userProfile" component={UserProfile}/>
                    <Route path="/register" component={Register}/>
                    <Route path="/resetPassword" component={ResetPassword}/>
                    <Route path="/popuni-anketu" component={Register}/>
                    <a className = "odjavaLink" href="/">Odjava</a>
                </div>
            </Router>
        )
    }
}
