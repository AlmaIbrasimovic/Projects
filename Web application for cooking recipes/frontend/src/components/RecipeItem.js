import React from 'react'
import {Link} from 'react-router-dom'
import './Recipes.css'
import hamburger from '../assets/img/hamburger.jpg'

function RecipeItem(props) {
    return (
        <>
            <li className="recipes__item">
                <Link className="recipes__item__link" to={props.path}>
                    <figure className="recipes__item__pic-wrap" data-category={props.label}>
                        <img
                            src={hamburger}
                            alt='Recipe image'
                            className="recipes__item__img">
                        </img>
                    </figure>
                    <div className="recipes__item__info">
                        <h5 className="recipes__item__text">
                            {props.text}
                        </h5>
                    </div>
                </Link>
            </li>
        </>
    )
}

export default RecipeItem