package com.example.ppis.repository;

import com.example.ppis.model.Role;
import org.springframework.data.repository.CrudRepository;

public interface RoleRepository extends CrudRepository<Role,Integer> {
    Role findByName(String name);
}
