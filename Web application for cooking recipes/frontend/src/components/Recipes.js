import React from 'react'
import RecipeItem from './RecipeItem'
import './Recipes.css'

function Recipes() {
    return (

        <div className="recipes">
            <h1>Check out these AWESOME recipes!</h1>
            <div className="recipes__container">
                <div className="recipes__wrapper">
                    <ul className="recipes__items">
                        <RecipeItem
                            text="Amazing hamburger"
                            label="Hamburger"
                            path="/"
                        />
                        <RecipeItem
                            text="Amazing hamburger"
                            label="Hamburger"
                            path="/"
                        />
                    </ul>
                    <ul className="recipes__items">
                        <RecipeItem
                            text="Amazing hamburger"
                            label="Hamburger"
                            path="/"
                        />
                        <RecipeItem
                            text="Amazing hamburger"
                            label="Hamburger"
                            path="/"
                        />
                        <RecipeItem
                            text="Amazing hamburger"
                            label="Hamburger"
                            path="/"
                        />
                    </ul>
                </div>
            </div>
        </div>
    )

}

export default Recipes;