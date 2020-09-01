package com.etf.anketa_service.controller;

import com.etf.anketa_service.model.Question;
import com.etf.anketa_service.service.QuestionService;
import net.minidev.json.JSONObject;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import javax.validation.Valid;
import java.util.List;

@RequestMapping(path = "/v1/question")
@RestController
public class QuestionController {
    private QuestionService questionService;

    public QuestionController(final QuestionService questionService) {
        this.questionService = questionService;
    }

    @GetMapping(path = "/getAll")
    List<Question> getAllQuestions() {
        return questionService.getAllQuestions();
    }

    @GetMapping(path = "/getById")
    Question getSpecifiedQuestion(@RequestParam(name = "id", required = true) Long id) {
        return questionService.getQuestionById(id);
    }

    @GetMapping(path = "/getBySurvey")
    List<Question> getQuestionsBySurveyId(Long surveyId) {
        return questionService.getQuestionsBySurveyId(surveyId);
    }

    @DeleteMapping(path = "deleteAll")
    ResponseEntity<JSONObject> deleteAllQuestions() {
        return questionService.deleteAllQuestions();
    }

    @DeleteMapping(path = "/deleteById")
    ResponseEntity<JSONObject> deleteSpecifiedQuestion(@RequestParam(name = "id", required = true) Long id) {
        return questionService.deleteSpecifiedQuestion(id);
    }

    @PostMapping
    Question addQuestion(@Valid @RequestBody Question question) {
        return questionService.addQuestion(question);
    }

    @PostMapping(path = "/addMultiple")
    List<Question> addQuestions(@RequestBody List<Question> questions) {
        return questionService.addQuestions(questions);
    }

    @PutMapping
    Question editQuestion(@Valid @RequestBody Question newQuestion, @RequestParam(name = "id", required = true) Long questionId) {
        return questionService.putQuestion(newQuestion, questionId);
    }
}
