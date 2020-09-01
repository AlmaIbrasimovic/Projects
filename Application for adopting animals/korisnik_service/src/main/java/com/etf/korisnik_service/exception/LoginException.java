package com.etf.korisnik_service.exception;

public class LoginException extends RuntimeException {

    public LoginException(String errorMessage) {
        super(errorMessage);
    }
}
