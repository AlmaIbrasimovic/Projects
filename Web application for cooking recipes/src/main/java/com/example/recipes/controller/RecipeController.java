package com.example.recipes.controller;

import com.example.recipes.model.Ingredient;
import com.example.recipes.model.Korisnici;
import com.example.recipes.model.Recipe;

import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.example.recipes.model.RecipePostDTO;
import com.example.recipes.service.RecipeService;
import io.swagger.models.auth.In;
import net.minidev.json.JSONObject;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;

@RestController
public class RecipeController {

    private RecipeService recipeService;

    public RecipeController(RecipeService recipeService) {
        this.recipeService = recipeService;
    }

    // GET
    @GetMapping("/allrecipes")
    public List<Recipe> getAllRecipes() {
        return recipeService.findAll();
    }

    @GetMapping("/recipe/{id}")
    public Recipe one(@PathVariable Long id) {
        return recipeService.findById(id);
    }

    // To get recipes that user created
    @GetMapping("/user/recipes/{userID}")
    public List<Map<String, Object>> getUserRecipes(@PathVariable Long userID) throws Exception {
        return recipeService.getUserRecipes(userID);
    }

    @GetMapping("/recipe/ingredients/{recipeID}")
    public List<Map<String, Object>> getIngredients(@PathVariable Long recipeID) throws Exception {
        return recipeService.getIngredients(recipeID);
    }

    // DELETE
    @DeleteMapping("/deleteRecipes")
    ResponseEntity<JSONObject> deleteAllRecipes() throws Exception {
        JSONObject temp = new JSONObject();
        try {
            recipeService.deleteAll();
            temp.put("message", "Successfully deleted recipes!");
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.OK
            );
        } catch (Exception e) {
            temp.put("message", "Some error happened while deleting recipes");
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    @DeleteMapping("/deleteRecipe/{id}")
    ResponseEntity<JSONObject> deleteRecipeById(@PathVariable Long id) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            recipeService.deleteById(id);
            temp.put("message", "Recipe with id " + id + " successfully deleted!");
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.OK
            );
        } catch (Exception e) {
            temp.put("message", e.getMessage());
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    // POST
    @PostMapping(value = "/recipe", consumes = "application/json", produces = "application/json")
    ResponseEntity<JSONObject> createRecipe(@Valid @RequestBody Recipe recipe) throws Exception {
        JSONObject message = new JSONObject();
        try {
            recipeService.createRecipe(recipe);
            message.put("message", recipe);
            return new ResponseEntity<>(
                    message,
                    HttpStatus.OK
            );
        } catch (Exception e) {
            message.put("message", e.getMessage());
            return new ResponseEntity<>(
                    message,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    @PostMapping(value = "/recipe/{userID}", headers = "Accept=application/json", consumes = "application/json", produces = "application/json")
    ResponseEntity<JSONObject> createRecipeUserDTO(@PathVariable Long userID, @RequestBody RecipePostDTO ingredient) throws Exception {
        JSONObject message = new JSONObject();
        try {
            message.put("message", recipeService.createRecipeUser(ingredient, userID));
            return new ResponseEntity<>(
                    message,
                    HttpStatus.OK
            );
        } catch (Exception e) {
            message.put("message", e.getMessage());
            return new ResponseEntity<>(
                    message,
                    HttpStatus.BAD_REQUEST
            );
        }
    }


    // PUT
    @PutMapping("/recipe/{id}")
    @ResponseBody
    ResponseEntity<JSONObject> updateRecipe(@RequestBody Recipe recipe, @PathVariable Long id) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            recipeService.updateRecipe(recipe, id);
            temp.put("message", "Recipe with id " + id + " was successfully updated!");
            return new ResponseEntity<JSONObject>(
                    temp,
                    HttpStatus.OK
            );
        } catch (Exception e) {
            temp.put("message", e.getMessage());
            return new ResponseEntity<JSONObject>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }
}
