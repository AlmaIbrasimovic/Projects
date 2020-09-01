package com.etf.korisnik_service.model;

import javax.persistence.*;

@Entity
@Table(name = "Survey")
public class Survey {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;
    private Integer surveyId;
    private Boolean gotAnimal;

    public Survey() {}

    public Survey(Integer surveyId, Boolean gotAnimal) {
        this.surveyId = surveyId;
        this.gotAnimal = gotAnimal;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getSurveyId() {
        return surveyId;
    }

    public void setSurveyId(Integer surveyId) {
        this.surveyId = surveyId;
    }

    public Boolean getGotAnimal() {
        return gotAnimal;
    }

    public void setGotAnimal(Boolean gotAnimal) {
        this.gotAnimal = gotAnimal;
    }
}
