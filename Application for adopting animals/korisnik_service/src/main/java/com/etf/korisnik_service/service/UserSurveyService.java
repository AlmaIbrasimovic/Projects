package com.etf.korisnik_service.service;

import com.etf.korisnik_service.DTO.UserSurveyDTO;
import com.etf.korisnik_service.model.Survey;
import com.etf.korisnik_service.model.User;
import com.etf.korisnik_service.model.UserSurvey;
import com.etf.korisnik_service.repository.UserSurveyRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class UserSurveyService {

    @Autowired
    private UserSurveyRepository userSurveyRepository;
    @Autowired
    private SurveyService surveyService;
    @Autowired
    private UserService userService;

    public User provjeriUsera(UserSurveyDTO userSurvey) throws  Exception {
        User user = userService.getUserById(userSurvey.getUserId());
        Survey survey = new Survey(userSurvey.getSurveyId(),false); //eidtovat poslije
        surveyService.upisiAnketu(survey);
        UserSurvey newUserSurvey = new UserSurvey(user,survey);
        userSurveyRepository.save(newUserSurvey);
        return user;
    }

}
