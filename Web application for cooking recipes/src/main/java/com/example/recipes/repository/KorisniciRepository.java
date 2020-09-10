package com.example.recipes.repository;

import com.example.recipes.model.Korisnici;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface KorisniciRepository extends JpaRepository<Korisnici, Long> {

    @Query(value = "SELECT * FROM Korisnici WHERE id = :id", nativeQuery = true)
    Korisnici findOneById(@Param("id") Long id);

    @Query(value = "SELECT recipe_id FROM favourite_recipes_users WHERE user_id = :id", nativeQuery = true)
    List<Integer> findFavouriteRecipes(@Param("id") Long id);
}
