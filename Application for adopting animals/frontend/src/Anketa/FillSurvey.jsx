import React from 'react';
import styles from './styles/CreateSurvey.module.scss';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'
import axios from 'axios';

toast.configure();

export default class FillSurvey extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            animalId: this.props.location.state.animalId,
            chosenAnswers: [],
            survey: null,
            animal: null
        }
    }

    componentDidMount() {
        console.log(this.state);
        axios.get(process.env.REACT_APP_GET_SURVEY_ANIMAL_API, { params: { animalId: this.state.animalId } })
        .then(res => {
            this.setState({survey: res.data});
        });
        axios.get(process.env.REACT_APP_GET_ANIMALS_API)
            .then(res => {
                const animalOptionsJson = res.data;
                for(let i = 0; i < animalOptionsJson.length; i++) {
                    if (animalOptionsJson[i].id == this.state.animalId) {
                        this.setState({ animal: animalOptionsJson[i] });
                        break;
                    }
                }
                toast.success('Životinja je uspješno udomljena!', {position: toast.POSITION.TOP_RIGHT});
            }
        );
    }

    render() {
        return(
            <div>
                <div>
                    <label>{this.state.survey}</label>
                </div>
            </div>
        );
    }
} 
