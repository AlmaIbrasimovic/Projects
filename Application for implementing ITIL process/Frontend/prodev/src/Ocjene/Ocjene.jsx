import React, {Component} from 'react'
import axios from 'axios'
import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";

export class Ocjene extends Component {
    constructor(props) {
        super (props)
        this.state = {
            Ocjene : [
                {Kriterij:"", Dobavljač: "", Korisnik:"", Ocjena:"", Godina:"", obrisati: false},
            ],
            ocjene:[],
            kriteriji: [], // Za popunjavanje tipova vjestina
            dobavljaci:[],
            korisnici:[],
            izabraniDobavljac:'',
            izabraniKriterij:'',
            datumOcjenjivanja:'',
            izabraniKorisnik:'',
            godina: '',
            ocjena:'',
            id:'',
            tempDobavaljac:'',
            tempKorisnik:'',
            tempKriterij:'',
            startDate:new Date()
        };
    }

    componentWillMount() {

            axios.get('http://localhost:8083/grade/all')
                          .then(res => {
                            var temp=[];
                            for (var i=0; i<res.data.length;i++) {
                                temp.push({name: `${res.data[i].criteriaType.coeficient}`, value: res.data[i].criteriaType.coeficient, id: res.data[i].id,criteriaType:res.data[i].criteriaType.name, dateOfGrading:res.data[i].dateOfGrading, grade:res.data[i].grade, suplier:res.data[i].suplier, suplierName:res.data[i].suplier.name, user:res.data[i].grade, userName:res.data[i].user.email, year:res.data[i].year});
                            }
                            this.setState({ ocjene:temp });
            })

            axios.get('http://localhost:8083/user/all')
              .then(res => {
                var temp=[];
                for (var i=0; i<res.data.length;i++) {
                    temp.push({name: `${res.data[i].username}`, value: res.data[i].username, id: res.data[i].id, username:res.data[i].username, password:res.data[i].password,email:res.data[i].email,roleList:res.data[i].roleList});

                }
                console.log(temp)
                this.setState({ korisnici:temp });
            })

            axios.get('http://localhost:8083/suppliers')
              .then(res => {
                var temp=[];
                for (var i=0; i<res.data.length;i++) {
                    temp.push({name: `${res.data[i].name}`, value: res.data[i].name, id: res.data[i].id, name:res.data[i].name, adress:res.data[i].adress,contactPerson:res.data[i].contactPerson});

                }
                this.setState({ dobavljaci:temp });
            })

            axios.get('http://localhost:8083/criteria')
              .then(res => {
                var temp=[];
                for (var i=0; i<res.data.length;i++) {
                    temp.push({name: `${res.data[i].name}`, value: res.data[i].name, id: res.data[i].id, name:res.data[i].name, coeficient:res.data[i].coeficient});

                }
                this.setState({ kriteriji:temp });
            })
    }


    handleChange = (e, index) => {
            this.state.id = this.state.ocjene[index].suplier.id;
    }

    obrisiOcjenu = () => {
        axios.delete(`http://localhost:8083/grade/suplier/${this.state.id}`)
                    .then(res => {
                        var TEMP = [...this.state.ocjene];
                        for (var i = 0; i<TEMP.length; i++) {
                            if(TEMP[i].suplier.id === this.state.id) TEMP.splice(i, 1);
                        }
                        alert("Uspješno obrisana ocjena!");
                        this.setState({ocjene:TEMP})
                         
        })
    }

    handleChangeDobavljaci = (selectedOption) => {
            if (selectedOption) {
                this.setState({izabraniDobavljac:selectedOption.value});
                this.setState({tempDobavaljac:selectedOption});
            }
    }

    handleChangeKriteriji = (selectedOption) => {
        if (selectedOption) {
            this.setState({izabraniKriterij:selectedOption.value});
            this.setState({tempKriterij:selectedOption});
        }
    
    }

    handleChangeKorisnici = (selectedOption) => {
        if (selectedOption) {
            this.setState({izabraniKorisnik:selectedOption.value});
            this.setState({tempKorisnik:selectedOption});
        }
    }

    handleChangeDate = date => {
        this.setState({
            startDate: date,
            datumOcjenjivanja: date
        });
    }

    kreirajOcjenu = () => {
            var idDobavljaca = -1;
            var idKriterija=-1;
            var idKorisnika=-1;

            for (var i = 0; i<this.state.dobavljaci.length; i++) {
                if (this.state.dobavljaci[i].value === this.state.izabraniDobavljac) idDobavljaca = this.state.dobavljaci[i].id;
            }

            for (var i = 0; i<this.state.korisnici.length; i++) {
                if (this.state.korisnici[i].value === this.state.izabraniKorisnik) idKorisnika = this.state.korisnici[i].id;
            }

            for (var i = 0; i<this.state.kriteriji.length; i++) {
                if (this.state.kriteriji[i].value === this.state.izabraniKriterij) idKriterija = this.state.kriteriji[i].id;
            }

            axios.post('http://localhost:8083/grade', {
                criteriaType:{
                    id:idKriterija
                },
                dateOfGrading:this.state.datumOcjenjivanja,
                grade:this.state.ocjena,
                suplier:{
                    id:idDobavljaca
                },
                user:{
                    id:idKorisnika
                },
                year:this.state.godina
            }).then(function (response) {
                alert("Ocjena uspješno dodana!");
              })
              .catch(function (error) {
                alert(error);
              });

            var TEMP = [...this.state.ocjene];
            const temp = {
                criteriaType:{
                    id:idKriterija
                },
                dateOfGrading:this.state.datumOcjenjivanja,
                grade:this.state.ocjena,
                suplier:{
                    id:idDobavljaca
                },
                user:{
                    id:idKorisnika
                },
                year:this.state.godina,
                obrisati: false
            }
            TEMP.push(temp);
            this.setState({ocjene:TEMP})
            
    }

    prikazOcjena() {
        return this.state.ocjene.map((ocjena, index) => {
           const {criteriaType,suplierName,userName,grade,year} = ocjena
           const obrisati = false
           return (
              <tr key={criteriaType}>
                 <td>{criteriaType}</td>
                 <td>{suplierName}</td>
                 <td>{userName}</td>
                 <td>{grade}</td>
                 <td>{year}</td>
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
        let header = Object.keys(this.state.Ocjene[0])
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
            <h2 id='title'>Postojeće ocjene</h2>
            <div className="glavniDIV">
            <table id='ocjene'>
               <tbody>
                  <tr>{this.headerTabele()}</tr>
                  {this.prikazOcjena()}
               </tbody>
            </table>
            <div className="footer">
                <button type="button" className="btnObrisiOcjenu"  onClick={this.obrisiOcjenu}>
                    Obriši ocjenu
                </button>
            </div>
            </div>
            <div className="formaOcjene">
            <h2 id='title'>Dodavanje ocjene</h2>
                <div className="form-grupaOcjene">
                    <label htmlFor="username">Izaberite dobavljača:</label>
                    <Dropdown options={this.state.dobavljaci}
                        value={this.state.tempDobavaljac}
                        onChange={(e) => {
                        this.handleChangeDobavljaci(e);
                        }}
                        placeholder="Odaberite dobavljača"
                    />
                </div>
                <div className="form-grupaOcjene">
                    <label htmlFor="username">Izaberite kriterij:</label>
                    <Dropdown options={this.state.kriteriji}
                        value={this.state.tempKriterij}
                        onChange={(e) => {
                        this.handleChangeKriteriji(e);
                        }}
                        placeholder="Odaberite kriterij"
                    />
                </div>
                <div className="form-grupaOcjene">
                    <label htmlFor="username">Izaberite korisnika:</label>
                    <Dropdown options={this.state.korisnici}
                        value={this.state.tempKorisnik}
                        onChange={(e) => {
                        this.handleChangeKorisnici(e);
                        }}
                        placeholder="Odaberite korisnika"
                    />
                </div>
                <div className="form-grupaOcjene">
                    <label htmlFor="username">Datum ocjenjivanja:</label>
                    <DatePicker
                        name="vrijeme"
                        selected={this.state.startDate}
                        onChange={this.handleChangeDate}
                        showTimeSelect
                        dateFormat="Pp"
                    />
                </div>
                <div className="form-grupaOcjene">
                    <label htmlFor="username">Ocjena:</label>
                    <input type="number"
                    name="ocjena"
                    value={this.state.ocjena}
                    onChange={e => this.unosNovog(e)}/>
                </div>
                <div className="form-grupaOcjene">
                    <label htmlFor="username">Godina unosa:</label>
                    <input type="number"
                    name="godina"
                    value={this.state.godina}
                    onChange={e => this.unosNovog(e)}/>
                </div>
                <button type="button" className="btnDodajOcjenu"  onClick={this.kreirajOcjenu}>
                    Dodavanje nove ocjene
                </button>
            </div>
            </div>
        )
    }
}

