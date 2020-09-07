package com.example.recipes.repository;

import com.example.recipes.model.Korisnici;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface KorisniciRepository extends JpaRepository<Korisnici, Long> {
}
