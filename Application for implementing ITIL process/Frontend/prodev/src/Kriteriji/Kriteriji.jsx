import React, { Component } from 'react'
import axios from 'axios'
import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

export class Kriteriji extends Component {
    constructor(props) {
        super(props)
        this.state = {
            Kriterij: [
                { Kriterij: "", Koeficijent: "", obrisati: false },
            ],
            kriteriji: [], // Za popunjavanje tipova vjestina
            id: '',
            name: '',
            coeficient: ''
        };
    }

    componentWillMount() {

        axios.get('http://localhost:8083/criteria')
            .then(res => {
                var temp = [];
                for (var i = 0; i < res.data.length; i++) {
                    temp.push({ name: `${res.data[i].name}`, value: res.data[i].name, id: res.data[i].id, name: res.data[i].name, coeficient: res.data[i].coeficient });

                }
                this.setState({ kriteriji: temp });
            })
    }


    handleChange = (e, index) => {
        this.state.id = this.state.kriteriji[index].id;
    }

    obrisiKriterij = () => {
        axios.delete(`http://localhost:8083/criteria/${this.state.id}`)
            .then(res => {
                var TEMP = [...this.state.kriteriji];
                for (var i = 0; i < TEMP.length; i++) {
                    if (TEMP[i].id === this.state.id) TEMP.splice(i, 1);
                }
                alert("Uspješno obrisan kriterij!");
                this.setState({ ocjene: TEMP })

            })
    }

    kreirajKriterij = () => {

        axios.post('http://localhost:8083/criteria', {
            name: this.state.name,
            coeficient: this.state.coeficient
        }).then(function (response) {
            alert("Kriterij uspješno dodan!");
        })
            .catch(function (error) {
                alert(error);
            });

        var TEMP = [...this.state.kriteriji];
        const temp = {
            name: this.state.name,
            coeficient: this.state.coeficient,
            obrisati: false
        }
        TEMP.push(temp);
        this.setState({ kriteriji: TEMP })

    }

    prikazKriterija() {
        return this.state.kriteriji.map((ocjena, index) => {
            const { name, coeficient } = ocjena
            const obrisati = false
            return (
                <tr key={name}>
                    <td>{name}</td>
                    <td>{coeficient}</td>
                    <td>{obrisati}
                        <div className="brisanje">
                            <label>
                                <input type="checkbox"
                                    brisati={this.state.checked}
                                    onChange={e => this.handleChange(e, index)}
                                />
                            </label>
                        </div>
                    </td>
                </tr>
            )
        })
    }

    headerTabele() {
        let header = Object.keys(this.state.Kriterij[0])
        return header.map((key, index) => {
            return <th key={index}>{key.toUpperCase()}</th>
        })
    }

    unosNovog = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    render() {
        return (
            <div>
            <h2 id='title'>Postojeći kriteriji</h2>
            <div className="glavniDIV">
            <table id='ocjene'>
                <tbody>
                <tr>{this.headerTabele()}</tr>
                {this.prikazKriterija()}
                </tbody>
            </table>
            <div className="footer">
                <button type="button" className="btnObrisiKriterij" onClick={this.obrisiKriterij}>
                    Obriši kriterij
                </button>
            </div>
            </div>

                <div className="formaKriterij">
                    <h2 id='title'>Dodavanje kriterija</h2>
                    <div className="form-grupaKriterij">
                        <label htmlFor="username">Naziv kriterija:</label>
                        <input
                            type="text"
                            name="name"
                            onChange={e => this.unosNovog(e)} />
                    </div>
                    <div className="form-grupaKriterij">
                        <label htmlFor="username">Unos koeficijenta:</label>
                        <input
                            type="number"
                            name="coeficient"
                            onChange={e => this.unosNovog(e)} />
                    </div>
                    <button type="button" className="btnDodajKriterij" onClick={this.kreirajKriterij}>
                        Dodavanje novog kriterija
                </button>
                </div>
            </div>
        )
    }
}

