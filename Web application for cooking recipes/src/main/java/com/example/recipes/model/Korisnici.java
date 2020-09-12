package com.example.recipes.model;

import javax.persistence.*;
import javax.validation.constraints.*;
import java.util.HashSet;
import java.util.Set;

@Entity
public class Korisnici {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotBlank(message = "First name is mandatory!")
    private String firstName;

    @NotBlank(message = "Last name is mandatory!")
    private String lastName;

    @NotBlank(message = "Password is mandatory!")
    private String Password;

    @NotBlank(message = "Email is mandatory!")
    private String eMail;

    // Recipe 1-n
    @OneToMany(mappedBy = "userID")
    private Set<Recipe> Recipes = new HashSet<>(); // Recipes which this user created


    // Favourite n-n
    @ManyToMany(fetch = FetchType.LAZY,
            cascade = {
                    CascadeType.PERSIST,
                    CascadeType.MERGE
            })
    @JoinTable(name = "favourite_recipes_users",
            joinColumns = {@JoinColumn(name = "user_id")},
            inverseJoinColumns = {@JoinColumn(name = "recipe_id")})
    private Set<Recipe> favouriteRecipes = new HashSet<>();

    // Constructors
    public Korisnici() {
    }

    public Korisnici(String fName, String lName, String pass, String email) {
        firstName = fName;
        lastName = lName;
        Password = pass;
        eMail = email;
    }

    // Getters and setters
    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getPassword() {
        return Password;
    }

    public void setPassword(String password) {
        Password = password;
    }

    public Set<Recipe> getRecipes() {
        return Recipes;
    }

    public void setRecipes(Set<Recipe> recipes) {
        Recipes = recipes;
    }

    public Set<Recipe> getFavouriteRecipes() {
        return favouriteRecipes;
    }

    public void setFavouriteRecipes(Set<Recipe> favouriteRecipes) {
        this.favouriteRecipes = favouriteRecipes;
    }

    public String getEMail() {
        return eMail;
    }

    public void setEMail(String eMail) {
        this.eMail = eMail;
    }
}

