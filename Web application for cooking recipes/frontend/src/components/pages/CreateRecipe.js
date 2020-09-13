import React, {Component} from 'react';
import './css/CreateRecipe.css';

export default class CreateRecipe extends React.Component {
    constructor(props) {
        super(props)
        this.state = {}
    }

    render() {
        return (
            <div className="wrapper">
                <div className="form-wrapper">
                    <h1>Kreiraj životinju</h1>
                    <form>
                        <div className="Ime">
                            <label htmlFor="Ime">Ime</label>
                            <input
                                placeholder="Ime"
                                value={this.state.Ime}
                                type="text"
                                name="Ime"
                            />
                        </div>
                        <div className="vrsta">
                            <label htmlFor="vrsta">Vrsta životinje</label>
                            <input
                                placeholder="Vrsta životinje"
                                value={this.state.vrsta}
                                type="text"
                                name="vrsta"
                            />
                        </div>
                        <div className="rasa">
                            <label htmlFor="rasa">Rasa</label>
                            <input
                                placeholder="Rasa"
                                type="text"
                                name="rasa"
                            />
                        </div>
                        <div className="godine">
                            <label htmlFor="godine">Godine</label>
                            <input
                                placeholder="Godine"
                                type="number"
                                name="godine"
                            />
                        </div>
                        <div className="tezina">
                            <label htmlFor="tezina">Težina</label>
                            <input
                                placeholder="Težina"
                                type="number"
                                name="tezina"
                            />
                        </div>
                        <div className="opis">
                            <label htmlFor="opis">Dodatni opis</label>
                            <textarea
                                placeholder="Opis"
                                value={this.state.opis}
                                type="text"
                                name="opis"
                            />
                        </div>
                        <div className="kreirajZivotinju">
                            <button type="button">Kreiraj životinju</button>
                        </div>
                    </form>
                </div>
            </div>
        );
    }
}