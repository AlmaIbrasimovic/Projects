package com.etf.anketa_service.service;

import com.etf.anketa_service.exception.AnswerException;
import com.etf.anketa_service.model.Answer;
import com.etf.anketa_service.repository.AnswerRepository;
import net.minidev.json.JSONObject;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class AnswerService {
    private AnswerRepository answerRepository;

    public AnswerService(final AnswerRepository answerRepository) {
        this.answerRepository = answerRepository;
    }

    public List<Answer> getAllAnswers() {
        return answerRepository.findAll();
    }

    public Answer getSpecifiedAnswer(Long answerId) {
        return answerRepository.findById(answerId).orElseThrow(() -> new AnswerException(answerId));
    }

    public ResponseEntity<JSONObject> deleteAllAnswers() {
        answerRepository.deleteAll();
        JSONObject returnValue = new JSONObject();
        returnValue.put("message", "Uspjesno obrisani odgovori!");
        return new ResponseEntity<>(returnValue, HttpStatus.OK);
    }

    public ResponseEntity<JSONObject> deleteSpecifiedAnswer(Long answerId) {
        JSONObject returnValue = new JSONObject();
        try {
            answerRepository.deleteById(answerId);
            returnValue.put("message", "Uspjesno obrisan odgovor!");
            return new ResponseEntity<>(returnValue, HttpStatus.OK);
        }
        catch(Exception err) {
            returnValue.put("message", err.getMessage());
            return new ResponseEntity<>(returnValue, HttpStatus.BAD_REQUEST);
        }
    }

    public Answer addAnswer(Answer answer) {
        return answerRepository.save(answer);
    }

    public Answer putAnswer(Answer newAnswer, Long answerId) {
        Optional<Answer> toEdit = answerRepository.findById(answerId);
        if (!toEdit.isPresent()) {
            answerRepository.save(newAnswer);
            return newAnswer;
        } else {
            toEdit.get().setUser(newAnswer.getUser());
            toEdit.get().setPossibleAnswer(newAnswer.getPossibleAnswer());
            answerRepository.save(toEdit.get());
            return toEdit.get();
        }
    }
}
