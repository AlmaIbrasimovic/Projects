package com.example.recipes.Exceptions;

public class IngredientException extends RuntimeException {
    public IngredientException(Long id) {
        super ("Ingredient with id " + id + " doesn't exist!");
    }
}
