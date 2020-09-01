import React, { Component } from 'react'
import axios from 'axios'
import CanvasJSReact from '../canvasjs.react'
import Modal from 'react-modal'

export class Dobavljaci extends Component {
    constructor(props) {
        super(props)
        this.state = {
            Dobavljaci: [],
            Header: [
                { Ime: "", Adresa: "", Kontakt_Osoba: "", Ocjene: "", brisati: false }
            ],
            ime: '',
            adresa: '',
            kontaktOsoba: '',
            id: '',
            modalIsOpen: false,
            chartOptions: [],
            sveOcjene: [],
            suplierChartOptions: [],
            criteria: [],
            modalSupIsOpen: false
        };
        this.startModal = this.startModal.bind(this)
        this.prikaziOcjene = this.prikaziOcjene.bind(this)
    }

    handleChange = (e, index) => {
        console.log(this.state.Dobavljaci[index])
        this.state.id = this.state.Dobavljaci[index].id;;
    }

    componentWillMount() {
        axios.get('http://localhost:8083/suppliers')
            .then(res => {
                const Dobavljaci = res.data;
                this.setState({ Dobavljaci });
            })

        axios.get('http://localhost:8083/grades/statistic')
            .then(res => {
                const ocjene = res.data;
                this.setState({ sveOcjene: ocjene });
            })

        axios.get('http://localhost:8083/criteria')
            .then(res => {
                this.setState({ criteria: res.data });
            })
    }

    obrisiDobavljaca = () => {
        axios.delete(`http://localhost:8083/suppliers/${this.state.id}`)
            .then(res => {
                var TEMP = [...this.state.Dobavljaci];
                for (var i = 0; i < TEMP.length; i++) {
                    if (TEMP[i].id === this.state.id) TEMP.splice(i, 1);
                }
                this.setState({ Dobavljaci: TEMP })
                alert("Uspješno obrisan dobavljač!");
            }).catch(err => {
                console.log(err.response.data.errors)
            })
    }

    kreirajDobavljaca = () => {
        axios.post('http://localhost:8083/suppliers', {
            adress: this.state.adresa,
            contactPeroson: this.state.kontaktOsoba,
            name: this.state.ime,
        }).then(response => {
            if (response.status === 201) alert("Dobavljač uspješno registrovan!")
        }).catch(err => {
            alert(err.response.data.errors)
        })

        var TEMP = [...this.state.Dobavljaci];
        const temp = {
            adress: this.state.adresa,
            contactPeroson: this.state.kontaktOsoba,
            name: this.state.ime,
            obrisati: false
        }

        TEMP.push(temp);
        this.setState({ Dobavljaci: TEMP })
    }

    prikaziOcjene(id) {
        this.setState({ modalSupIsOpen: true })
        var sveOcjene = this.state.sveOcjene

        var dataaaa = []

        for (var i = 0; i < sveOcjene.years.length; i++) {
            var dataPointsP = [];
            for (var j = 0; j < sveOcjene.suplierGradeDtoList.length; j++) {
                if (sveOcjene.suplierGradeDtoList[j].suplierId == id) {
                    if (sveOcjene.suplierGradeDtoList[j].year == sveOcjene.years[i]) {
                        for (var k = 0; k < sveOcjene.suplierGradeDtoList[j].gradesByCriteria.length; k++) {
                            dataPointsP.push({
                                label: sveOcjene.suplierGradeDtoList[j].gradesByCriteria[k].criteriaType.name,
                                y: sveOcjene.suplierGradeDtoList[j].gradesByCriteria[k].grade,
                            })
                        }
                    }
                }
            }
            var godina = sveOcjene.years[i] + ""
            var temp = {
                type: "column",
                showInLegend: true,
                name: godina,
                dataPoints: dataPointsP
            }
            dataaaa.push(temp)
        }

        const optionsSuplier = {
            title: {
                text: "Ocjene po kriterijima"
            },
            data: dataaaa
        }
        this.setState({ suplierChartOptions: optionsSuplier })
    }

    prikazDobavljaca() {
        return this.state.Dobavljaci.map((dobavljac, index) => {
            const { id, name, adress, contactPeroson } = dobavljac
            const brisati = false
            return (
                <tr key={name}>
                    <td>{name}</td>
                    <td>{adress}</td>
                    <td>{contactPeroson}</td>
                    <td>
                        <button onClick={e => this.prikaziOcjene(id)}>Ocjene</button>
                    </td>
                    <td>{brisati}
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
        let header = Object.keys(this.state.Header[0])
        return header.map((key, index) => {
            return <th key={index}>{key.toUpperCase()}</th>
        })
    }

    unosNovog = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    startModal() {

        this.setState({ modalIsOpen: true })

        var sveOcjene = this.state.sveOcjene

        var dataP = []
        var titleP = ''
        for (var i = 0; i < sveOcjene.years.length; i++) {
            var dataPointsP = [];

            for (var k = 0; k < sveOcjene.suplierGradeDtoList.length; k++) {
                if (sveOcjene.suplierGradeDtoList[k].year == sveOcjene.years[i]) {
                    dataPointsP.push({
                        label: sveOcjene.suplierGradeDtoList[k].suplierName,
                        y: sveOcjene.suplierGradeDtoList[k].finalGrade,
                    })
                }
            }
            var godina = sveOcjene.years[i] + ""
            var temp = {
                type: "column",
                showInLegend: true,
                name: godina,
                dataPoints: dataPointsP
            }
            dataP.push(temp)
        }

        const options = {
            title: {
                text: "Ocjene dobavljača po godinama"
            },
            data: dataP
        }
        this.setState({ chartOptions: options })
    }


    render() {

        return (
            <div>
                <button onClick={this.startModal}>Prikaz statistike</button>
                <Modal isOpen={this.state.modalIsOpen}>
                    <div>
                        <button onClick={() => this.setState({ modalIsOpen: false })}>Zatvori</button>
                    </div>
                    <div>
                        <CanvasJSReact.CanvasJSChart options={this.state.chartOptions} />
                    </div>
                </Modal>
                <Modal isOpen={this.state.modalSupIsOpen}>
                    <div>
                        <button onClick={() => this.setState({ modalSupIsOpen: false })}>Zatvori</button>
                    </div>
                    <div>
                        <CanvasJSReact.CanvasJSChart options={this.state.suplierChartOptions} />
                    </div>
                </Modal>
                <h2 id='title'>Postojeći dobavljači</h2>
                <div className="glavniDIV">
                    <table id='korisnici'>
                        <tbody>
                            <tr>{this.headerTabele()}</tr>
                            {this.prikazDobavljaca()}
                        </tbody>
                    </table>
                    <div className="footer">
                        <button type="submit" className="btnObrisiDobavljaca" onClick={this.obrisiDobavljaca}>
                            Obriši dobavljača
                </button>
                    </div>
                </div>
                <form>
                    <div className="formaDobavljaci">
                        <h2>Unos dobavljača</h2>
                        <div className="form-grupaDobavljaci">
                            <label htmlFor="ime">Ime:</label>
                            <input type="text"
                                name="ime"
                                value={this.state.ime}
                                onChange={e => this.unosNovog(e)} />
                        </div>
                        <div className="form-grupaDobavljaci">
                            <label htmlFor="adresa">Adresa:</label>
                            <input type="text"
                                name="adresa"
                                value={this.state.adresa}
                                onChange={e => this.unosNovog(e)} />
                        </div>
                        <div className="form-grupaDobavljaci">
                            <label htmlFor="kontaktOsoba">Kontakt osoba:</label>
                            <input type="text"
                                name="kontaktOsoba"
                                value={this.state.kontaktOsoba}
                                onChange={e => this.unosNovog(e)} />
                        </div>
                        <button type="submit" className="btnDodajDobavljaca" onClick={this.kreirajDobavljaca}>
                            Dodavanje novog dobavljača
                </button>
                    </div>
                </form>
            </div>
        )
    }
}

