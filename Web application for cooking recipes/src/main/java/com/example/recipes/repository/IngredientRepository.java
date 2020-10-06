package com.example.recipes.repository;

import com.example.recipes.model.Ingredient;
import com.example.recipes.model.Recipe;
import io.swagger.models.auth.In;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Map;

@Repository
public interface IngredientRepository extends JpaRepository<Ingredient, Long> {

    @Query(value = "SELECT * FROM Ingredient WHERE id = :id", nativeQuery = true)
    Map<String, Object> findOneById(@Param("id") Long id);
}
