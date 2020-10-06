package com.example.recipes.service;

import com.example.recipes.Exceptions.IngredientException;
import com.example.recipes.Exceptions.RecipeException;
import com.example.recipes.model.Ingredient;
import com.example.recipes.model.Recipe;
import com.example.recipes.repository.IngredientRepository;
import io.swagger.models.auth.In;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class IngredientService {
    @Autowired
    private IngredientRepository ingredientRepository;

    public IngredientService(IngredientRepository ingredientRepository) {
        this.ingredientRepository = ingredientRepository;
    }

    public List<Ingredient> findAll() {
        return ingredientRepository.findAll();
    }

    public Ingredient findById(Long id) throws IngredientException {
        return ingredientRepository.findById(id).orElseThrow(() -> new IngredientException(id));
    }

    public void deleteAll() throws Exception {
        if (ingredientRepository.count() == 0) throw new Exception("There is no ingredients to delete!");
        ingredientRepository.deleteAll();
    }

    public void deleteById(Long id) throws IngredientException {
        if (!ingredientRepository.existsById(id)) throw new IngredientException(id);
        ingredientRepository.deleteById(id);
    }

    public Ingredient createIngredient(Ingredient ingredient) {
        return ingredientRepository.save(ingredient);
    }

    public Ingredient updateIngredient(Ingredient newIngredient, Long id) throws Exception {
        if (!ingredientRepository.existsById(id)) {
            throw new RecipeException(id);
        }
        return ingredientRepository.findById(id)
                .map(ingredient -> {
                    ingredient.setName(newIngredient.getName());
                    ingredient.setQuantity(newIngredient.getQuantity());
                    ingredient.setRecipes(newIngredient.getRecipes());
                    ingredient.setUnit(newIngredient.getUnit());
                    return ingredientRepository.save(ingredient);
                })
                .orElseGet(() -> {
                    newIngredient.setId(id);
                    return ingredientRepository.save(newIngredient);
                });
    }

}
