package com.etf.anketa_service.exception;

public class PossibleAnswerException extends RuntimeException {
    public PossibleAnswerException(Long id) {
        super("Ponudjeni odgovor ciji je id " + id + " ne postoji!");
    }
}
