import React, { Component } from 'react'
import axios from 'axios'
import { Link, useHistory } from "react-router-dom"
import viki from "./viki.jpg"
import mini from "./mini.jpg"
import rex from "./rex.jpg"

export class Zivotinje  extends Component {
    constructor(props) {
        super(props)
        this.state = {
            Zivotinje: [],
            idOdabraneZivotinje:''
        }
    }

    componentWillMount() {
        axios.get('http://localhost:8080/zivotinje')
          .then(res => {
            const Zivotinje = res.data;
            this.setState({ Zivotinje });
        })  
    }

    udomiZivotinju = (id) => {
        let animalId = id;
        this.setState({idOdabraneZivotinje:id});  // Za odgovarajuću anketu
        this.props.history.push({
            pathname: '/admin/popuni-anketu',
            state: {
                animalId: animalId
            }
        });
    }

    renderImage = (ime) => {
        if (ime === 'Viki') {
            return (
                <img src={viki} />
            );
        }
        else if (ime === 'Rex') {
            return (
                <img src={rex} />
            );
        }
        else {
            return (
                <img src={mini} />
            );
        }
    }

    render() {
        return(
            <div className="App">
                <div className="zivotinje">
                    {this.state.Zivotinje && this.state.Zivotinje.map((zivotinja, index) => {
                        var spolTemp ="Žensko"
                        var uslov = false;
                        if (zivotinja.slika === null) uslov = true
                        var id = zivotinja.id;
                        var udomljenaTemp = "Nije udomljena"
                        if (zivotinja.spol == 'M') spolTemp = "Muško"
                        if (zivotinja.udomljena) udomljenaTemp = "Udomljena"
                        return (
                        <div className="zivotinja" key={index}>
                            <h2>{zivotinja.ime}</h2>
                            <div className="detalji">
                                <p> Vrsta: {zivotinja.vrsta}</p>
                                <p> Rasa: {zivotinja.rasa} </p>
                                <p> Godine: {zivotinja.godine}</p>
                                <p> Spol: {spolTemp}</p>
                                <p> Veličina: {zivotinja.velicina}</p>
                                <p> Težina: {zivotinja.tezina}</p>                       
                                <p> Dodatni opis: {zivotinja.dodatniOpis}</p>
                                <p> Udomljena: {udomljenaTemp}</p>
                                <div className="udomiZivotinju">
                                    <button type="button" disabled={zivotinja.udomljena} 
                                            onClick={() => this.udomiZivotinju(zivotinja.id)}>
                                            Udomi
                                    </button>  
                                </div>
                            </div>
                            <div className="slika">
                                {!uslov ? (<img src={`data:image/jpeg;base64,${zivotinja.slika}`} />) : this.renderImage(zivotinja.ime) }
                            </div>
                        </div>
                        );
                    })}
                 </div>
            </div>
        )
    }
}


//<img src={viki} alt="slika" />