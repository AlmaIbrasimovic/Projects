import React, {Component} from 'react'
import axios from 'axios'
import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';

export class TipoviEdukacija extends Component {
    constructor(props) {
        super (props)
        this.state = {
            TipoviEdukacija : [
                {tip:"Interna", obrisati: false}
            ],
            tip:'',
            tipovi:[]
        };
    }

    componentWillMount() {
        axios.get('http://localhost:8083/education-types')
          .then(res => {
            const tipovi = res.data;
            this.setState({ tipovi });
        })
    }
    
    handleChange = (e, index) => {
        this.state.id = this.state.tipovi[index].id;;
    }

    obrisiTip = () => {
        axios.delete(`http://localhost:8083/education-types/${this.state.id}`)
        .then(res => {
            var TEMP = [...this.state.tipovi];
            for (var i = 0; i<TEMP.length; i++) {
                if(TEMP[i].obrisati) TEMP.splice(i, 1);
            }
        this.setState({tipovi:TEMP})
        alert("Uspješno obrisan tip edukacije!");
        })
    }

    kreirajTip = () => {
            axios.post('http://localhost:8083/education-types', {
              name:this.state.tip
            })

            var TEMP = [...this.state.tipovi];
            const temp = {name:this.state.tip, obrisati: false}
            TEMP.push(temp);
            this.setState({tipovi:TEMP})
    }

    prikazTipova() {
        return this.state.tipovi.map((tipov, index) => {
           const {name} = tipov
           const obrisati=false
           return (
              <tr key={name}>
                 <td>{name}</td>
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
        let header = Object.keys(this.state.TipoviEdukacija[0])
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
            <h2 id='title'>Postojeći tipovi edukacija</h2>
            <div className="glavniDIV">
            <table id='tipoviEdu'>
               <tbody>
                  <tr>{this.headerTabele()}</tr>
                  {this.prikazTipova()}
               </tbody>
            </table>
            <div className="footer">
                <button type="button" className="btnObrisiEdukaciju"  onClick={this.obrisiTip}>
                    Obriši tip edukacije
                </button>
            </div>

            </div>
            <div className="formaTipoviEdukacije">
            <h2 id='title'>Dodavanje novog tipa edukacije</h2>
                <div className="form-grupaTipoviEdukacije">
                    <label htmlFor="username">Tip edukacije:</label>
                    <input type="text"
                    name="tip"
                    value={this.state.tip} 
                    onChange={e => this.unosNovog(e)}/>
                </div>
                <button type="button" className="btnDodajEdukaciju"  onClick={this.kreirajTip}>
                    Dodavanje novog tipa edukacije
                </button>
            </div>
            </div>
        )
    }
}

