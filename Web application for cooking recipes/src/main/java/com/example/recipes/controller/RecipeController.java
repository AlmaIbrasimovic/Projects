package com.example.recipes.controller;

import com.example.recipes.model.Recipe;
import java.util.List;
import com.example.recipes.service.RecipeService;
import org.json.JSONObject;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class RecipeController {

    private RecipeService recipeService;
    public RecipeController (RecipeService recipeService) {
        this.recipeService = recipeService;
    }

    // GET
    @GetMapping ("/allrecipes")
    public List<Recipe> getAllRecipes () {
        return recipeService.findAll();
    }

    @GetMapping ("/recipe/{id}")
    public Recipe one (@PathVariable Long id) {
        return recipeService.findById(id);
    }

    // DELETE
    @DeleteMapping ("/deleteRecipes")
    ResponseEntity<JSONObject> deleteAllRecipes () throws Exception {
        JSONObject temp = new JSONObject();
        try {
            recipeService.deleteAll();
            temp.put("message", "Successfully deleted recipes!");
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.OK
            );
        }
        catch (Exception e) {
            temp.put ("message", "Some error happened while deleting recipes");
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    @DeleteMapping ("/deleteRecipe/{id}")
    ResponseEntity<JSONObject> deleteRecipeById (@PathVariable Long id) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            recipeService.deleteById(id);
            temp.put("message", "Recipe with id " + id + " successfully deleted!");
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.OK
            );
        }
        catch (Exception e) {
            temp.put("message", "Some error happened while deleting recipe with id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

}
