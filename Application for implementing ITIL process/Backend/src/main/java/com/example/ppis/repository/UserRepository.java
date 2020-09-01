package com.example.ppis.repository;

import com.example.ppis.model.User;
import org.springframework.data.repository.CrudRepository;

public interface UserRepository extends CrudRepository<User,Integer> {
    User findByEmail(String email);
    User findByUsername(String username);
}
