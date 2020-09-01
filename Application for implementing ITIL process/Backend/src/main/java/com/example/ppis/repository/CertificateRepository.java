package com.example.ppis.repository;

import com.example.ppis.model.Certificate;
import com.example.ppis.model.EmployeeEducation;
import org.springframework.data.repository.CrudRepository;

public interface CertificateRepository  extends CrudRepository<Certificate, Integer> {
}
