package com.example.recipes.controller;

import com.example.recipes.model.Recipe;
import java.util.List;
import com.example.recipes.service.RecipeService;
import net.minidev.json.JSONObject;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import javax.validation.Valid;

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

    // POST
    @PostMapping ("/recipe")
    Recipe createRecipe (@Valid @RequestBody Recipe recipe) {
        return recipeService.createRecipe(recipe);
    }

    // PUT
    @PutMapping ("/recipe/{id}")
    @ResponseBody
    ResponseEntity<JSONObject> updateRecipe (@RequestBody Recipe recipe, @PathVariable Long id) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            recipeService.updateRecipe(recipe, id);
            temp.put("message", "Recipe with id " + id + " was successfully updated!");
            return new ResponseEntity<JSONObject>(
                    temp,
                    HttpStatus.OK
            );
        }
        catch (Exception e) {
            temp.put("message", e.getMessage());
            return new ResponseEntity<JSONObject>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }
}
