package com.example.recipes.service;

import java.util.*;

import com.example.recipes.Exceptions.RecipeException;
import com.example.recipes.model.Ingredient;
import com.example.recipes.model.Korisnici;
import com.example.recipes.model.Recipe;
import com.example.recipes.model.RecipePostDTO;
import com.example.recipes.repository.KorisniciRepository;
import com.example.recipes.repository.RecipeRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class RecipeService {
    @Autowired
    private RecipeRepository recipeRepository;

    private KorisniciRepository korisniciRepository;

    public RecipeService(RecipeRepository recRepo, KorisniciRepository korisniciRepository) {
        recipeRepository = recRepo;
        this.korisniciRepository = korisniciRepository;
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

    public Recipe createRecipe(Recipe recipe) throws Exception {
        return recipeRepository.save(recipe);
    }

    public Recipe createRecipeUser(RecipePostDTO recipe, Long userID) throws Exception {
        Korisnici newUser = korisniciRepository.findOneById(userID);
        Recipe rec = recipe.getRecipe();
        Recipe newRecipe = new Recipe(rec.getName(), rec.getType(), rec.getDescription(), newUser);
        Set<Ingredient> ingredientSet = new HashSet<Ingredient>();

        for (Map<String, Object> map : recipe.getIngredientList()) {
            List<String> temp = new ArrayList<>();
            for (Map.Entry<String, Object> entry : map.entrySet()) {
                String key = entry.getKey();
                temp.add(entry.getValue().toString());
            }
            ingredientSet.add(new Ingredient(temp.get(0), Double.parseDouble(temp.get(1)), temp.get(2)));
        }

        newRecipe.setIngredients(ingredientSet);
        return recipeRepository.save(newRecipe);
    }

    public Recipe updateRecipe(Recipe newRecipe, Long id) throws Exception {
        if (!recipeRepository.existsById(id)) {
            throw new RecipeException(id);
        }
        return recipeRepository.findById(id)
                .map(recipe -> {
                    recipe.setType(newRecipe.getType());
                    recipe.setName(newRecipe.getName());
                    recipe.setIngredients(newRecipe.getIngredients());
                    recipe.setDescription(newRecipe.getDescription());
                    return recipeRepository.save(recipe);
                })
                .orElseGet(() -> {
                    newRecipe.setId(id);
                    return recipeRepository.save(newRecipe);
                });
    }
}
