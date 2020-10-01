import React, {Component} from 'react'
import {Link, Router, BrowserRouter} from "react-router-dom"
import './Recipes.css'
import hamburger from '../assets/img/hamburger.jpg'
import Signin from './pages/Signin'
import {render} from 'react-dom'
import Modal from 'react-modal'
import CloseIcon from '@material-ui/icons/Close';
import Button from '@material-ui/core/Button';

export class RecipeItem extends Component {
    constructor(props) {
        super(props)
        this.state = {
            modalIsOpen: false
        }
    }

    showDetails = () => {
        this.setState({modalIsOpen: true})
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
                            <Modal isOpen={this.state.modalIsOpen} className ="modal">
                                <div>
                                    <Button
                                        onClick={() => this.setState({modalIsOpen: false})}                                       
                                        variant="contained"
                                        color="secondary"
                                        >
                                        x
                                    </Button>
                                </div>
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
