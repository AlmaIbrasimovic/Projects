import React, { Component } from 'react'
import axios from 'axios'
import {toast} from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'

toast.configure()

function validacija(tip, revakcinacija) {
  return {
    tip: tip.length === 0,
    revakcinacija: revakcinacija.length === 0,
  };
}

export class KreirajVakcinu extends Component {
    constructor(props) {
        super(props)
        this.state = {
            tip:'',
            revakcinacija:'',
            touched: {
              revakcinacija: false,
              tip: false,
            }
        }
    }

    handleChange = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    kreirajVakcinu = () => {   
        axios.post('http://localhost:8080/vakcine', {
            tip: this.state.tip,
            revakcinacija: Number(this.state.revakcinacija),
        }).then(response => {
          if (response.status === 200 || response.status === 201) toast.success('Vakcina uspješno kreirana', {position: toast.POSITION.TOP_RIGHT})
        }).catch(err => {
          toast.error(err.response.data.errors.toString(), {position: toast.POSITION.TOP_RIGHT})
        })
    }

    handleBlur = field => evt => {
      this.setState({
        touched: { ...this.state.touched, [field]: true }
      });
    };

    render() {
      const errors = validacija(this.state.tip, this.state.revakcinacija);
      const isDisabled = Object.keys(errors).some(x => errors[x]);
      const shouldMarkError = field => {
      const hasError = errors[field];
      const shouldShow = this.state.touched[field];
      return hasError ? shouldShow : false;
      };

        return (
            <div className="wrapper">
              <div className="form-wrapper">
                <h1>Kreiraj vakcinu</h1>
                <form>
                  <div className="tip">
                    <label htmlFor="tip">Tip vakcine</label>
                    <input 
                      className={shouldMarkError("tip") ? "error" : ""}  
                      placeholder="Tip"
                      value={this.state.tip}
                      onChange={e => this.handleChange(e)}
                      onBlur={this.handleBlur("tip")}
                      type="text"
                      name="tip"             
                    />                  
                  </div>
                  <div className="revakcinacija">
                    <label htmlFor="revakcinacija">Period revakcinacije (mjeseci)</label>
                    <input     
                      className={shouldMarkError("revakcinacija") ? "error" : ""}               
                      placeholder="Revakcinacija"
                      value={this.state.revakcinacija}
                      onChange={e => this.handleChange(e)}
                      onBlur={this.handleBlur("revakcinacija")}
                      type="number"
                      name="revakcinacija"             
                    />         
                  </div>
                  <div className="kreiraj">
                    <button type="button" disabled={isDisabled} onClick={this.kreirajVakcinu}>Kreiraj vakcinu</button>                    
                  </div>
                </form>
              </div>
            </div>
        );
    }
}
    
