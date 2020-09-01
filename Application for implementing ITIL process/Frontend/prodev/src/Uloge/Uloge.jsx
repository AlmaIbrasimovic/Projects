import React, {Component} from 'react'

export class Uloge extends Component {
    constructor(props) {
        super (props)
        this.state = {
            Uloge : [
                {uloga: "Kupac", obrisati: false},
                {uloga: "Direktor", obrisati: false},
                {uloga: "Administrator", obrisati: false}
            ],
            uloga: '',
        };
    }

    handleChange = (e, index) => {
        this.state.Uloge[index].obrisati = true;
    }

    obrisiUlogu = () => {
        var TEMP = [...this.state.Uloge];
        for (var i = 0; i<TEMP.length; i++) {
            if(TEMP[i].obrisati) TEMP.splice(i, 1);
        }
        this.setState({Uloge:TEMP})
    }

    kreirajUlogu = () => {
        var TEMP = [...this.state.Uloge];
        const temp = {uloga: this.state.uloga, obrisati: false}
        TEMP.push(temp);
        this.setState({Uloge:TEMP})
    }

    prikazUloge() {
        return this.state.Uloge.map((ulogica, index) => {
           const {uloga, obrisati} = ulogica
           return (
              <tr key={uloga}>
                 <td>{uloga}</td>
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
        let header = Object.keys(this.state.Uloge[0])
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
            <h2 id='title'>Postojeće uloge</h2>
            <div className="glavniDIV">
            <table id='uloge'>
               <tbody>
                  <tr>{this.headerTabele()}</tr>
                  {this.prikazUloge()}
               </tbody>
            </table>
            <div className="footer">
                <button type="button" className="btn"  onClick={this.obrisiUlogu}>
                    Obriši ulogu
                </button>
            </div>
            </div>
            <div className="forma">
                <div className="form-grupa">
                    <label htmlFor="username">Uloga:</label>
                    <input type="text"
                    name="uloga"
                    value={this.state.uloga}
                    onChange={e => this.unosNovog(e)}/>
                </div>
                <button type="button" className="btn"  onClick={this.kreirajUlogu}>
                    Dodavanje nove uloge
                </button>
            </div>
            </div>
        )
    }
}

