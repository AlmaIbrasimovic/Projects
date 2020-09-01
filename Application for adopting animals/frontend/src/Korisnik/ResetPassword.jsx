import React, { Component } from 'react'
import "./style.scss";
import axios from 'axios'
import { toast } from 'react-toastify';
import LocalStorageService from "../LocalStorage.js";

export class ResetPassword extends Component {
    constructor(props) {
        super(props)
        this.state = {
            userId: '',
            newPassword: '',
            password: '',
            errors: {
                newPassword: '',
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
            case 'newPassword':
                errors.newPassword = value.length < 8
                    ? 'Sifra mora imati najmanje 8 karaktera!'
                    : '';
                break;
            case 'password':
                errors.password =
                    value != this.state.newPassword
                        ? 'Sifra nije ista kao unesena!'
                        : '';
                break;
            default:
                break;
        }

        this.setState({ errors, [name]: value }, () => {
            console.log(errors)
        })
    }

    resetPassword = (event) => {
        event.preventDefault();
        const localStorageService = LocalStorageService.getService();
        if (!this.validateForm(this.state.errors)) alert("Unesite vrijednosti")
        else {
            const token = localStorageService.getAccessToken()
            const userId = localStorageService.getUserId()
            axios.put('http://localhost:8084/korisnik/korisnik/sifra', {
                id: userId,
                password: this.state.password
            }, {
                headers: {
                    'Authorization': `Bearer ${token}`
                }
            }).then(response => {
                if (response.status === 200) {
                    toast.success('Uspjesno promijenjena sifra', { position: toast.POSITION.TOP_RIGHT })
                    this.props.history.push('/korisnik/userProfile')
                }
            }).catch(err => {
                toast.error(err.response.data.message.toString(), { position: toast.POSITION.TOP_RIGHT })
            })
        }
    }

    render() {
        const { errors } = this.state
        return (
            <div className="userDiv">
                <form className="loginForma">
                    <label></label>
                    <div className="inputGroup">
                        <input
                            className="loginInput"
                            type="password"
                            onChange={e => this.handleChange(e)}
                            placeholder="Nova sifra"
                            name="newPassword" />
                        {errors.newPassword.length > 0 &&
                            <span className='error'>{errors.newPassword}</span>}
                    </div>
                    <div className="inputGroup">
                        <input
                            className="loginInput"
                            type="password"
                            onChange={e => this.handleChange(e)}
                            placeholder="Ponovo unesite sifru"
                            name="password" />
                        {errors.password.length > 0 &&
                            <span className='error'>{errors.password}</span>}
                    </div>
                    <button
                        className="loginButton"
                        onClick={e => this.resetPassword(e)}
                        type="submit"> Promijeni sifru
                        </button>
                </form>
            </div>
        )
    }
}