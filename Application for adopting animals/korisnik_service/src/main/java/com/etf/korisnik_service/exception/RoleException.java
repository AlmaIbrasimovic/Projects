package com.etf.korisnik_service.exception;

public class RoleException extends RuntimeException {

    public RoleException(Integer id) {
        super("Ne postoji uloga sa id-em " + id);
    }

    public RoleException() {}

}
