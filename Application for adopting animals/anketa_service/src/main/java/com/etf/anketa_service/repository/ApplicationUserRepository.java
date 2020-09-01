package com.etf.anketa_service.repository;

import com.etf.anketa_service.model.ApplicationUser;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

@Repository
public interface ApplicationUserRepository extends JpaRepository<ApplicationUser, Long> {
    @Query(value = "SELECT SUM(pa.points) FROM possible_answer pa, answer a, question q, application_user au, survey s WHERE au.id = ?1 AND s.id = ?2 AND au.id = a.user_id AND a.possible_answer_id = pa.id AND pa.question_id = q.id AND q.survey_id = s.id", nativeQuery = true)
    Long getPointsForSpecifiedSurvey(Long applicationUserId, Long surveyId);
}
