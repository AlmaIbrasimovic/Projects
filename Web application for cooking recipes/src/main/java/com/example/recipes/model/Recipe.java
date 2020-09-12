package com.example.recipes.model;

import com.fasterxml.jackson.annotation.JsonIdentityInfo;
import com.fasterxml.jackson.annotation.ObjectIdGenerators;

import javax.persistence.*;
import javax.validation.constraints.NotBlank;
import java.util.HashSet;
import java.util.Set;
import java.util.stream.Collectors;
import java.util.stream.Stream;

@Entity
@JsonIdentityInfo(generator = ObjectIdGenerators.PropertyGenerator.class, property = "id")
public class Recipe {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotBlank(message = "Name of the recipe is mandatory!")
    private String Name;

    @NotBlank(message = "Type of the recipe is mandatory!")
    private String Type;

    @Column(length=10485760)
    @NotBlank(message = "Description of the recipe is mandatory!")
    private String Description;

    // User n-1
    @ManyToOne
    @JoinColumn(name = "userID", nullable = true)
    private Korisnici userID;

    // Favourite recipes n-n
    @ManyToMany(fetch = FetchType.LAZY,
            cascade = {
                    CascadeType.PERSIST,
                    CascadeType.MERGE
            },
            mappedBy = "favouriteRecipes")
    private Set<Korisnici> users = new HashSet<>();

    // Ingredients n-n
    @ManyToMany(cascade = CascadeType.ALL)
    @JoinTable(name = "recipe_ingredients",
            joinColumns = @JoinColumn(name = "recipe_id"),
            inverseJoinColumns = @JoinColumn(name = "ingredient_id"))
    private Set<Ingredient> ingredients = new HashSet<>();

    // Constructors
    public Recipe() {
    }

    public Recipe(String n, String t, String description, Ingredient... ingredients) {
        Name = n;
        Type = t;
        Description = description;
        this.ingredients = Stream.of(ingredients).collect(Collectors.toSet());
        this.ingredients.forEach(x -> x.getRecipes().add(this));
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

    public Set<Ingredient> getIngredients() {
        return ingredients;
    }

    public void setIngredients(Set<Ingredient> ingredients) {
        this.ingredients = ingredients;
    }

    public Set<Korisnici> getUsers() {
        return users;
    }

    public void setUsers(Set<Korisnici> users) {
        this.users = users;
    }

    public String getDescription() {
        return Description;
    }

    public void setDescription(String description) {
        Description = description;
    }
}


