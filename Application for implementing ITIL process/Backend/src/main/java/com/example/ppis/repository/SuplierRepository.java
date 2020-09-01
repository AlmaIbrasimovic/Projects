package com.example.ppis.repository;

import com.example.ppis.model.Suplier;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface SuplierRepository extends CrudRepository<Suplier, Integer> {

    Suplier findByName(String name);
}
