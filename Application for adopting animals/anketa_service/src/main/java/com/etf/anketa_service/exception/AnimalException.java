package com.etf.anketa_service.exception;

public class AnimalException extends RuntimeException {
    public AnimalException(Long id) {
        super("Zivotinja ciji je id " + id + " ne postoji!");
    }
}
