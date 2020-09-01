package com.etf.anketa_service.exception;

public class AnswerException extends RuntimeException {
    public AnswerException(Long id) {
        super("Odgovor ciji je id " + id + " ne postoji!");
    }
}
