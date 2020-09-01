package com.example.ppis.repository;

import com.example.ppis.model.Contract;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface ContractRepository extends CrudRepository<Contract, Integer> {
}
