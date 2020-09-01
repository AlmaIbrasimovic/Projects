import React, {Component} from 'react'
import axios from 'axios'
import DatePicker from "react-datepicker";
import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';
import "react-datepicker/dist/react-datepicker.css";



export class Edukacije extends Component {
    constructor(props) {
        super (props)
        this.state = {
            Korisnici : [
                {Tema: "", Host: "", Vrijeme: "", Tip_Edukacije: "", Vještina: "", obrisati: false}
            ],
            options: [], // Za popunjavanje tipova edukacije
            Edukacije:[], // Za popunjavanje tabele sa podacima edukacija iz baze
            vjestine:[], // Za popunjavnje tipova vjestina
            tema: '',
            host: '',
            uloga:'',
            vrijeme:'',
            id:'',
            temp:'',
            temp2:'',
            tipEdukacije:'', // Za odabrani tip edukacije
            tipVjestine:'', // Za odabrani tip vjestine
            startDate: new Date()
        };
    }

    componentWillMount() {
        axios.get('http://localhost:8083/educations')
          .then(res => {
            const Edukacije = res.data;
            this.setState({ Edukacije });
        })
          
        axios.get('http://localhost:8083/education-types')
          .then(res => {
            var temp=[];
            for (var i=0; i<res.data.length;i++) {
                temp.push({name: `${res.data[i].name}`, value: res.data[i].name, id: res.data[i].id});
                
            }
            this.setState({ options:temp });
        })

        axios.get('http://localhost:8083/skills')
          .then(res => {
            var temp=[];
            for (var i=0; i<res.data.length;i++) {
                temp.push({name: `${res.data[i].name}`, value: res.data[i].name, id: res.data[i].id, skillTypeId: res.data[i].skillType.id, skillTypeName: res.data[i].skillType.name});
            }
            this.setState({ vjestine:temp });
        })
      }

    handleChange = (e, index) => {
        this.state.id = this.state.Edukacije[index].id;;
    }

    handleChangeDate = date => {
        this.setState({
            startDate: date,
            vrijeme: date
        });
    }

    obrisiKorisnika = () => {
        axios.delete(`http://localhost:8083/educations/${this.state.id}`)
            .then(res => {
                var TEMP = [...this.state.Edukacije];
                for (var i = 0; i<TEMP.length; i++) {
                    if(TEMP[i].id === this.state.id) TEMP.splice(i, 1);
                }
                this.setState({Edukacije:TEMP})
                alert("Uspješno obrisana edukacija!");
        })
    }

    handleChangeVjestine = (selectedOption) => {
        if (selectedOption) {
            this.setState({tipVjestine:selectedOption.value});
            this.setState({temp2:selectedOption});
        }
    }

    handleChangeEdukacije = (selectedOption) => {
        if (selectedOption) {
            this.setState({tipEdukacije: selectedOption.value})
            this.setState({temp:selectedOption});
        }
    }

    kreirajKorisnika = () => {
        var idEdukacije = -1;
        var idVjestine = -1;
        var skillTypeId = -1;
        var skillTypeName = -1;
        for (var i = 0; i<this.state.options.length; i++) {
            if (this.state.options[i].value === this.state.tipEdukacije) idEdukacije = this.state.options[i].id;
        }

        for (var i = 0; i<this.state.vjestine.length; i++) {
            if (this.state.vjestine[i].value === this.state.tipVjestine) {
                idVjestine = this.state.vjestine[i].id;
                skillTypeName = this.state.vjestine[i].skillTypeName;
                skillTypeId = this.state.vjestine[i].id;
            }
        }

        axios.post('http://localhost:8083/educations', {
            host: this.state.host,
            dateTime: this.state.vrijeme,
            topic: this.state.tema,
            educationType: {
                id: idEdukacije,
                name: this.state.tipEdukacije
            },
            skill: {
                id: idVjestine,
                name: this.state.tipVjestine,
                skillType: {
                    id: skillTypeId,
                    name: skillTypeName
                }
            }
        })

        var TEMP = [...this.state.Edukacije];
        const temp = {
            topic: this.state.tema, 
            host: this.state.host, 
            //dateTime: "2020-05-16T12:39:41.684Z",  
            dateTime: this.state.vrijeme,
            educationType: {
                id: idEdukacije,
                name: this.state.tipEdukacije
            }, 
            skill: {
                id: idVjestine,
                name: this.state.tipVjestine,
                skillType: {
                    id: skillTypeId,
                    name: skillTypeName
                }
            }, 
            obrisati: false
        }
        TEMP.push(temp);
        this.setState({Edukacije:TEMP}) 
        alert("Edukacije uspješno kreirana!") 
    }
     
    prikazKorisnika() {
        return this.state.Edukacije.map((edukacija, index) => {
            const {topic, host, dateTime, educationType, skill} = edukacija
            const brisati = false
            return (
                <tr key={topic}>
                   <td>{topic}</td>
                   <td>{host}</td>
                   <td>{dateTime}</td>
                   <td>{educationType.name}</td>
                   <td>{skill.name}</td> 
                   <td>{brisati}
                        <div className="brisanje">
                            <label>
                                <input type="checkbox"  
                                    brisati={this.state.checked}
                                    onChange={e => this.handleChange(e, index)}/>
                            </label>
                        </div>
                    </td>      
                </tr>
             ) 
         })
    }

    headerTabele() {
        let header = Object.keys(this.state.Korisnici[0])
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
            <h2 id='title'>Edukacije</h2>
            <div className="glavniDIV">
            <table id='korisnici'>
               <tbody>
                  <tr>{this.headerTabele()}</tr>
                  {this.prikazKorisnika()}
               </tbody>
            </table>
            
            <div className="footer">
                <button type="button" className="btnObrisiEdukaciju"  onClick={this.obrisiKorisnika}>
                    Obriši edukaciju
                </button>
            </div>

            </div>
            <div className="formaEdukacije">
                <h2>Unos edukacije</h2>
                <div className="form-grupaEdukacije">
                    <label htmlFor="username">Tema:</label>
                    <input type="text"
                    name="tema"
                    value={this.state.tema} 
                    onChange={e => this.unosNovog(e)}/>
                </div>
                <div className="form-grupaEdukacije">
                    <label htmlFor="username">Host:</label>
                    <input type="text"
                    name="host"
                    value={this.state.host} 
                    onChange={e => this.unosNovog(e)}/>
                </div>
                <div className="form-grupaEdukacije">
                    <label htmlFor="username">Vrijeme:</label>
                    <DatePicker
                        name="vrijeme"
                        selected={this.state.startDate}
                        onChange={this.handleChangeDate}
                        showTimeSelect
                        dateFormat="Pp"
                    />
                </div>
                <div className="form-grupaEdukacije">
                    <label htmlFor="username">Edukacije:</label>
                    <Dropdown options={this.state.options}      
                        value={this.state.temp} 
                        onChange={(e) => {
                            this.handleChangeEdukacije(e);
                        }}
                        placeholder="Odaberite ponuđeni tip edukacije"
                    />  
                </div>
                <div className="form-grupaEdukacije">
                    <label htmlFor="username">Vještina:</label>
                    <Dropdown options={this.state.vjestine}      
                        value={this.state.temp2} 
                        onChange={(e) => {
                            this.handleChangeVjestine(e);
                        }}
                        placeholder="Odaberite ponuđeni tip vještine"
                    />  
                </div>
                <button type="button" className="btnDodajEdukaciju" onClick={this.kreirajKorisnika}>
                    Dodavanje nove edukacije
                </button>
                </div>
            </div>
        )
    }
}