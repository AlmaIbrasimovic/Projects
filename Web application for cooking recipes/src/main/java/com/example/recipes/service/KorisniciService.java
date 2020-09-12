package com.example.recipes.service;

import com.example.recipes.Exceptions.KorisniciException;
import com.example.recipes.Exceptions.RecipeException;
import com.example.recipes.model.Korisnici;
import com.example.recipes.model.Recipe;
import com.example.recipes.repository.KorisniciRepository;
import com.example.recipes.repository.RecipeRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.validation.Valid;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.Set;

@Service
public class KorisniciService {
    @Autowired
    private KorisniciRepository korisniciRepository;

    @Autowired
    private RecipeRepository recipeRepository;

    public KorisniciService(KorisniciRepository korisniciRepository, RecipeRepository recipeRepository) {
        this.korisniciRepository = korisniciRepository;
        this.recipeRepository = recipeRepository;
    }

    public List<Korisnici> getAll() {
        return korisniciRepository.findAll();
    }

    public Korisnici findOne(Long id) throws KorisniciException {
        return korisniciRepository.findById(id).orElseThrow(() -> new KorisniciException(id));
    }

    public void deleteAllUsers() throws Exception {
        if (korisniciRepository.count() == 0) throw new Exception("There is no users to delete!");
        else korisniciRepository.deleteAll();
    }

    public void deleteById(Long id) throws Exception {
        if (!korisniciRepository.existsById(id)) throw new KorisniciException(id);
        else if (korisniciRepository.count() == 0) throw new Exception("There is no users to delete!");
        else korisniciRepository.deleteById(id);
    }

    public Korisnici createUser(Korisnici newUser) {
        return korisniciRepository.save(newUser);
    }

    public Korisnici updateUser(Korisnici newUser, Long id) throws Exception {
        if (!korisniciRepository.existsById(id)) throw new KorisniciException(id);
        return korisniciRepository.findById(id)
                .map(user -> {
                    user.setFirstName(newUser.getFirstName());
                    user.setLastName(newUser.getLastName());
                    user.setPassword(newUser.getPassword());
                    user.setEMail(newUser.getEMail());
                    return korisniciRepository.save(user);
                })
                .orElseGet(() -> {
                    newUser.setId(id);
                    return korisniciRepository.save(newUser);
                });
    }

    public Korisnici createFavouriteRecipe(Long userID, Long recipeID) throws Exception {
        if (!korisniciRepository.existsById(userID)) throw new KorisniciException(userID);
        if (!recipeRepository.existsById(recipeID)) throw new RecipeException(recipeID);
        else {
            Recipe favRecipe = recipeRepository.findOneById(recipeID);
            Korisnici user = korisniciRepository.findOneById(userID);
            user.getFavouriteRecipes().add(favRecipe);
            favRecipe.getUsers().add(user);
            return korisniciRepository.save(user);
        }
    }

    public List<Recipe> getFavouriteRecipes(Long id) throws KorisniciException {
        if (!korisniciRepository.existsById(id)) throw new KorisniciException(id);
        List<Integer> favRecipesIndexes = korisniciRepository.findFavouriteRecipes(id);
        List<Recipe> favRecipes = new ArrayList<>();

        for (Integer favRecipesIndex : favRecipesIndexes) {
            favRecipes.add(recipeRepository.findOneById(Long.valueOf(favRecipesIndex)));
        }

        return favRecipes;
    }
}
