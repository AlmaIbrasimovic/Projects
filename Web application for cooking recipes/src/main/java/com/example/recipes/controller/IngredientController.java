package com.example.recipes.controller;

import com.example.recipes.Exceptions.IngredientException;
import com.example.recipes.model.Ingredient;
import com.example.recipes.model.Recipe;
import com.example.recipes.service.IngredientService;
import io.swagger.models.auth.In;
import net.minidev.json.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import springfox.documentation.spring.web.json.Json;

import javax.validation.Valid;
import java.util.List;

@RestController
public class IngredientController {

    @Autowired
    private IngredientService ingredientService;

    public IngredientController (IngredientService ingredientService) {
        this.ingredientService = ingredientService;
    }

    // GET
    @GetMapping (value = "/ingredients", produces = "application/json")
    public List<Ingredient> findAll() {
        return ingredientService.findAll();
    }

    @GetMapping ("ingredient/{id}")
    public Ingredient findById (@PathVariable Long id) throws IngredientException {
        return ingredientService.findById(id);
    }

    // DELETE
    @DeleteMapping ("/deleteIngredients")
    public ResponseEntity<JSONObject> deleteIngredients () throws Exception {
        JSONObject message = new JSONObject();
        try {
            ingredientService.deleteAll();
            message.put("message", "Ingredients successfully deleted!");
            return new ResponseEntity<>(
                    message,
                    HttpStatus.OK
            );
        }
        catch (Exception e) {
            message.put("message", e.getMessage());
            return new ResponseEntity<>(
                    message,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    @DeleteMapping ("/deleteIngredient/{id}")
    public ResponseEntity<JSONObject> deleteById (@PathVariable Long id) throws IngredientException {
        JSONObject message = new JSONObject();
        try {
            ingredientService.deleteById(id);
            message.put("message", "Ingredient with id " + id + " successfully deleted!");
            return new ResponseEntity<>(
                    message,
                    HttpStatus.OK
            );
        }
        catch (IngredientException e) {
            message.put("message", e.getMessage());
            return new ResponseEntity<>(
                    message,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    // POST
    @PostMapping("/ingredient")
    Ingredient createIngredient (@Valid @RequestBody Ingredient ingredient) {
        return ingredientService.createIngredient(ingredient);
    }

    // PUT
    @PutMapping ("/ingredient/{id}")
    @ResponseBody
    ResponseEntity<JSONObject> updateIngredient (@RequestBody Ingredient ingredient, @PathVariable Long id) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            ingredientService.updateIngredient(ingredient, id);
            temp.put("message", "Ingredient with id " + id + " was successfully updated!");
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
