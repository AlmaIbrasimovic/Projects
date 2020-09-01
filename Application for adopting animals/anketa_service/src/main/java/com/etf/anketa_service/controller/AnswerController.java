package com.etf.anketa_service.controller;

import com.etf.anketa_service.model.Answer;
import com.etf.anketa_service.service.AnswerService;
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

@RequestMapping(path = "/v1/answer")
@RestController
public class AnswerController {
    private AnswerService answerService;

    public AnswerController(final AnswerService answerService) {
        this.answerService = answerService;
    }

    @GetMapping(path = "/getAll")
    List<Answer> getAllAnswers() {
        return answerService.getAllAnswers();
    }

    @GetMapping(path = "/getById")
    Answer getSpecifiedAnswer(@RequestParam(name = "id", required = true) Long id) {
        return answerService.getSpecifiedAnswer(id);
    }

    @DeleteMapping(path = "deleteAll")
    ResponseEntity<JSONObject> deleteAllAnswers() {
        return answerService.deleteAllAnswers();
    }

    @DeleteMapping(path = "/deleteById")
    ResponseEntity<JSONObject> deleteSpecifiedAnswer(@RequestParam(name = "id", required = true) Long id) {
        return answerService.deleteSpecifiedAnswer(id);
    }

    @PostMapping
    Answer addAnswer(@Valid @RequestBody Answer answer) {
        return answerService.addAnswer(answer);
    }

    @PutMapping
    Answer editAnswer(@Valid @RequestBody Answer newAnswer, @RequestParam(name = "id", required = true) Long answerId) {
        return answerService.putAnswer(newAnswer, answerId);
    }

}
