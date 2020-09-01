package com.etf.korisnik_service.exception;

public class UserException extends RuntimeException {

    public UserException(Integer id) {
        super("Korisnik sa id-em " + id + " ne postoji");
    }

}
