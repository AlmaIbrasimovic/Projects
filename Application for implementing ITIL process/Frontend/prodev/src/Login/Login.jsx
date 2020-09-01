import React from "react";
import loginSlika from "../logo.png";
import { withRouter, Redirect } from 'react-router-dom';
import { browserHistory } from 'react-router';
import { TipoviEdukacija } from "../TipoviEdukacija/TipoviEdukacija.jsx"
import axios from 'axios'

export class Login extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            username: '',
            password: ''
        };
    }

    handleChange = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    login = () => {
        if (this.state.username === '' && this.state.password === '') alert('Molimo unesite vaše korisničke podatke!');
        else if (this.state.username === '') alert('Molimo unesite vaše korisničko ime!');
        else if (this.state.password === '') alert('Molimo unesite vašu lozinku!');
        else {
            axios.post('http://localhost:8083/user/login', {
                password: this.state.password,
                username: this.state.username
            }).then(res => {

                if (this.state.username == "admin") {
                    this.props.history.push('/admin')
                }
                else if (this.state.username == "hrmanager") {
                    this.props.history.push('/knowledge')
                }
                else if (this.state.username == "supmanager") {
                    this.props.history.push('/suplier')
                }
            })
                .catch(err => {
                    alert(err.response.data.message)
                })
        }
    }

    render() {
        return (<div className="base-container" ref={this.props.containerRef}>
            <div className="stil">Prijava na račun</div>
            <div className="content">
                <div className="image">
                    <img src={loginSlika} />
                </div>
                <div className="form">
                    <div className="form-group">
                        <label htmlFor="username">Korisničko ime</label>
                        <input type="text" name="username"
                            value={this.state.username}
                            onChange={e => this.handleChange(e)}
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="password">Lozinka</label>
                        <input type="password" name="password"
                            value={this.state.password}
                            onChange={e => this.handleChange(e)}
                        />
                    </div>
                </div>
            </div>
            <div className="footer">
                <button type="button" className="btnLogin" onClick={this.login}>
                    Login
                </button>
            </div>
        </div>
        );
    }
}

