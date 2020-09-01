import React, { Component } from 'react'
import avatar from "./avatar.png"
import "./style.scss";
import axios from 'axios'
import { toast } from 'react-toastify';
import { Link } from "react-router-dom"
import LocalStorageService from "../LocalStorage.js";

export class UserProfile extends Component {
    constructor(props) {
        super(props)
        this.state = {
            userId: '',
            userData: {},
            fullName: '',
            dateOfBirth: '',
            email: '',
            address: '',
            jmbg: '',
            gender: '',
        }
    }

    componentDidMount() {
        //procitat id
        const localStorageService = LocalStorageService.getService();
        const token = localStorageService.getAccessToken()
        const userId = localStorageService.getUserId()
        console.log(token);
        
        axios.get(`http://localhost:8084/korisnik/korisnik/${userId}`, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        }).then(
            res => {
                const userData = res.data;
                this.setState({ userData })
            }
        ).catch(err => {
            if (err.response.data.errors != undefined) {
                toast.error(err.response.data.message.toString(), { position: toast.POSITION.TOP_RIGHT })
            }
        })
    }

    obrisiProfil = (event) => {
        const localStorageService = LocalStorageService.getService();
        const token = localStorageService.getAccessToken()
        const userId = localStorageService.getUserId()
        console.log(token);
        
        axios.delete(`http://localhost:8084/korisnik/korisnik/${userId}`, {
            headers: {
                'Authorization': `Bearer ${token}`
            }
        }).then(
            res => {
                if(res.status == 200) {
                    this.props.history.push('/')
                    toast.success('Uspjesno obrisan profil', { position: toast.POSITION.TOP_RIGHT })
                }
            }
        ).catch(err => {
            if (err.response.data.errors != undefined) {
                toast.error(err.response.data.message.toString(), { position: toast.POSITION.TOP_RIGHT })
            }
        })
    }

    render() {
        return (
            <div className="parentProfile">
                <img src={avatar} />
                <div className="desnoDiv">
                    <Link to="/resetPassword">
                        <li className="linkProfile">Promijeni sifru</li>
                    </Link>
                    <button
                        className="loginButton"
                        onClick={e => this.obrisiProfil(e)}
                        type="submit"> Obrisi profil
                        </button>
                </div>
                <div className="backgrDiv">
                    <div className="profileWrapper">


                        <div className="profileDiv">
                            <div className="userProfileLabelGroup">
                                <label><b>Ime i prezime:</b></label>
                                <label>{this.state.userData.fullName}</label>
                            </div>
                            <div className="userProfileLabelGroup">
                                <label><b>Datum rodjenja:</b></label>
                                <label>{this.state.userData.dateOfBirth}</label>
                            </div>
                            <div className="userProfileLabelGroup">
                                <label><b>Email:</b></label>
                                <label>{this.state.userData.email}</label>
                            </div>
                            <div className="userProfileLabelGroup">
                                <label><b>Username:</b></label>
                                <label>{this.state.userData.username}</label>
                            </div>
                            <div className="userProfileLabelGroup">
                                <label><b>Adresa:</b></label>
                                <label>{this.state.userData.address}</label>
                            </div>
                            <div className="userProfileLabelGroup">
                                <label><b>JMBG:</b></label>
                                <label>{this.state.userData.jmbg}</label>
                            </div>
                            <div className="userProfileLabelGroup">
                                <label><b>Spol:</b></label>
                                <label>Musko</label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        )
    }
}