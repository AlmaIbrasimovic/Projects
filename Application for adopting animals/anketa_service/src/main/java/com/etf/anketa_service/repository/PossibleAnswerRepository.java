package com.etf.anketa_service.repository;

import com.etf.anketa_service.model.PossibleAnswer;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface PossibleAnswerRepository extends JpaRepository<PossibleAnswer, Long> {
    List<PossibleAnswer> findAllByQuestion_SurveyId(Long surveyId);
    Optional<PossibleAnswer> findById(Long id);
}
