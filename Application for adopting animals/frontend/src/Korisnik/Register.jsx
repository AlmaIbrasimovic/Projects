import React, { Component } from 'react'
import loginSlika from "./login.png"
import "./style.scss";
import { toast } from 'react-toastify';
import axios from 'axios'

export class Register extends Component {
    constructor(props) {
        super(props)
        this.state = {
            uloge: [],
            spol: [
                { value: 'M', label: 'Muško' },
                { value: 'Z', label: 'Žensko' }
            ],
            fullName: '',
            dateOfBirth: '',
            email: '',
            username: '',
            password: '',
            address: '',
            jmbg: '',
            gender: 'M',
            role: {
                "id": 1,
                "roleName": "administrator"
            },
            errors: {
                fullName: '',
                email: '',
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

    componentDidMount() {
        axios.get('http://localhost:8084/korisnik/uloga/lista').then(
            res => {
                const uloge = res.data
                this.setState({ uloge })
                console.log(uloge);

            }
        ).catch(err => {
            toast.error(err.response.data.message.toString(), { position: toast.POSITION.TOP_RIGHT })
        })
    }

    handleChangeSpol = (selectedOption) => {
        if (selectedOption) {
            this.setState({ gender: selectedOption.target.value });
        }
    }

    handleChangeUloga = (selectedOption) => {
        if (selectedOption) {
            const arrayelemnt = this.state.uloge.filter(function (item) {
                return item.id == selectedOption.target.value;
            })
            this.setState({
                role: arrayelemnt[0]
            });
            console.log(this.state.role);
        }
    }

    handleChange = (event) => {
        const validEmailRegex =
            RegExp(/^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i);
        event.preventDefault();
        const { name, value } = event.target;
        let errors = this.state.errors;

        switch (name) {
            case 'fullName':
                errors.fullName =
                    value.length < 5
                        ? 'Ime i prezime mora imati vise od 5 slova!'
                        : '';
                break;
            case 'username':
                errors.username =
                    value.length > 5
                        ? ''
                        : 'Username je prekratak, mora imati najmanje 5 karaktera';
                break;
            case 'email':
                errors.email =
                    validEmailRegex.test(value)
                        ? ''
                        : 'Email format nije validan!';
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
        if (!this.validateForm(this.state.errors)) toast.error("Unesite vrijednosti", { position: toast.POSITION.TOP_RIGHT })
        else {
            axios.post('http://localhost:8084/korisnik/oauth/korisnik', {
                fullName: this.state.fullName,
                dateOfBirth: this.state.dateOfBirth,
                email: this.state.email,
                password: this.state.password,
                address: this.state.address,
                username: this.state.username,
                jmbg: this.state.jmbg,
                gender: this.state.gender,
                role: this.state.role
            }).then(response => {
                if (response.status === 200 || response.status === 201) {
                    this.props.history.push('/')
                    toast.success('Uspješno kreiran racun', { position: toast.POSITION.TOP_RIGHT })
                }
            }).catch(err => {
                console.log(err.response.data.message.toString())
                toast.error(err.response.data.message.toString(), { position: toast.POSITION.TOP_RIGHT })
            })
        }
    }

    render() {
        const { errors } = this.state
        return (
            <div className="userDiv">
                <form className="registerForma">
                    <label>Registruj se</label>
                    <div className="inputGroup">
                        <input
                            className="loginInput"
                            type="text"
                            onChange={e => this.handleChange(e)}
                            placeholder="Ime i prezime"
                            name="fullName" />
                        {errors.email.length > 0 &&
                            <span className='error'>{errors.fullName}</span>}
                    </div>
                    <div className="inputGroup">
                        <input
                            className="loginInput"
                            type="date"
                            onChange={e => this.handleChange(e)}
                            placeholder="Datum rodjenja"
                            name="dateOfBirth" />
                    </div>
                    <div className="inputGroup">
                        <input
                            className="loginInput"
                            type="email"
                            onChange={e => this.handleChange(e)}
                            placeholder="Email"
                            name="email" />
                        {errors.email.length > 0 &&
                            <span className='error'>{errors.email}</span>}
                    </div>
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
                    <div className="inputGroup">
                        <input
                            className="loginInput"
                            type="text"
                            onChange={e => this.handleChange(e)}
                            placeholder="Adresa"
                            name="address" />
                        {errors.password.length > 0 &&
                            <span className='error'>{errors.address}</span>}
                    </div>
                    <div className="inputGroup">
                        <input
                            className="loginInput"
                            type="text"
                            onChange={e => this.handleChange(e)}
                            placeholder="JMBG"
                            name="jmbg" />
                        {errors.password.length > 0 &&
                            <span className='error'>{errors.jmbg}</span>}
                    </div>
                    <div className="selectWrapper">
                        <select className="selectBox"
                            onChange={(e) => {
                                this.handleChangeSpol(e);
                            }}
                            value={this.state.gender}
                            name="gender">
                            {this.state.spol.map(spol => <option key={spol.value} value={spol.value}>{spol.label}</option>)}
                        </select>
                    </div>
                    <div className="selectWrapper">
                        <select className="selectBox"
                            onChange={(e) => {
                                this.handleChangeUloga(e);
                            }}
                            value={this.state.role}
                            name="role">
                            {this.state.uloge.map(uloga => <option key={uloga.id} value={uloga.id}>{uloga.roleName}</option>)}
                        </select>
                    </div>
                    <button
                        className="loginButton"
                        onClick={e => this.userLogin(e)}
                        type="submit"> Registruj</button>
                </form>
            </div>
        )
    }
}