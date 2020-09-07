package com.example.recipes.model;
import javax.persistence.*;
import javax.validation.constraints.NotBlank;
import java.util.HashSet;
import java.util.Set;

@Entity
public class Recipe {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotBlank (message = "Name of the recipe is mandatory!")
    private String Name;

    @NotBlank (message = "Type is mandatory!")
    private String Type;

    // User 1-n
    @ManyToOne
    @JoinColumn(name = "userID", nullable = true)
    private Korisnici userID;

    @ManyToOne
    @JoinColumn(name = "favUserID", nullable = true)
    private Korisnici favouriteUserID;

    // Ingredients n-n
    @ManyToMany(fetch = FetchType.LAZY, cascade = CascadeType.MERGE)
    @JoinTable(name = "ingredients_recipes",
            joinColumns = {
                    @JoinColumn(name = "recipeID", referencedColumnName = "id", nullable = false, updatable = false)},
            inverseJoinColumns = {
                    @JoinColumn(name = "ingredientID", referencedColumnName = "id", nullable = false, updatable = false)})
    private Set<Ingredient> Ingredients = new HashSet<>();

    // Constructors
    public Recipe() {
    }
    public Recipe (String n, String t) {
        Name = n;
        Type = t;
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

    public String getType() {
        return Type;
    }

    public void setType(String type) {
        Type = type;
    }

    public Korisnici getUserID() {
        return userID;
    }

    public void setUserID(Korisnici userID) {
        this.userID = userID;
    }

    public Korisnici getFavouriteUserID() {
        return favouriteUserID;
    }

    public void setFavouriteUserID(Korisnici favouriteUserID) {
        this.favouriteUserID = favouriteUserID;
    }

    public Set<Ingredient> getIngredients() {
        return Ingredients;
    }

    public void setIngredients(Set<Ingredient> ingredients) {
        Ingredients = ingredients;
    }
}


