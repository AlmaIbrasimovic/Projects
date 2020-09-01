package com.example.ppis.repository;

import com.example.ppis.model.Education;
import com.example.ppis.model.Employee;
import com.example.ppis.model.EmployeeEducation;
import org.springframework.data.repository.CrudRepository;

public interface EmployeeEducationRepository extends CrudRepository<EmployeeEducation, Integer> {
        EmployeeEducation findByEducationAndEmployee(Education education, Employee employee);
}
