package com.example.recipes;

import com.example.recipes.model.Ingredient;
import com.example.recipes.model.Korisnici;
import com.example.recipes.model.Recipe;
import com.example.recipes.repository.IngredientRepository;
import com.example.recipes.repository.KorisniciRepository;
import com.example.recipes.repository.RecipeRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

import java.util.HashSet;
import java.util.Set;

@SpringBootApplication
public class RecipesApplication implements CommandLineRunner {

    @Autowired
    private RecipeRepository rRepo;

    @Autowired
    private KorisniciRepository kRepo;

    @Autowired
    private IngredientRepository iRepo;

    public static void main(String[] args) {
        System.out.print("Running");
        SpringApplication.run(RecipesApplication.class, args);
    }

    @Override
    public void run(String... args) {
        Korisnici user = new Korisnici("Alma", "Ibrasimovic", "alma_96", "belma.alma@hotmail.com");
        kRepo.save(user);
        Recipe rec = new Recipe("Pizza", "Main Dish", "Put milk and chocolate", user);
        Set<Ingredient> ingredientSet = new HashSet<Ingredient>();
        ingredientSet.add(new Ingredient("Milk", 1000.0, "ml"));
        ingredientSet.add(new Ingredient("Chocolate", 250.0, "gr"));
        rec.setIngredients(ingredientSet);
        //  rec.setIngredients();
        //user.getFavouriteRecipes().add(rec);
        //rec.getUsers().add(user);
        rRepo.save(rec);

    }
}
