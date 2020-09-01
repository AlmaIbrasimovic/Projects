import React, { Component } from 'react'
import axios from 'axios'
import {toast} from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'

toast.configure()
function validacija(ime, lijek) {
  return {
    ime: ime.length === 0,
    lijek: lijek.length === 0,
  };
}

export class KreirajBolest extends Component {
    constructor(props) {
        super(props)
        this.state = {
            ime:'',
            lijek:'',
            touched: {
              ime: false,
              lijek: false,
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

    kreirajVakcinu = () => {   
        axios.post('http://localhost:8080/bolesti', {
            ime: this.state.ime,
            lijek: this.state.lijek,
        }).then(response => {
          if (response.status === 200 || response.status === 201) toast.success('Bolest uspješno kreirana', {position: toast.POSITION.TOP_RIGHT})
        }).catch(err => {
          toast.error(err.response.data.errors.toString(), {position: toast.POSITION.TOP_RIGHT})
        })
    }

    render() {
      const errors = validacija(this.state.ime, this.state.lijek);
      const isDisabled = Object.keys(errors).some(x => errors[x]);
      const shouldMarkError = field => {
      const hasError = errors[field];
      const shouldShow = this.state.touched[field];
      return hasError ? shouldShow : false;
      };
        return (
            <div className="wrapper">
              <div className="form-wrapper">
                <h1>Kreiraj bolest</h1>
                <form>
                  <div className="ime">
                    <label htmlFor="ime">Ime bolesti</label>
                    <input 
                      placeholder="Ime"
                      className={shouldMarkError("ime") ? "error" : ""}
                      onBlur={this.handleBlur("ime")}  
                      value={this.state.ime}
                      onChange={e => this.handleChange(e)}
                      type="text"
                      name="ime"             
                    />                  
                  </div>
                  <div className="lijek">
                    <label htmlFor="lijek">Lijek</label>
                    <input
                      className={shouldMarkError("lijek") ? "error" : ""}
                      onBlur={this.handleBlur("lijek")}                  
                      placeholder="Lijek"
                      value={this.state.lijek}
                      onChange={e => this.handleChange(e)}
                      type="text"
                      name="lijek"             
                    />         
                  </div>
                  <div className="kreiraj">
                    <button type="button" disabled={isDisabled} onClick={this.kreirajVakcinu}>Kreiraj bolest</button>                    
                  </div>
                </form>
              </div>
            </div>
        );
    }
}
    
