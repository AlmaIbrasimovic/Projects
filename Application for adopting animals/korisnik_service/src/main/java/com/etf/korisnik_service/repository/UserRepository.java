package com.etf.korisnik_service.repository;

import com.etf.korisnik_service.model.User;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface UserRepository extends CrudRepository<User, Integer> {
    User findByEmail(String email);
    List<User> findAllBySoftDelete(Boolean value);
    Integer deleteAllBySoftDelete(Boolean value);
    User findByUsername(String username);

}
