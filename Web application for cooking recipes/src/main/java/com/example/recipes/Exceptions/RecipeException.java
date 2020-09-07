package com.example.recipes.Exceptions;

public class RecipeException extends RuntimeException {
    public RecipeException(Long id) {
        super ("Recipe with id " + id + " doesn't exist!");
    }
}
