import React, {Component} from 'react';
import axios from 'axios'
import './css/CreateRecipe.css';
import TextField from '@material-ui/core/TextField';
import {withStyles} from '@material-ui/core';
import {toast} from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'
import clsx from 'clsx';
import {borders} from '@material-ui/system';
import DeleteIcon from '@material-ui/icons/Delete';
import Button from '@material-ui/core/Button';
import AddIcon from '@material-ui/icons/Add';
import RemoveIcon from '@material-ui/icons/Remove';
import IconButton from '@material-ui/core/IconButton';

toast.configure()

const useStyles = (theme) => ({
    root: {
        height: '89.5vh',
        display: 'flex',
        flexWrap: 'wrap',

    },
    textField: {
        width: '25%',
        margin: theme.spacing(-1.8, 4)

    },
    IngredientTextField: {
        width: '28%',
        margin: theme.spacing(1, 2.9)

    },
    button: {}
});

export class CreateRecipe extends Component {
    constructor(props) {
        super(props)
        this.state = {
            Ingredients: [
                {Name: "", Quantity: "", Unit: ""}
            ],
            name: '',
            type: '',
            description: '',
            Name: "",
            Quantity: "",
            Unit: ""
        }
    }

    handleChange = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    handleInputChange = (e, index) => {
        const {name, value} = e.target;
        const list = [...this.state.Ingredients];
        list[index][name] = value;
        this.setState({Ingredients: list})
    }

    handleAddClick = (e) => {
        this.setState((prevState) => ({
            Ingredients: [...prevState.Ingredients, {Name: "", Quantity: "", Unit: ""}]
        }));
    }

    deteteRow = (index) => {
        this.setState({
            Ingredients: this.state.Ingredients.filter((s, sindex) => index !== sindex),
        });
        // const taskList1 = [...this.state.taskList];
        // taskList1.splice(index, 1);
        // this.setState({ taskList: taskList1 });
    }

    createRecipe = () => {
        axios.post('http://localhost:8080/recipe', {
            type: this.state.type,
            name: this.state.name,
            description: this.state.description
        }).then(response => {
            if (response.status === 200 || response.status === 201) toast.success("Recipe created successfully", {position: toast.POSITION.TOP_RIGHT})
        }).catch(err => {
            console.log(this.state.Ingredients)
            var error = '';
            for (var i = 0; i < err.response.data.errors.length; i++) {
                error += err.response.data.errors[i] + "\n";
            }
            toast.error(error, {position: toast.POSITION.TOP_RIGHT})
        })
    }

    render() {
        const {classes} = this.props;

        return (
            <div className="create-recipe-container">
                <form>
                    <TextField
                        variant="filled"
                        margin='normal'
                        required
                        className={clsx(classes.textField)}
                        id="name"
                        label="Name"
                        name="name"
                        value={this.state.name}
                        onChange={e => this.handleChange(e)}
                    />
                    <TextField
                        variant="filled"
                        margin='normal'
                        required
                        className={clsx(classes.textField)}
                        width="75%"
                        id="type"
                        label="Type"
                        name="type"
                        value={this.state.type}
                        onChange={e => this.handleChange(e)}
                        InputProps={{
                            classes: {
                                textField: classes.textField
                            }
                        }}
                    />
                    <TextField
                        variant="filled"
                        margin='normal'
                        required
                        id="standard-multiline-flexible"
                        multiline
                        className={clsx(classes.textField)}
                        rowsMax={10}
                        width="75%"
                        id="description"
                        label="Description"
                        name="description"
                        value={this.state.description}
                        onChange={e => this.handleChange(e)}
                    />
                    <div className="create-recipe-ingredients-container">
                        <h2>Ingredients</h2>
                        {this.state.Ingredients.map((x, i) => {
                            return (
                                <div className="box">
                                    <TextField
                                        variant="filled"
                                        margin='normal'
                                        required
                                        className={clsx(classes.IngredientTextField)}
                                        id="Name"
                                        label="Name"
                                        name="Name"
                                        value={x.Name}
                                        onChange={e => this.handleInputChange(e, i)}
                                    />
                                    <TextField
                                        variant="filled"
                                        margin='normal'
                                        required
                                        className={clsx(classes.IngredientTextField)}
                                        id="Quantity"
                                        label="Quantity"
                                        name="Quantity"
                                        value={x.Quantity}
                                        onChange={e => this.handleInputChange(e, i)}
                                    />
                                    <TextField
                                        variant="filled"
                                        margin='normal'
                                        required
                                        className={clsx(classes.IngredientTextField)}
                                        id="Quantity"
                                        label="Unit"
                                        name="Unit"
                                        value={x.Unit}
                                        onChange={e => this.handleInputChange(e, i)}
                                    />
                                    <div className="btn-box">
                                        {this.state.Ingredients.length - 1 === i &&
                                        <IconButton
                                            onClick={this.handleAddClick}>
                                            <AddIcon/>                                           
                                        </IconButton>}
                                        {this.state.Ingredients.length !== 1 &&
                                        <IconButton
                                            onClick={() => this.deteteRow(i)}>
                                            <RemoveIcon/>                                           
                                        </IconButton>}
                                    </div>
                                </div>
                            );
                        })}
                    </div>
                    <div className="create-recipe-button">
                        <button type="button" onClick={this.createRecipe}>CreateRecipe</button>
                    </div>
                </form>
            </div>
        );
    }
}

export default withStyles(useStyles)(CreateRecipe);