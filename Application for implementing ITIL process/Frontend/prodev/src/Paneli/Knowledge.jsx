import React from "react";
import { withRouter, Redirect } from 'react-router-dom';

import { Login, Register } from "../Login/index";
import { Vjestine } from "../Vjestine/index";
import { Tipovi } from "../TipoviVjestina/index";
import { TipoviEdukacija } from "../TipoviEdukacija/index"
import { Edukacije } from "../Edukacije/index"
import { Uposlenici } from "../Uposlenici/index"
import { KnowledgeNavbar } from "../Navigation/index"
import { Certifikati } from "../Certifikati/index"
import { BrowserRouter as Router, Route, Switch } from "react-router-dom"
import { DodavanjeVjestine } from "../DodavanjeVjestine/index"
import DodavanjeEdukacije from '../DodavanjeEdukacije/DodavanjeEdukacije'
import './style.scss';

class Knowledge extends React.Component {
    render() {
        return (
            <Router>
                <div>
                    <KnowledgeNavbar />
                    <Route path="/knowledge/tipovi-vjestina" component={Tipovi} />
                    <Route path="/knowledge/vjestine" component={Vjestine} />
                    <Route path="/knowledge/dodavanje-vjestine" component={DodavanjeVjestine} />
                    <Route path="/knowledge/tipovi-edukacija" component={TipoviEdukacija} />
                    <Route path="/knowledge/edukacije" component={Edukacije} />
                    <Route path="/knowledge/dodavanje-edukacije" component={DodavanjeEdukacije} />
                    <Route path="/knowledge/certifikati" component={Certifikati} />
                    <Route path="/knowledge/uposlenici" component={Uposlenici} />
                    <Route path="/" exact component={Login} />
                </div>
                <a href="/" className="odjavaLink">Odjava</a>
            </Router>
        )
    }
}

export default Knowledge