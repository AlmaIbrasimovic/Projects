import React, { Component } from 'react'
import axios from 'axios'
import Select from 'react-select';
import FileBase64 from 'react-file-base64';
import {toast} from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'

toast.configure()
function validacija(Ime, vrsta, rasa, odabraniSpol, godine, tezina, odabranaVelicina, slika, opis) {
  return {
    Ime: Ime.length === 0,
    vrsta: vrsta.length === 0,
    rasa: rasa.length === 0,     
    odabraniSpol:odabraniSpol.length === 0,
    godine: godine.length === 0,
    tezina: tezina.length === 0,
    odabranaVelicina: odabranaVelicina.length === 0,
    slika: slika === null,
    opis: opis.length === 0
  };
}

export class KreirajZivotinju extends Component {
    constructor(props) {
        super(props)
        this.state = {
            Zivotinje: [],
            spol: [
                { value: 'M', label: 'Muško'},
                { value: 'Z', label: 'Žensko'}
            ],
            velicina: [
                { value: 'Mali rast', label: 'Mali rast'},
                { value: 'Srednji rast', label: 'Srednji rast'},
                { value: 'Veliki rast', label: 'Veliki rast'},
            ],

            // Za validaciju
            touched: {
              Ime: false,
              vrsta: false,
              rasa: false,
              odabraniSpol: false,
              godine: false,
              tezina: false,
              odabranaVelicina: false,
              slika: false,
              opis: false
            },

            Ime:'',
            vrsta:'',
            rasa:'',
            odabraniSpol:'',
            godine:'',
            tezina:'',
            odabranaVelicina:'',
            slika:null,
            opis:''
        }
    }

    handleChange = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    handleChangeSpol = (selectedOption) => {
        if (selectedOption) {
            this.setState({odabraniSpol:selectedOption.value});           
        }
    }

    handleChangeVelicina = (selectedOption) => {
        if (selectedOption) {
            this.setState({odabranaVelicina:selectedOption.value});
        }
    }

    handleBlur = field => evt => {
      this.setState({
        touched: { ...this.state.touched, [field]: true }
      });
    };

    KreirajZivotinju = () => {  
      var tempSlika =''
      tempSlika = this.state.slika[0].base64.substring(23, this.state.slika[0].base64.length)
      axios.post('http://localhost:8080/zivotinje', {
        ime: this.state.Ime,
        vrsta: this.state.vrsta,
        rasa: this.state.rasa,
        godine: Number(this.state.godine),
        udomljena: false,
        slika: tempSlika,
        spol: this.state.odabraniSpol,
        velicina: this.state.odabranaVelicina,
        dodatniOpis: this.state.opis,
        tezina: Number(this.state.tezina)
      }).then(response => {
        if (response.status === 200 || response.status === 201) toast.success('Životinja uspješno kreirana', {position: toast.POSITION.TOP_RIGHT})
      }).catch(err => {
        toast.error(err.response.data.errors.toString(), {position: toast.POSITION.TOP_RIGHT})
      })
    }

    getFiles(files){
      this.setState({ slika: files })
    }

    render() {
      const errors = validacija(this.state.Ime, this.state.vrsta, this.state.rasa, this.state.odabraniSpol, 
                                this.state.godine, this.state.tezina, this.state.odabranaVelicina,
                                this.state.slika, this.state.opis);
      const isDisabled = Object.keys(errors).some(x => errors[x]);
      const shouldMarkError = field => {
        const hasError = errors[field];
        const shouldShow = this.state.touched[field];
        return hasError ? shouldShow : false;
      };

      return (
            <div className="wrapper">
              <div className="form-wrapper">
                <h1>Kreiraj životinju</h1>
                <form>
                  <div className="Ime">
                    <label htmlFor="Ime">Ime</label>
                    <input 
                      className={shouldMarkError("Ime") ? "error" : ""}  
                      placeholder="Ime"
                      value={this.state.Ime}
                      onBlur={this.handleBlur("Ime")}
                      onChange={e => this.handleChange(e)}
                      type="text"
                      name="Ime"             
                    />                  
                  </div>
                  <div className="vrsta">
                    <label htmlFor="vrsta">Vrsta životinje</label>
                    <input    
                      className={shouldMarkError("vrsta") ? "error" : ""}                
                      placeholder="Vrsta životinje"
                      value={this.state.vrsta}
                      onChange={e => this.handleChange(e)}
                      onBlur={this.handleBlur("vrsta")}
                      type="text"
                      name="vrsta"             
                    />         
                  </div>
                  <div className="rasa">
                    <label htmlFor="rasa">Rasa</label>
                    <input
                      className={shouldMarkError("rasa") ? "error" : ""}                
                      placeholder="Rasa"
                      type="text"
                      onBlur={this.handleBlur("rasa")}
                      value={this.state.rasa}
                      onChange={e => this.handleChange(e)}
                      name="rasa"
                    />
                  </div>
                  <div className="godine">
                    <label htmlFor="godine">Godine</label>
                    <input
                      className={shouldMarkError("godine") ? "error" : ""}  
                      placeholder="Godine"
                      onBlur={this.handleBlur("godine")}
                      value={this.state.godine}
                      onChange={e => this.handleChange(e)}
                      type="number"
                      name="godine"  
                    />
                  </div>
                  <div className="spol">
                    <label htmlFor="spol">Spol</label>
                    <Select
                        onBlur={this.handleBlur("spol")}
                        className={shouldMarkError("odabraniSpol") ? "error" : ""}  
                        options={this.state.spol}
                        onChange={(e) => {
                            this.handleChangeSpol(e);
                        }}
                        name="spol"
                    />                  
                  </div>
                  <div className="velicina">
                    <label htmlFor="velicina">Veličina</label>
                    <Select
                        onBlur={this.handleBlur("velicina")}
                        className={shouldMarkError("odabranaVelicina") ? "error" : ""}  
                        options={this.state.velicina}
                        onChange={(e) => {
                            this.handleChangeVelicina(e);
                        }}
                        name="velicina"
                    />
                  </div>
                  <div className="tezina">
                    <label htmlFor="tezina">Težina</label>
                    <input
                      onBlur={this.handleBlur("tezina")}  
                      className={shouldMarkError("tezina") ? "error" : ""}  
                      placeholder="Težina"
                      value={this.state.tezina}
                      onChange={e => this.handleChange(e)}
                      type="number"
                      name="tezina"
                    />
                  </div>
                  <div className="slikaA">
                    <label htmlFor="slika">Slika</label>
                    <FileBase64
                      onBlur={this.handleBlur("slika")}
                      className={shouldMarkError("slika") ? "error" : ""}  
                      multiple={ true }
                      onDone={ this.getFiles.bind(this) } />
                  </div>
                  <div className="opis">
                    <label htmlFor="opis">Dodatni opis</label>
                    <textarea
                      onBlur={this.handleBlur("opis")}
                      className={shouldMarkError("opis") ? "error" : ""}  
                      placeholder="Opis"
                      value={this.state.opis}
                      onChange={e => this.handleChange(e)}
                      type="text"
                      name="opis"              
                    />
                  </div>      
                  <div className="kreirajZivotinju">
                    <button type="button" disabled={isDisabled} onClick={this.KreirajZivotinju}>Kreiraj životinju</button>                    
                  </div>
                </form>
              </div>
            </div>
          );
        }
    }
    
