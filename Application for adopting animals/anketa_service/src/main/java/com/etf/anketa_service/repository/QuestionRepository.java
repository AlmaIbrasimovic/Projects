package com.etf.anketa_service.repository;

import com.etf.anketa_service.model.Question;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface QuestionRepository extends JpaRepository<Question, Long> {
    Optional<Question> findById(Long id);
    List<Question> findAllBySurveyId(Long surveyId);
}
