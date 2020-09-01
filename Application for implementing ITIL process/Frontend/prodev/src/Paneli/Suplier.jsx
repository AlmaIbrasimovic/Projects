import React from "react";
import { withRouter, Redirect } from 'react-router-dom';

import { Login, Register } from "../Login/index";
import SuplierNavbar from '../Navigation/SuplierNavbar'
import { Dobavljaci } from "../Dobavljaci/index"
import { Ugovori } from "../Ugovori/index"
import { BrowserRouter as Router, Route, Switch } from "react-router-dom"
import { Ocjene } from "../Ocjene/index"
import { Kriteriji } from "../Kriteriji/index"
import './style.scss'; 

class Suplier extends React.Component {
    render() {
        return (
            <Router>
                <div>
                    <SuplierNavbar />
                    <Route path="/suplier/dobavljaci" component={Dobavljaci} />
                    <Route path="/suplier/ugovori" component={Ugovori} />
                    <Route path="/suplier/ocjene" component={Ocjene} />
                    <Route path="/suplier/kriteriji" component={Kriteriji} />
                    <Route path="/" exact component={Login} />
                    <a className = "odjavaLink" href="/">Odjava</a>
                </div>
            </Router>
        )
    }
}

export default Suplier