import React, { Component } from 'react'
import loginSlika from "./login.png"
import "./style.scss";
import axios from 'axios'
import { toast } from 'react-toastify';
import { Link, useHistory } from "react-router-dom"
import LocalStorageService from "../LocalStorage.js";

export class Login extends Component {
    constructor(props) {
        super(props)
        this.state = {
            username: '',
            password: '',
            role: '',
            token: '',
            errors: {
                username: '',
                password: ''
            }
        }
    }

    validateForm = (errors) => {
        let valid = true;
        Object.values(errors).forEach(
            // if we have an error string set valid to false
            (val) => val.length > 0 && (valid = false)
        );
        return valid;
    }

    handleChange = (event) => {
        event.preventDefault();
        const { name, value } = event.target;
        let errors = this.state.errors;

        switch (name) {
            case 'username':
                errors.username =
                    value.length > 5 
                        ? ''
                        : 'Username je prekratak, mora imati najmanje 5 karaktera';
                break;
            case 'password':
                errors.password =
                    value.length < 8
                        ? 'Sifra mora imati najmanje 8 karaktera!'
                        : '';
                break;
            default:
                break;
        }

        this.setState({ errors, [name]: value }, () => {
            console.log(errors)
        })
    }

    userLogin = (event) => {
        event.preventDefault();
        const localStorageService = LocalStorageService.getService();
        if (!this.validateForm(this.state.errors)) alert("Unesite vrijednosti")
        else {
            axios.post('http://localhost:8084/korisnik/authenticate', {
                username: this.state.username,
                password: this.state.password,

            }).then(response => {
                if (response.status === 200) {
                    localStorageService.setToken(response.data)
                    if (response.data.role === "administrator") {
                        this.props.history.push('/admin')
                    }
                    else if (response.data.role === "korisnik") {
                        this.props.history.push('/korisnik')
                    }
                    this.state.token = response.data.token
                    toast.success('Uspjesna prijava na sistem', { position: toast.POSITION.TOP_RIGHT })
                }
            }).catch(err => {
                if (err.response.data.message != null) {
                    toast.error(err.response.data.message.toString(), { position: toast.POSITION.TOP_RIGHT })
                }
                else {
                    toast.error('Ne postoji korisnik', { position: toast.POSITION.TOP_RIGHT })
                 
                } })
        }
    }

    render() {
        const { errors } = this.state
        return (
            <div className="userDiv">
                <form className="loginForma">
                    <label>Prijavi se</label>
                    <div className="inputGroup">
                        <input
                            className="loginInput"
                            type="text"
                            onChange={e => this.handleChange(e)}
                            placeholder="Username"
                            name="username" />
                        {errors.username.length > 0 &&
                            <span className='error'>{errors.username}</span>}
                    </div>
                    <div className="inputGroup">
                        <input
                            className="loginInput"
                            type="password"
                            onChange={e => this.handleChange(e)}
                            placeholder="Sifra"
                            name="password" />
                        {errors.password.length > 0 &&
                            <span className='error'>{errors.password}</span>}
                    </div>
                    <button
                        className="loginButton"
                        onClick={e => this.userLogin(e)}
                        type="submit"> Prijava
                        </button>
                </form>
                <div className="goToRegisterDiv">
                    <label>Nemate racun?</label>
                    <Link className="linkRegister" to="/register">
                        <li>Registruj se</li>
                    </Link>
                </div>
                <img
                    className="loginImg"
                    src={loginSlika}
                    alt="slika" />
            </div>
        )
    }
}