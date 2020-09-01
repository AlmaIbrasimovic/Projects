import React, {Component} from 'react'
import axios from 'axios'
import Dropdown from 'react-dropdown';
import 'react-dropdown/style.css';

export class Tipovi extends Component {
    constructor(props) {
        super (props)
        this.state = {
            Tip : [
                {tip:"Razvoj softvera", obrisati: false}
            ],
            Tipovi: [],
            tip:'',
        };
    }

    componentWillMount() {
            axios.get('http://localhost:8083/skill-types')
              .then(res => {
                const Tipovi = res.data;
                this.setState({ Tipovi });
            })
    }

    handleChange = (e, index) => {
            this.state.id = this.state.Tipovi[index].id;;
    }

    obrisiTip = () => {
        axios.delete(`http://localhost:8083/skill-types/${this.state.id}`)
            .then(res => {
                 var TEMP = [...this.state.Tipovi];
                 for (var i = 0; i<TEMP.length; i++) {
                     if(TEMP[i].id === this.state.id) TEMP.splice(i, 1);
                 }
                 this.setState({Tipovi:TEMP})
                 alert("Uspješno obrisan tip vještine!");
        })
    }

    kreirajTip = () => {
        axios.post('http://localhost:8083/skill-types', {
          name:this.state.tip
        })

        var TEMP = [...this.state.Tipovi];
        const temp = {name:this.state.tip, obrisati: false}
        TEMP.push(temp);
        this.setState({Tipovi:TEMP})
    }

    prikazTipova() {
        return this.state.Tipovi.map((tipovii, index) => {
           const {name} = tipovii
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
        let header = Object.keys(this.state.Tip[0])
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
            <h2 id='title'>Postojeći tipovi</h2>
            <div className="glavniDIV">
            <table id='tipVjestine'>
               <tbody>
                  <tr>{this.headerTabele()}</tr>
                  {this.prikazTipova()}
               </tbody>
            </table>
            <div className="footer">
                <button type="button" className="btnObrisiTip"  onClick={this.obrisiTip}>
                    Obriši tip vještine
                </button>
            </div>

            </div>
            <div className="formaTipovi">
            <h2 id='title'>Dodaj tip vještine</h2>
                <div className="form-grupaTipovi">
                    <label htmlFor="username">Tip vještine:</label>
                    <input type="text"
                    name="tip"
                    value={this.state.tip} 
                    onChange={e => this.unosNovog(e)}/>
                </div>
                <button type="button" className="btnDodajTip"  onClick={this.kreirajTip}>
                    Dodavanje novog tipa vještine
                </button>
            </div>
            </div>
        )
    }
}

