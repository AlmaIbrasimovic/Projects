package com.example.zivotinja.exception;

public class BolestException extends RuntimeException {
    public BolestException(Long id) {
        super("Ne postoji bolest sa id " + id);
    }
}
