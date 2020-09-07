package com.example.recipes;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class RecipesApplication {

    public static void main(String[] args) {
        System.out.print("Running");
        SpringApplication.run(RecipesApplication.class, args);
    }
}
