package com.example.ppis.service;

import com.example.ppis.dto.EmployeeEducationDTO;
import com.example.ppis.model.EmployeeEducation;
import com.example.ppis.repository.EducationRepository;
import com.example.ppis.repository.EmployeeEducationRepository;
import com.example.ppis.repository.EmployeeRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class EmployeeEducationService {

    @Autowired
    EmployeeRepository employeeRepository;

    @Autowired
    EducationRepository educationRepository;

    @Autowired
    EmployeeEducationRepository employeeEducationRepository;

    public EmployeeEducation addNewEducationToEmplyer(EmployeeEducationDTO employeeEducationDTO) throws  Exception {
        if(!employeeRepository.existsById(employeeEducationDTO.getEmployeeId())) {
            throw  new Exception("Ne postoji uposlenik");
        }
        if(!educationRepository.existsById(employeeEducationDTO.getEducationId())) {
            throw new Exception("Ne postoji edukacija");
        }

        return employeeEducationRepository.save(new EmployeeEducation(employeeRepository.findById(employeeEducationDTO.getEmployeeId()).get(),educationRepository.findById(employeeEducationDTO.getEducationId()).get()));
    }

    public void deleteEducationFromEmployeer(EmployeeEducationDTO employeeEducationDTO) throws Exception {
       EmployeeEducation employeeEducation = employeeEducationRepository.findByEducationAndEmployee(educationRepository.findById(employeeEducationDTO.getEducationId()).get(),employeeRepository.findById(employeeEducationDTO.getEmployeeId()).get());
        if(employeeEducation == null) {
            throw new Exception("Ne postoji");
        }
        employeeEducationRepository.delete(employeeEducation);
    }
}
