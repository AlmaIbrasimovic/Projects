package com.example.recipes.repository;

import com.example.recipes.model.Korisnici;
import com.example.recipes.model.Recipe;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

@Repository
public interface RecipeRepository extends JpaRepository<Recipe, Long> {

    @Query(value = "SELECT * FROM Recipe WHERE id = :id", nativeQuery = true)
    Recipe findOneById(@Param("id") Long id);
}
