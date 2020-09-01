import React, { Component } from 'react'
import axios from 'axios'
import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';

class DodavanjeEdukacije extends Component {
    constructor(props) {
        super(props)
        this.state = {
            uposlenici: [], // Za popunjavanje uposlenicima
            vjestine: [], // Za popunjavnje vjestina
            temp: '',
            temp2: '',
            level: '',
            vrijeme: '',
            Uposlenik: '', // Za odabranog uposlenika
            tipVjestine: '', // Za odabrani tip vjestine
            startDate: new Date()
        };
    }

    componentWillMount() {
        axios.get('http://localhost:8083/employees')
            .then(res => {
                var temp = [];
                for (var i = 0; i < res.data.length; i++) {
                    temp.push({ name: `${res.data[i].firstName}`, value: res.data[i].firstName + " " + res.data[i].lastName, lastName: res.data[i].lastName, birthDate: res.data[i].birthDate, dateOfEmployment: res.data[i].dateOfEmployment, educations: res.data[i].educations, id: res.data[i].id });
                }
                this.setState({ uposlenici: temp })
            })

        axios.get('http://localhost:8083/educations')
            .then(res => {
                var temp = [];
                for (var i = 0; i < res.data.length; i++) {
                    temp.push({ name: `${res.data[i].topic}`, value: res.data[i].topic, id: res.data[i].id });
                }
                this.setState({ vjestine: temp });
            })
    }

    handleChangeDate = date => {
        this.setState({
            startDate: date,
            vrijeme: date
        });
    }
    handleChangeVjestine = (selectedOption) => {
        if (selectedOption) {
            this.setState({ tipVjestine: selectedOption.value });
            this.setState({ temp2: selectedOption });
        }
    }

    handleChangeUposlenici = (selectedOption) => {
        if (selectedOption) {
            this.setState({ Uposlenik: selectedOption.value })
            this.setState({ temp: selectedOption });
        }
    }

    dodajVjestinu = () => {

        var idUposlenik = this.state.uposlenici.find(option => option.value === this.state.Uposlenik).id
        var idEdukacije = this.state.vjestine.find(option => option.value === this.state.tipVjestine).id

        var ruta = "http://localhost:8083/employeeEducation"
        axios.post(ruta, {
            employeeId: idUposlenik,
            educationId: idEdukacije

        }).then(function (response) {
            alert("Edukacija uspješno dodana!");
        })
            .catch(function (error) {
                alert(error);
            });
    }

    unosNovog = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    render() {
        return (
            <div>
                <h2 id='title'>Dodavanje edukacije uposleniku</h2>

                <div className="formaDodavanje">
                    <div className="form-grupaDodavanje">
                        <label htmlFor="username">Odaberite uposlenika:</label>
                        <Dropdown options={this.state.uposlenici}
                            value={this.state.temp}
                            onChange={(e) => {
                                this.handleChangeUposlenici(e);
                            }}
                            placeholder="Odaberite uposlenika"
                        />
                    </div>
                    <div className="form-grupaDodavanje">
                        <label htmlFor="username">Odaberite edukaciju:</label>
                        <Dropdown options={this.state.vjestine}
                            value={this.state.temp2}
                            onChange={(e) => {
                                this.handleChangeVjestine(e);
                            }}
                            placeholder="Odaberite ponuđenu edukaciju"
                        />
                    </div>
                    <button type="button" className="btnDodaj" onClick={this.dodajVjestinu}>
                        Dodavanje nove edukacije uposleniku
                </button>
                </div>
            </div>
        )
    }
}

export default DodavanjeEdukacije