package com.example.ppis.repository;

import com.example.ppis.model.EmployeeSkill;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface EmployeeSkillRepository extends CrudRepository<EmployeeSkill, Integer> {
}
