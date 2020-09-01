package com.etf.korisnik_service.controller;

import com.etf.korisnik_service.DTO.UserSurveyDTO;
import com.etf.korisnik_service.model.User;
import com.etf.korisnik_service.service.UserSurveyService;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import javax.validation.Valid;

@RestController
public class UserSurveyController {

    private UserSurveyService userSurveyService;

    public UserSurveyController(UserSurveyService userSurveyService) {
        this.userSurveyService = userSurveyService;
    }

    @PostMapping("/user_survey/exists")
    public User postojilKorisnik(@RequestBody @Valid UserSurveyDTO userSurvey) throws Exception {
        return userSurveyService.provjeriUsera(userSurvey);
    }

}
