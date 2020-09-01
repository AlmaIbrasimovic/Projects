package com.etf.korisnik_service.repository;

import com.etf.korisnik_service.model.Role;
import org.springframework.data.repository.CrudRepository;

public interface RoleRepository extends CrudRepository<Role, Integer> {
}
