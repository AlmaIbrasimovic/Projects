package com.etf.korisnik_service.repository;

import com.etf.korisnik_service.model.Survey;
import com.etf.korisnik_service.model.User;
import com.etf.korisnik_service.model.UserSurvey;
import org.springframework.data.repository.CrudRepository;

public interface UserSurveyRepository extends CrudRepository<UserSurvey, Integer> {
    UserSurvey findBySurvey(Survey survey);
    UserSurvey findByUser(User user);
}
