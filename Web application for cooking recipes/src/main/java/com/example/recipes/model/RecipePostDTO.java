package com.example.recipes.model;
import java.util.List;
import java.util.Map;

public class RecipePostDTO {

    private Recipe recipe;
    private List<Map<String, Object>> ingredientList;

    public RecipePostDTO(Recipe recipe, List<Map<String, Object>> ingredientList) {
        this.recipe = recipe;
        this.ingredientList = ingredientList;
    }

    public RecipePostDTO() {
    }

    public Recipe getRecipe() {
        return recipe;
    }

    public void setRecipe(Recipe recipe) {
        this.recipe = recipe;
    }

    public List<Map<String, Object>> getIngredientList() {
        return ingredientList;
    }

    public void setIngredientList(List<Map<String, Object>> ingredientList) {
        this.ingredientList = ingredientList;
    }
}
