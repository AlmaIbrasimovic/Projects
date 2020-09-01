package com.example.ppis.repository;

import com.example.ppis.model.CriteriaType;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface CriteriaTypeRepository extends CrudRepository<CriteriaType, Integer> {
}
