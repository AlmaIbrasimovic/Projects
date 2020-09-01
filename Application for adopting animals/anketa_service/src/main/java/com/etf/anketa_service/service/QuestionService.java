package com.etf.anketa_service.service;

import com.etf.anketa_service.exception.QuestionException;
import com.etf.anketa_service.model.Question;
import com.etf.anketa_service.repository.QuestionRepository;
import net.minidev.json.JSONObject;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

@Service
public class QuestionService {
    private QuestionRepository questionRepository;

    public QuestionService(final QuestionRepository questionRepository) {
        this.questionRepository = questionRepository;
    }

    public List<Question> getAllQuestions() {
        return questionRepository.findAll();
    }

    public Question getQuestionById(Long questionId) {
        return questionRepository.findById(questionId).orElseThrow(() -> new QuestionException(questionId));
    }

    public List<Question> getQuestionsBySurveyId(Long surveyId) {
        return questionRepository.findAllBySurveyId(surveyId);
    }

    public ResponseEntity<JSONObject> deleteAllQuestions() {
        questionRepository.deleteAll();
        JSONObject returnValue = new JSONObject();
        returnValue.put("message", "Uspjesno obrisana pitanja!");
        return new ResponseEntity<>(returnValue, HttpStatus.OK);
    }

    public ResponseEntity<JSONObject> deleteSpecifiedQuestion(Long questionId) {
        JSONObject returnValue = new JSONObject();
        try {
            questionRepository.deleteById(questionId);
            returnValue.put("message", "Uspjesno obrisano pitanje!");
            return new ResponseEntity<>(returnValue, HttpStatus.OK);
        }
        catch(Exception err) {
            returnValue.put("message", err.getMessage());
            return new ResponseEntity<>(returnValue, HttpStatus.BAD_REQUEST);
        }
    }

    public Question addQuestion(Question question) {
        return questionRepository.save(question);
    }

    public List<Question> addQuestions(List<Question> questions) {
        List<Question> returnValue = new ArrayList<>();
        for (Question q: questions) {
            returnValue.add(questionRepository.save(q));
        }
        return returnValue;
    }

    public Question putQuestion(Question newQuestion, Long questionId) {
        Optional<Question> toEdit = questionRepository.findById(questionId);
        if (!toEdit.isPresent()) {
            questionRepository.save(newQuestion);
            return newQuestion;
        } else {
            toEdit.get().setSurvey(newQuestion.getSurvey());
            toEdit.get().setQuestionText(newQuestion.getQuestionText());
            toEdit.get().setMandatory(newQuestion.isMandatory());
            toEdit.get().setPossibleAnswers(newQuestion.getPossibleAnswers());
            questionRepository.save(toEdit.get());
            return toEdit.get();
        }
    }
}
