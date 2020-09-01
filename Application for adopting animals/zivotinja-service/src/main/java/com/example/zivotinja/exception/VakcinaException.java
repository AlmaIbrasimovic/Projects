package com.example.zivotinja.exception;

public class VakcinaException extends RuntimeException {
    public VakcinaException(Long id) {
        super("Ne postoji vakcina sa id " + id);
    }
}
