package com.example.recipes.service;

import java.util.List;

import com.example.recipes.Exceptions.RecipeException;
import com.example.recipes.model.Recipe;
import com.example.recipes.repository.RecipeRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class RecipeService {
    @Autowired
    private RecipeRepository recipeRepository;

    public RecipeService(RecipeRepository recRepo) {
        recipeRepository = recRepo;
    }

    public List<Recipe> findAll() {
        return recipeRepository.findAll();
    }

    public Recipe findById(Long id) {
        return recipeRepository.findById(id).orElseThrow(() -> new RecipeException(id));
    }

    public void deleteAll() throws Exception {
        if (recipeRepository.count() == 0) {
            throw new Exception("There is no recipes to delete!");
        } else {
            recipeRepository.deleteAll();
        }
    }

    public void deleteById(Long id) throws Exception {
        if (recipeRepository.count() == 0) {
            throw new Exception("There is no recipes to delete!");
        } else if (!recipeRepository.existsById(id)) {
            throw new RecipeException(id);
        } else {
            recipeRepository.deleteById(id);
        }
    }

    public Recipe createRecipe(Recipe recipe) {
        return recipeRepository.save(recipe);
    }

    public Recipe updateRecipe(Recipe newRecipe, Long id) throws Exception {
        if (!recipeRepository.existsById(id)) {
            throw new RecipeException(id);
        }
        return recipeRepository.findById(id)
                .map(recipe -> {
                    recipe.setType(newRecipe.getType());
                    recipe.setName(newRecipe.getName());
                    return recipeRepository.save(recipe);
                })
                .orElseGet(() -> {
                    newRecipe.setId(id);
                    return recipeRepository.save(newRecipe);
                });
    }
}
