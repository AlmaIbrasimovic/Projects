package com.etf.anketa_service.exception;

public class SurveyException extends RuntimeException {
    public SurveyException(Long id) {
        super("Anketa ciji je id " + id + " ne postoji!");
    }
}
