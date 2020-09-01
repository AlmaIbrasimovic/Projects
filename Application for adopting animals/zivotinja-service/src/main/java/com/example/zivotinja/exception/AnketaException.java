package com.example.zivotinja.exception;

public class AnketaException extends RuntimeException {
    public AnketaException(Long id) {
        super("Ne postoji anketa sa id " + id);
    }
}
