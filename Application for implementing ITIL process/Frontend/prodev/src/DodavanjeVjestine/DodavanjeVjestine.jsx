import React, {Component} from 'react'
import axios from 'axios'
import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';

export class DodavanjeVjestine extends Component {
    constructor(props) {
        super (props)
        this.state = {
            uposlenici: [], // Za popunjavanje uposlenicima
            vjestine:[], // Za popunjavnje vjestina
            temp:'',
            temp2:'',
            level:'',
            vrijeme:'',
            Uposlenik:'', // Za odabranog uposlenika
            tipVjestine:'', // Za odabrani tip vjestine
            startDate: new Date()
        };
    }

    componentWillMount() {
        axios.get('http://localhost:8083/employees')
          .then(res => {
            var temp=[];
                for (var i=0; i<res.data.length;i++) {
                    temp.push({name: `${res.data[i].firstName}`,value:res.data[i].firstName+" "+res.data[i].lastName, lastName: res.data[i].lastName, birthDate:res.data[i].birthDate, dateOfEmployment:res.data[i].dateOfEmployment, educations:res.data[i].educations, id:res.data[i].id});
                }
            this.setState({uposlenici:temp})
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

    handleChangeDate = date => {
            this.setState({
                startDate: date,
                vrijeme: date
            });
    }
    handleChangeVjestine = (selectedOption) => {
        if (selectedOption) {
            this.setState({tipVjestine:selectedOption.value});
            this.setState({temp2:selectedOption});
        }
    }

    handleChangeUposlenici = (selectedOption) => {
        if (selectedOption) {
            this.setState({Uposlenik: selectedOption.value})
            this.setState({temp:selectedOption});
        }
    }

    dodajVjestinu = () => {
        var idUposlenika = -1;
        var idVjestine = -1;
        var nameVjestine = -1;
        var skillTypeId = -1;
        var skillTypeName = -1;
        for (var i = 0; i<this.state.uposlenici.length; i++) {
            if (this.state.uposlenici[i].value === this.state.Uposlenik) idUposlenika = this.state.uposlenici[i].id;
        }

        for (var i = 0; i<this.state.vjestine.length; i++) {
            if (this.state.vjestine[i].value === this.state.tipVjestine) {
                idVjestine = this.state.vjestine[i].id;
                nameVjestine=this.state.vjestine[i].name;
                skillTypeName = this.state.vjestine[i].skillTypeName;
                skillTypeId = this.state.vjestine[i].id;
            }
        }

        var ruta="http://localhost:8083/employees/"+idUposlenika+"/skills"
        axios.post(ruta , {
            dateCreated: this.state.startDate,
             skill: {
                id: idVjestine,
                name: nameVjestine,
                skillType: {
                  id: skillTypeId,
                  name: skillTypeName
                }
              },
              skillLevel: this.state.level
        }).then(function (response) {
              alert("Vještina uspješno dodana!");
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
            <h2 id='title'>Dodavanje vještine</h2>

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
                    <label htmlFor="username">Odaberite vještinu:</label>
                    <Dropdown options={this.state.vjestine}
                        value={this.state.temp2}
                        onChange={(e) => {
                            this.handleChangeVjestine(e);
                        }}
                    placeholder="Odaberite ponuđenu vještinu"
                    />
                </div>
                <div className="form-grupaDodavanje">
                    <label htmlFor="username">Level:</label>
                    <input type="number"
                        name="level"
                        value={this.state.level}
                        onChange={e => this.unosNovog(e)}/>
                </div>

                <button type="button" className="btnDodaj" onClick={this.dodajVjestinu}>
                    Dodavanje nove vještine uposleniku
                </button>
            </div>
            </div>
        )
    }
}