package com.etf.korisnik_service.service;

import com.etf.korisnik_service.model.Survey;
import com.etf.korisnik_service.repository.SurveyRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class SurveyService {
    @Autowired
    private SurveyRepository surveyRepository;

    public void upisiAnketu(Survey survey) {
        surveyRepository.save(survey);
    }
}
