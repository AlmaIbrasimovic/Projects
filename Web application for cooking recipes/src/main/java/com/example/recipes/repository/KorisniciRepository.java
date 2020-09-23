package com.example.recipes.repository;

import com.example.recipes.model.Korisnici;
import com.example.recipes.model.Recipe;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface KorisniciRepository extends JpaRepository<Korisnici, Long> {

    Boolean existsByeMail(String e_mail);

    @Query(value = "SELECT * FROM Korisnici WHERE e_mail = :e_mail", nativeQuery = true)
    Korisnici findByeMail(@Param("e_mail") String e_mail);

    @Query(value = "SELECT * FROM Korisnici WHERE id = :id", nativeQuery = true)
    Korisnici findOneById(@Param("id") Long id);

    @Query(value = "SELECT recipe_id FROM favourite_recipes_users WHERE user_id = :id", nativeQuery = true)
    List<Integer> findFavouriteRecipes(@Param("id") Long id);

    @Query(value = "SELECT * FROM Korisnici WHERE e_mail = :e_mail AND password = :password", nativeQuery = true)
    Korisnici findByEmailPassword(@Param("e_mail") String e_mail, @Param("password") String password);

    @Query(value = "SELECT id FROM Korisnici WHERE e_mail = :e_mail AND password = :password", nativeQuery = true)
    Long getId(@Param("e_mail") String e_mail, @Param("password") String password);
}
