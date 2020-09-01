package com.example.ppis.controller;

import com.example.ppis.dto.EmployeeEducationDTO;
import com.example.ppis.model.Employee;
import com.example.ppis.model.EmployeeEducation;
import com.example.ppis.service.EmployeeEducationService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

@RestController
public class EmployeeEducationController {

    @Autowired
    EmployeeEducationService employeeEducationService;

    @PostMapping("/employeeEducation")
    @ResponseStatus(HttpStatus.CREATED)
    EmployeeEducation add(@RequestBody EmployeeEducationDTO employeeEducationDTO) throws Exception {
        return employeeEducationService.addNewEducationToEmplyer(employeeEducationDTO);
    }

    @DeleteMapping("/employeeEducation")
    void delete(@RequestBody EmployeeEducationDTO employeeEducationDTO) throws Exception {
        employeeEducationService.deleteEducationFromEmployeer(employeeEducationDTO);
    }


}
