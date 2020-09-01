import React, {Component} from 'react'
import axios from 'axios'
import DatePicker from "react-datepicker";
import Dropdown from 'react-dropdown';

export class Ugovori extends Component {
    constructor(props) {
        super (props)
        this.state = {
            Ugovori : [],
            Header : [
                {Ime: "", Datum_Kreiranja: "", Datum_Isteka: "", Dobavljač: "",Kontakt_Osoba_Dobavljača: "", brisati: false}
            ],
            dobavljaciOpcija:[], // Za popunjavanje dropdowna
            sviDobavljaci:[], // Za kreiranje FK-a
            ime:'',
            kreiranje:'',
            istek:'',
            id:'',
            dobavljac:'', // Koji se dobavljac odabrao
            temp:'',
            startDate: new Date(),
            startDate2: new Date(),
        
        };
    }

    handleChange = (e, index) => {
        console.log(this.state.Ugovori[index])
        this.state.id = this.state.Ugovori[index].id;;
    }

    handleChangeDate = date => {
        this.setState({
            startDate: date,
            kreiranje: date
        });
    }

    handleChangeDateIstek = date => {
        this.setState({
            startDate2: date,
            istek: date
        });
    }
    
    handleChangeDobavljac = (selectedOption) => {
        if (selectedOption) {
            this.setState({dobavljac:selectedOption.value});
            this.setState({temp:selectedOption});
        }
    }

    componentWillMount() {
        axios.get('http://localhost:8083/contracts')
          .then(res => {
            const Ugovori = res.data;
            this.setState({ Ugovori });
        })

        axios.get('http://localhost:8083/suppliers')
          .then(res => {
            var temp=[];
            const sviDobavljaci = res.data;
            this.setState({ sviDobavljaci });
            for (var i=0; i<res.data.length;i++) {
                temp.push({name: `${res.data[i].name}`, value: res.data[i].name, id: res.data[i].id});
            }
            this.setState({ dobavljaciOpcija:temp });
        })
    }

    obrisiUgovor = () => {
        axios.delete(`http://localhost:8083/contracts/${this.state.id}`)
            .then(res => {
                var TEMP = [...this.state.Ugovori];
                for (var i = 0; i<TEMP.length; i++) {
                    if(TEMP[i].id === this.state.id) TEMP.splice(i, 1);
                }
                this.setState({Ugovori:TEMP})
                alert("Uspješno obrisan ugovor!");
        }).catch(err => {
            console.log(err.response.data.errors)
        })
    }

    kreirajUgovor = () => {   
        var idUgovora = ''
        for (var i = 0; i<this.state.dobavljaciOpcija.length; i++) {
            if (this.state.dobavljaciOpcija[i].value === this.state.dobavljac) idUgovora = this.state.dobavljaciOpcija[i].id;
        }

        axios.post('http://localhost:8083/contracts', {
            name: this.state.ime,
            createdDate: this.state.kreiranje,
            expiredDate: this.state.istek,
            suplier: this.state.sviDobavljaci[idUgovora-1]
        }).then(response => {
            if (response.status === 201 || response.status === 200) alert("Ugovor uspješno registrovan!")
          }).catch(err => {
            alert(err.response.data.errors)
        })

        var TEMP = [...this.state.Ugovori];
        const temp = {
            name: this.state.ime,
            createdDate: this.state.kreiranje,
            expiredDate: this.state.istek,
            suplier: this.state.sviDobavljaci[idUgovora-1],
            obrisati: false
        }
        TEMP.push(temp);
        this.setState({Ugovori:TEMP}) 
    }

    prikazUgovora() {
        return this.state.Ugovori.map((ugovor, index) => {
           const {name, createdDate, expiredDate, suplier} = ugovor
           const brisati = false
           return (
              <tr key={name}>
                 <td>{name}</td>
                 <td>{createdDate}</td>
                 <td>{expiredDate}</td>
                 <td>{suplier.name}</td>
                 <td>{suplier.contactPeroson}</td>
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
    
    render() {
        return (    
            <div>
            <h2 id='title'>Postojeći ugovori</h2>
            <div className="glavniDIV">
            <table id='korisnici'>
               <tbody>
                  <tr>{this.headerTabele()}</tr>
                  {this.prikazUgovora()}
               </tbody>
            </table>
            <div className="footer">
                <button type="submit" className="btnObrisiUgovor" onClick={this.obrisiUgovor}>
                    Obriši ugovor
                </button>
            </div>
            </div>
            <form>
            <div className="formaUgovori">
                <h2>Unos ugovora</h2>
                <div className="form-grupaUgovori">
                    <label htmlFor="ime">Ime:</label>
                    <input type="text"
                    name="ime"
                    value={this.state.ime} 
                    onChange={e => this.unosNovog(e)}/>
                </div>
                <div className="form-grupaUgovori">
                    <label htmlFor="adresa">Datum kreirenja:</label>
                    <DatePicker
                        name="kreiranje"
                        selected={this.state.startDate}
                        onChange={this.handleChangeDate}
                        showTimeSelect
                        dateFormat="dd/MM/yyyy, hh:mm"
                    />
                    
                </div>
                <div className="form-grupaUgovori">
                    <label htmlFor="kontaktOsoba">Datum isteka:</label>
                    <DatePicker
                        name="istek"
                        selected={this.state.startDate2}
                        onChange={this.handleChangeDateIstek}
                        showTimeSelect
                        dateFormat="dd/MM/yyyy, hh:mm"
                    />
                </div>
                <div className="form-grupaUgovori">
                    <label htmlFor="dobavljac">Odaberite dobavljača:</label>
                    <Dropdown options={this.state.dobavljaciOpcija}
                        value={this.state.temp}
                        onChange={(e) => {
                            this.handleChangeDobavljac(e);
                        }}
                    placeholder="Odaberite ponuđenog dobavljača"
                    />
                </div>
                <button type="submit" className="btnDodajUgovor"  onClick={this.kreirajUgovor}>
                    Dodavanje novog ugovora
                </button>
            </div>
            </form>
            </div>
        )
    }
}

