import React, { Component } from 'react'
import axios from 'axios'
import {toast} from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'

toast.configure()
function validacija(ime, prezime, adresa, telefon) {
  return {
    ime: ime.length === 0,
    prezime: prezime.length === 0,
    adresa: adresa.length === 0,
    telefon: telefon.length === 0
  };
}

export class KreirajVeterinara extends Component {
    constructor(props) {
        super(props)
        this.state = {
            ime:'',
            prezime:'',
            adresa:'',
            telefon:'',
            touched: {
              ime: false,
              prezime: false,
              adresa: false,
              telefon: false,
            }
        }
    }

    handleChange = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    handleBlur = field => evt => {
      this.setState({
        touched: { ...this.state.touched, [field]: true }
      });
    };

    kreirajVeterinara = () => {   
        axios.post('http://localhost:8080/veterinari', {
            ime: this.state.ime,
            prezime: this.state.prezime,
            adresa: this.state.adresa,
            kontaktTelefon: this.state.telefon,
        }).then(response => {
          if (response.status === 200 || response.status === 201) toast.success('Veterinar uspješno kreiran', {position: toast.POSITION.TOP_RIGHT})
        }).catch(err => {
          toast.error(err.response.data.errors.toString(), {position: toast.POSITION.TOP_RIGHT})
        })
    }

    render() {
      const errors = validacija(this.state.ime, this.state.prezime, this.state.adresa, this.state.telefon);
      const isDisabled = Object.keys(errors).some(x => errors[x]);
      const shouldMarkError = field => {
      const hasError = errors[field];
      const shouldShow = this.state.touched[field];
      return hasError ? shouldShow : false;
      };
        return (
            <div className="wrapper">
              <div className="form-wrapper">
                <h1>Kreiraj veterinara</h1>
                <form>
                  <div className="ime">
                    <label htmlFor="ime">Ime</label>
                    <input
                      className={shouldMarkError("ime") ? "error" : ""}  
                      onBlur={this.handleBlur("ime")}
                      placeholder="Ime"
                      value={this.state.ime}
                      onChange={e => this.handleChange(e)}
                      type="text"
                      name="ime"             
                    />                  
                  </div>
                  <div className="prezime">
                    <label htmlFor="prezime">Prezime</label>
                    <input    
                      className={shouldMarkError("prezime") ? "error" : ""}  
                      onBlur={this.handleBlur("prezime")}              
                      placeholder="Prezime"
                      value={this.state.prezime}
                      onChange={e => this.handleChange(e)}
                      type="text"
                      name="prezime"             
                    />         
                  </div>
                  <div className="adresa">
                    <label htmlFor="adresa">Adresa ordinacije</label>
                    <input
                      className={shouldMarkError("adresa") ? "error" : ""}  
                      onBlur={this.handleBlur("adresa")}                  
                      placeholder="Adresa"
                      value={this.state.adresa}
                      onChange={e => this.handleChange(e)}
                      type="text"
                      name="adresa"             
                    />         
                  </div>
                  <div className="telefon">
                    <label htmlFor="telefon">Kontakt telefon</label>
                    <input
                      className={shouldMarkError("telefon") ? "error" : ""}  
                      onBlur={this.handleBlur("telefon")}                            
                      placeholder="Kontakt telefon"
                      value={this.state.telefon}
                      onChange={e => this.handleChange(e)}
                      type="text"
                      name="telefon"             
                    />         
                  </div>
                  <div className="kreiraj">
                    <button type="button" disabled={isDisabled} onClick={this.kreirajVeterinara}>Unesi podatke o veterinaru</button>                    
                  </div>
                </form>
              </div>
            </div>
        );
    }
}
    
