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

        Recipe rec = new Recipe("Pizza", "Main Dish", "Put milk and chocolate", new Ingredient("Milk", 1000, "ml"), new Ingredient("Chocolate", 250, "gr"));
        Korisnici user = new Korisnici("Alma", "Ibrasimovic", "alma_96", "belma.alma@hotmail.com");
        //user.getFavouriteRecipes().add(rec);
        //rec.getUsers().add(user);
        rRepo.save(rec);
        kRepo.save(user);
    }
}
