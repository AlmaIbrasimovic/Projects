package com.example.zivotinja.exception;

public class VeterinarException extends RuntimeException {
    public VeterinarException(Long id) {
        super("Ne postoji veterinar sa id " + id);
    }
}
