package com.example.ppis.repository;

import com.example.ppis.model.EducationType;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface EducationTypeRepository extends CrudRepository<EducationType, Integer> {

    EducationType findByName(String name);
}
