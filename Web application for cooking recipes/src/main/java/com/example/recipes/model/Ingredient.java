package com.example.recipes.model;
import javax.persistence.*;
import javax.validation.constraints.NotBlank;
import java.util.HashSet;
import java.util.Set;

@Entity
public class Ingredient {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotBlank (message = "Name of the ingredient is mandatory")
    private String Name;

    @NotBlank (message = "Quantity is mandatory!")
    private String Quantity;

    // Recipes n-n
    @ManyToMany(fetch = FetchType.LAZY, cascade = CascadeType.MERGE)
    @JoinTable(name = "ingredients_recipes",
            joinColumns = {
                    @JoinColumn(name = "ingredientID", referencedColumnName = "id", nullable = false, updatable = false)},
            inverseJoinColumns = {
                    @JoinColumn(name = "recipeID", referencedColumnName = "id", nullable = false, updatable = false)})
    private Set<Ingredient> Recipes = new HashSet<>();

    // Constructors
    public Ingredient() {}
    public Ingredient (String n, String q) {
        Name =  n;
        Quantity = q;
    }

    // Getters and setters
    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return Name;
    }

    public void setName(String name) {
        Name = name;
    }

    public String getQuantity() {
        return Quantity;
    }

    public void setQuantity(String quantity) {
        Quantity = quantity;
    }

    public Set<Ingredient> getRecipes() {
        return Recipes;
    }

    public void setRecipes(Set<Ingredient> recipes) {
        Recipes = recipes;
    }
}
