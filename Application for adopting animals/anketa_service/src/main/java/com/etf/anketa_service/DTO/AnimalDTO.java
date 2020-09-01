package com.etf.anketa_service.DTO;

import com.etf.anketa_service.model.Animal;
import com.etf.anketa_service.model.Survey;

import java.util.ArrayList;
import java.util.List;

public class AnimalDTO {
    private List<Long> surveyIds;

    public AnimalDTO() {}

    public AnimalDTO(List<Long> surveyIds) {
        this.surveyIds = surveyIds;
    }

    public AnimalDTO(Animal animal) {
        surveyIds = new ArrayList<>();
        for(final Survey survey : animal.getSurveys()) {
            surveyIds.add(survey.getId());
        }
    }

    public Animal toEntity() {
        return new Animal();
    }

    public List<Long> getSurveyIds() {
        return surveyIds;
    }

    public void setSurveyIds(List<Long> surveyIds) {
        this.surveyIds = surveyIds;
    }
}
