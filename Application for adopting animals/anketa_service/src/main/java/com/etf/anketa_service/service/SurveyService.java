package com.etf.anketa_service.service;

import com.etf.anketa_service.exception.SurveyException;
import com.etf.anketa_service.model.Survey;
import com.etf.anketa_service.repository.SurveyRepository;
import net.minidev.json.JSONObject;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class SurveyService {
    private SurveyRepository surveyRepository;

    public SurveyService(SurveyRepository surveyRepository) {
        this.surveyRepository = surveyRepository;
    }

    public Survey addSurvey(Survey survey) {
        return surveyRepository.save(survey);
    }

    public Survey getSurveyByAnimalId(Long animalId) {
        return surveyRepository.findByAnimalId(animalId);
    }

    public List<Survey> getAllSurveys() {
        return surveyRepository.findAll();
    }

    public Survey getSurveyById(Long id) {
        return surveyRepository.findById(id).orElseThrow(() -> new SurveyException(id));
    }

    public List<Survey> getByActiveStatus(boolean active) {
        return surveyRepository.getAllByActiveEquals(active);
    }

    public ResponseEntity<JSONObject> deleteAll() {
        surveyRepository.deleteAll();
        JSONObject returnValue = new JSONObject();
        returnValue.put("message", "Uspjesno obrisane ankete!");
        return new ResponseEntity<>(returnValue, HttpStatus.OK);
    }

    public ResponseEntity<JSONObject> deleteSpecifiedSurvey(Long surveyId) {
        JSONObject returnValue = new JSONObject();
        try {
            surveyRepository.deleteById(surveyId);
            returnValue.put("message", "Uspjesno obrisana anketa!");
            return new ResponseEntity<>(returnValue, HttpStatus.OK);
        }
        catch(Exception err) {
            returnValue.put("message", err.getMessage());
            return new ResponseEntity<>(returnValue, HttpStatus.BAD_REQUEST);
        }
    }

    public Survey putSurvey(Survey newSurvey, Long idSurvey) {
        Optional<Survey> toEdit = surveyRepository.findById(idSurvey);
        if(!toEdit.isPresent()) {
            surveyRepository.save(newSurvey);
            return newSurvey;
        }
        else {
            toEdit.get().setSurveyQuestions(newSurvey.getSurveyQuestions());
            toEdit.get().setActive(newSurvey.isActive());
            toEdit.get().setAnimal(newSurvey.getAnimal());
            toEdit.get().setDescription(newSurvey.getDescription());
            surveyRepository.save(toEdit.get());
            return toEdit.get();
        }
    }
}
