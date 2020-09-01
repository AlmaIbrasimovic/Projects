package com.etf.anketa_service.exception;

public class QuestionException extends RuntimeException {
    public QuestionException(Long id) {
        super("Pitanje ciji je id " + id + " ne postoji!");
    }
}
