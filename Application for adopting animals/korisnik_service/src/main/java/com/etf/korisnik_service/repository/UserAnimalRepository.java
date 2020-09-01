package com.etf.korisnik_service.repository;

import com.etf.korisnik_service.model.UserAnimal;
import org.springframework.data.repository.CrudRepository;

public interface UserAnimalRepository extends CrudRepository<UserAnimal, Integer> {
}
