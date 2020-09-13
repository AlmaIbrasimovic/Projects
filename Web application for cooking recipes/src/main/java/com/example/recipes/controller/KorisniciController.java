package com.example.recipes.controller;

import com.example.recipes.Exceptions.KorisniciException;
import com.example.recipes.model.Korisnici;
import com.example.recipes.model.Recipe;
import com.example.recipes.model.UserLoginDTO;
import com.example.recipes.service.KorisniciService;
import net.minidev.json.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.validation.annotation.Validated;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.HashMap;
import java.util.List;

@RestController
public class KorisniciController {

    @Autowired
    private KorisniciService korisniciService;

    public KorisniciController(KorisniciService korisniciService) {
        this.korisniciService = korisniciService;
    }

    // GET
    @GetMapping("/users")
    public List<Korisnici> getAllUsers() {
        return korisniciService.getAll();
    }


    @GetMapping("/user/{id}")
    public Korisnici one(@PathVariable Long id) throws KorisniciException {
        return korisniciService.findOne(id);
    }

    @GetMapping("/favouriteRecipes/{id}")
    public List<Recipe> getFavouriteRecipes(@PathVariable Long id) throws KorisniciException {
        return korisniciService.getFavouriteRecipes(id);
    }

    @GetMapping("/user/{email}/{password}")
    public Korisnici getData(@PathVariable String email, @PathVariable String password) {
        Long id = korisniciService.getId(email, password);
        return korisniciService.findOne(id);
    }

    // DELETE
    @DeleteMapping("/deleteUsers")
    ResponseEntity<JSONObject> deleteAllUsers() throws Exception {
        JSONObject message = new JSONObject();
        try {
            korisniciService.deleteAllUsers();
            message.put("message", "Users deleted successfully!");
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

    @DeleteMapping("/deleteUser/{id}")
    ResponseEntity<JSONObject> deleteById(@PathVariable Long id) throws Exception {
        JSONObject message = new JSONObject();
        try {
            korisniciService.deleteById(id);
            message.put("message", "User with id " + id + " successfully deleted!");
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

    // POST
    @PostMapping(value = "/user", consumes = "application/json", produces = "application/json")
    ResponseEntity<JSONObject> createUser(@Valid @RequestBody Korisnici user) throws Exception {
        JSONObject message = new JSONObject();
        try {
            korisniciService.createUser(user);
            message.put("message", user);
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

    @PostMapping("/login")
    HashMap<String, String> login(@RequestBody UserLoginDTO user) throws Exception {
        return korisniciService.login(user);
    }

    // PUT
    @PutMapping("/user/{id}")
    ResponseEntity<JSONObject> updateUser(@Valid @RequestBody Korisnici user, @PathVariable Long id) throws Exception {
        JSONObject message = new JSONObject();
        try {
            korisniciService.updateUser(user, id);
            message.put("message", "User with id " + id + " was successfully updated!");
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

    // Add favourite recipe to user
    @PutMapping("/favouriteRecipe/{userID}/{recipeID}")
    ResponseEntity<JSONObject> createFavouriteRecipe(@PathVariable Long userID, @PathVariable Long recipeID) throws Exception {

        JSONObject message = new JSONObject();
        try {
            korisniciService.createFavouriteRecipe(userID, recipeID);
            message.put("message", "Recipe with id " + recipeID + " assigned to user with id " + userID);
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
}
