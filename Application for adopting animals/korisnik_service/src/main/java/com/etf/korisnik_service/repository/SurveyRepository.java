package com.etf.korisnik_service.repository;

import com.etf.korisnik_service.model.Survey;
import org.springframework.data.repository.CrudRepository;

public interface SurveyRepository extends CrudRepository<Survey, Integer> {
}
