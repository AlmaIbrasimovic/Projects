import React, {Component} from 'react'
import {Link, Router, BrowserRouter} from "react-router-dom"
import './Recipes.css'
import hamburger from '../assets/img/hamburger.jpg'
import Signin from './pages/Signin'
import {render} from 'react-dom'
import Modal from 'react-modal'
import CloseIcon from '@material-ui/icons/Close';
import Button from '@material-ui/core/Button';
import axios from 'axios'

export class RecipeItem extends Component {
    constructor(props) {
        super(props)
        this.state = {
            modalIsOpen: false,
            modalOptions: [],
            Ingredients: []
        }
    }

    showDetails = () => {
        this.setState({modalIsOpen: true})

        // To get ingredients for recipes
        axios.get(`http://localhost:8080/recipe/ingredients/${this.props.recipeID}`)
            .then(res => {
                const Ingredients = res.data;
                this.setState({Ingredients});
            })

        /* const options = {
             title: {
                 text: this.props.text

             },
             data: this.state.Ingredients
         }
         this.setState({modalOptions : options})*/

    }

    render() {
        return (
            <li className="recipes__item">
                <div className='recipes__item__link'>
                    <div className="recipes__item__link">
                        <figure className="recipes__item__pic-wrap">
                            <img
                                src={hamburger}
                                alt='Recipe image'
                                className="recipes__item__img">
                            </img>
                            <a>
                                <button class="btnA" onClick={this.showDetails}>Read more</button>
                            </a>
                            <Modal isOpen={this.state.modalIsOpen} className="modal">
                                <Button
                                    onClick={() => this.setState({modalIsOpen: false})}
                                    variant="contained"
                                    color="secondary"
                                >
                                    x
                                </Button>
                                <h2>{this.props.text}</h2>
                                <h3>Ingredients:</h3>
                                {this.state.Ingredients && this.state.Ingredients.map((ingredients, index) => {
                                    return (
                                        <h6>{ingredients.name + ", " + ingredients.quantity + ingredients.unit}</h6>);
                                })}
                                <h3>Preparation:</h3>
                                <h6>{this.props.description}</h6>
                            </Modal>

                        </figure>
                        <div className="recipes__item__info">
                            <h5 className="recipes__item__text">
                                {this.props.text}
                            </h5>
                        </div>
                    </div>
                </div>
            </li>
        );
    }
}

export default RecipeItem;
