package com.etf.korisnik_service.DTO;


import javax.validation.constraints.NotNull;

public class UserSurveyDTO {
    @NotNull
    Integer userId;
    @NotNull
    Integer surveyId;
    Boolean gotAnimal;

    public UserSurveyDTO(@NotNull Integer userId, @NotNull Integer surveyId, Boolean gotAnimal) {
        this.userId = userId;
        this.surveyId = surveyId;
        this.gotAnimal = gotAnimal;
    }

    public Integer getUserId() {
        return userId;
    }

    public void setUserId(Integer userId) {
        this.userId = userId;
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
