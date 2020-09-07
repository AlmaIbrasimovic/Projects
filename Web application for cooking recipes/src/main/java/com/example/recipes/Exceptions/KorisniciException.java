package com.example.recipes.Exceptions;

public class KorisniciException extends RuntimeException {
    public KorisniciException(Long id) {
        super ("User with id " + id + " doesn't exist!");
    }
}
