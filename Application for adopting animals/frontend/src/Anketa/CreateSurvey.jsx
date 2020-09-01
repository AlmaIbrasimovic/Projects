import React from 'react';
import styles from './styles/CreateSurvey.module.scss';
import { toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css'
import axios from 'axios';

toast.configure();

function validate(description, numQuestions, questionText) {
    let noEmptyStrings = true;
    for(let i = 0; i < questionText.length; i++) {
        if(questionText[i] === '') noEmptyStrings = false;
    }
    return {
        description: description.length === 0,
        numQuestions: numQuestions === 0 || numQuestions === '',
        questionText: questionText.length === 0 || !noEmptyStrings
    };
}

export default class CreateSurvey extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            description: '',
            active: true,
            animal: null,
            animalOptionsJson: null,
            animalOptions: [],
            numQuestions: 0,
            questionText: [],
            questionIds: [],
            givenAnswer1: [],
            givenAnswer2: [],
            timer: null,

            errors: {
                description: '',
                numQuestions: ''
            },

            touched: {
                description: false,
                questionText: false
            }
        }
    }

    componentDidMount() {
        axios.get(process.env.REACT_APP_GET_ANIMALS_API)
            .then(res => {
                const animalOptionsJson = res.data;
                this.setState({ animalOptionsJson });
                let animals = [];
                let animalsForSurvey = [];
                for(let i = 0; i < animalOptionsJson.length; i++) {
                    animalsForSurvey.push({
                        "id": animalOptionsJson[i].id
                    });
                    if(!animalOptionsJson[i].udomljena) {
                        animals.push(<option key={animalOptionsJson[i].id} value={animalOptionsJson[i].ime}>{animalOptionsJson[i].ime}</option>)
                    } else {
                        animalOptionsJson.splice(i, 1);
                        i--;
                    }
                }
                this.setState({ animalOptions: animals, animal: animalOptionsJson[0] });
                axios.post(process.env.REACT_APP_CREATE_ANIMALS_API, animalsForSurvey);
            }
        );
    }

    CreateSurvey = () => {  
        let dataSurvey = {
            "active": this.state.active,
            "animal": {
                "id": this.state.animal.id
            },
            "description": this.state.description,
            "surveyQuestions": []
        }
        axios.post(process.env.REACT_APP_CREATE_SURVEY_API, dataSurvey)
        .then(responseSurvey => {
            if (responseSurvey.status === 200 || responseSurvey.status === 201) {
                let data;
                for(let i = 0; i < this.state.questionText.length; i++) {
                    data = {
                        "mandatory": true,
                        "possibleAnswers": [],
                        "questionText": this.state.questionText[i],
                        "survey": {
                            "id": responseSurvey.data.id
                        }
                    };
                    if(i == this.state.questionText.length - 1) break;
                    axios.post(process.env.REACT_APP_CREATE_QUESTION_API, data).then(
                        response => {
                            let questionIdsUpdated = this.state.questionIds;
                            questionIdsUpdated.push(response.data.id);
                            this.setState({questionIds: questionIdsUpdated});
                        }
                    );
                }
                axios.post(process.env.REACT_APP_CREATE_QUESTION_API, data)
                .then(responseQuestion => {
                    if (responseQuestion.status === 200 || responseQuestion.status === 201) {    
                        let questionIdsUpdated = this.state.questionIds
                        questionIdsUpdated.push(responseQuestion.data.id);
                        this.setState({questionIds: questionIdsUpdated});                        
                        let possibleAnswerData;
                        let answerIndex = 0;
                        console.log(this.state.questionIds.length);
                        console.log(this.state.givenAnswer1);
                        console.log(this.state.givenAnswer2);
                        for(let i = 0; i < this.state.questionIds.length; i++) {
                            possibleAnswerData = {
                                "answer": this.state.givenAnswer1[answerIndex],
                                "points": 1,
                                "question": {
                                    "id": this.state.questionIds[i]
                                },
                                "givenAnswers": []
                            };
                            console.log(possibleAnswerData);
                            axios.post(process.env.REACT_APP_CREATE_POSSIBLE_ANSWER_API, possibleAnswerData);
                            possibleAnswerData = {
                                "answer": this.state.givenAnswer2[answerIndex],
                                "points": 1,
                                "question": {
                                    "id": this.state.questionIds[i]
                                },
                                "givenAnswers": []
                            };
                            if(i == this.state.questionIds.length - 1) break;
                            axios.post(process.env.REACT_APP_CREATE_POSSIBLE_ANSWER_API, possibleAnswerData)
                            answerIndex++;
                        }
                        console.log(possibleAnswerData);
                        axios.post(process.env.REACT_APP_CREATE_POSSIBLE_ANSWER_API, possibleAnswerData)
                        .then(response => {
                            if (response.status === 200 || response.status === 201) {
                                toast.success('Anketa uspješno kreirana', {position: toast.POSITION.TOP_RIGHT})
                            }
                        }).catch(err => {
                            toast.error(err.toString(), {position: toast.POSITION.TOP_RIGHT})
                        })
                    }                  
                }).catch(err => {
                    toast.error(err.toString(), {position: toast.POSITION.TOP_RIGHT})
                });
            }
        }).catch(err => {
            toast.error(err.toString(), {position: toast.POSITION.TOP_RIGHT})
        });
    }

    handleChange = (e) => {
        this.setState({
            [e.target.name] : e.target.value
        });
    }

    handleActive = (e) => {
        this.setState({
            active : (e.target.value === "Da") ? true : false
        });
    }

    handleSelectAnimal = (selectedOption) => {
        if (selectedOption) {
            let selectedAnimal = null;
            for(let i = 0; i < this.state.animalOptionsJson.length; i++) {
                if(selectedOption.target.value == this.state.animalOptionsJson[i].ime) {
                    selectedAnimal = this.state.animalOptionsJson[i];
                }
            }
            this.setState({ 
                animal : selectedAnimal
            });           
        }
    }

    updateQuestionText = (text) => {
        let updatedQuestions = this.state.questionText;
        updatedQuestions.push(text);
        this.setState({
            questionText : updatedQuestions
        });
    }

    handleQuestionTextEntered = (e) => {
        var self = this;
        let text = e.target.value;
        if(self.state.timer) {
            clearTimeout(self.state.timer);
        }
        self.setState({
            timer: setTimeout(function () {
                self.updateQuestionText(text);
            }, 1000)
        });
    }

    updateGivenAnswer1 = (text) => {
        let updatedGivenAnswers = this.state.givenAnswer1;
        updatedGivenAnswers.push(text);
        this.setState({
            givenAnswer1: updatedGivenAnswers
        });
    }

    updateGivenAnswer2 = (text) => {
        let updatedGivenAnswers = this.state.givenAnswer2;
        updatedGivenAnswers.push(text);
        this.setState({
            givenAnswer2: updatedGivenAnswers
        });
    }

    handleGivenAnswer1Entered = (e) => {
        var self = this;
        let answer = e.target.value;
        if(self.state.timer) {
            clearTimeout(self.state.timer);
        }
        self.setState({
            timer: setTimeout(function () {
                self.updateGivenAnswer1(answer);
            }, 1000)
        });
    }

    handleGivenAnswer2Entered = (e) => {
        var self = this;
        let answer = e.target.value;
        if(self.state.timer) {
            clearTimeout(self.state.timer);
        }
        self.setState({
            timer: setTimeout(function () {
                self.updateGivenAnswer2(answer);
            }, 1000)
        });
    }

    handleBlur = field => evt => {
        this.setState({
        touched : { ...this.state.touched, [field]: true }
        });
    };

    renderQuestions = (value) => {
        const errors = validate(this.state.description, this.state.numQuestions, this.state.questionText);
        const shouldMarkError = field => {
            const hasError = errors[field];
            const shouldShow = this.state.touched[field];
            return hasError ? shouldShow : false;
        };

        let questions = [];
        for(let i = 0; i < value; i++) {
            questions.push(
                <div key={i} className={styles.keyDiv}>
                    <div className={styles.question}>
                        <label className={styles.questionLabel}>Pitanje {i + 1}</label>
                        <br/>
                        <label className={styles.questionTextLabel}>Unesi tekst pitanja</label>
                        <br/>
                        <input
                            className={shouldMarkError("questionText") ? "error" : styles.questionText}
                            id={i}                
                            placeholder="Tekst pitanja"
                            type="text"
                            onBlur={this.handleBlur("questionText")}
                            onChange={e => this.handleQuestionTextEntered(e)}
                            name="questionText"
                        />
                        <br/> <br/>
                        <label className={styles.questionTextLabel}>Unesi ponuđene odgovore</label>
                        <br/>
                        <input
                            className={shouldMarkError("givenAnswer1") ? "error" : styles.givenAnswer1}
                            id={'gA' + i}                
                            placeholder="Prvi ponuđeni odgovor"
                            type="text"
                            onBlur={this.handleBlur("givenAnswer1")}
                            onChange={e => this.handleGivenAnswer1Entered(e)}
                            name="givenAnswer1"
                        />
                        <input
                            className={shouldMarkError("givenAnswer2") ? "error" : styles.givenAnswer2}
                            id={'gA2' + i}                
                            placeholder="Drugi ponuđeni odgovor"
                            type="text"
                            onBlur={this.handleBlur("givenAnswer2")}
                            onChange={e => this.handleGivenAnswer2Entered(e)}
                            name="givenAnswer2"
                        />
                    </div>
                    <br/>
                </div>
            );
        }
        return questions;
    }

    render() {
        const errors = validate(this.state.description, this.state.numQuestions, this.state.questionText);
        const isDisabled = Object.keys(errors).some(x => errors[x]);
        const shouldMarkError = field => {
            const hasError = errors[field];
            const shouldShow = this.state.touched[field];
            return hasError ? shouldShow : false;
        };

        return (
            <div className={styles.wrapper}>
                <div className={styles.formWrapper}>
                    <h1 className={styles.header}>Kreiraj anketu</h1>
                    <form className={styles.createSurveyForm}>
                        <div className={styles.desc}>
                            <label className={styles.opisLabel}>Opis</label>
                            <br/>
                            <textarea
                            className={shouldMarkError("description") ? "error" : styles.description}
                            onBlur={this.handleBlur("description")}
                            onChange={e => this.handleChange(e)}
                            placeholder="Opis"
                            type="text"
                            name="description"
                            />                  
                        </div>
                        <div className={styles.active}>
                            <br/>
                            <label className={styles.activeLabel}>Aktivna</label>
                            <br/>
                            <div className={styles.radioGroup}>
                                <label className={styles.radioGroupLabel}>
                                    <input 
                                    className={styles.isActive}
                                    type="radio"
                                    value="Da"
                                    name="active"
                                    label="Da"
                                    defaultChecked={true}
                                    onChange={e => this.handleActive(e)}
                                    />
                                    Da
                                </label>
                                <label className={styles.radioGroupLabel}>
                                    <input 
                                    className={styles.isActive}
                                    type="radio"
                                    value="Ne"
                                    name="active"
                                    label="Ne"
                                    onChange={e => this.handleActive(e)}
                                    />
                                    Ne
                                </label>
                            </div>
                        </div>
                        <div className={styles.chooseAnimal}>
                            <br/>
                            <label className={styles.chooseLabel}>Izaberi životinju</label>
                            <br/>
                            <select 
                            className={styles.picker}
                            name="animal"
                            onChange={
                                (e) => {
                                    this.handleSelectAnimal(e);
                                }
                            }
                            >
                                {this.state.animalOptions}
                            </select>
                        </div>
                        <div className={styles.questionNum}>
                            <br/>
                            <label className={styles.chooseQuestions}>Unesi broj pitanja</label>
                            <br/>
                            <input 
                                className={styles.numQuestions}
                                onBlur={this.handleBlur("numQuestions")}
                                onChange={e => this.handleChange(e)}
                                type="number"
                                name="numQuestions"
                                />
                            <br/>
                        </div>
                        {(this.state.numQuestions !== '' && this.state.numQuestions > 0) ? 
                            <div className={styles.questions}>
                                {this.renderQuestions(this.state.numQuestions)}
                            </div> : 
                            <></>
                        }
                        <div className={styles.createSurvey}>
                            <button 
                            className={styles.createSurveyButton}
                            type="button" 
                            disabled={isDisabled} 
                            onClick={this.CreateSurvey}>Kreiraj anketu</button>                    
                        </div>
                    </form>
                </div>
            </div>
        );
    }
} 
