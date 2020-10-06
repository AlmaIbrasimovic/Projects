import React, {Component} from 'react'
import axios from 'axios'
import {Link,  BrowserRouter} from "react-router-dom"
import RecipeItem from '../RecipeItem'
import '../Recipes.css'

class MyRecipes extends Component {
    constructor(props) {
        super(props)
        this.state = {
            Recipes: [],
            Ingredients: []
        }
    }

    componentWillMount() {

        // To get recipes for user
        axios.get(`http://localhost:8080/user/recipes/${this.props.id}`)
            .then(res => {
                const Recipes = res.data;
                this.setState({Recipes});
            })    
    }

    render() {
        return (
            <BrowserRouter>
            <div className="App">
                <div className="my-recipes-wrapper">
                    {this.state.Recipes && this.state.Recipes.map((recipe, index) => {
                        return (
                            <div className="recipes__container__recipe" key={index}>
                                <div className="recipes__wrapper__recipe">                                
                                        <RecipeItem
                                            text={recipe.name}
                                            recipeID = {recipe.id}
                                            description = {recipe.description}
                                            path='/'                                   
                                        />                                
                                </div>
                            </div>
                        );
                    })}
                </div>
            </div>
            </BrowserRouter>
        )
    }
}


export default MyRecipes;