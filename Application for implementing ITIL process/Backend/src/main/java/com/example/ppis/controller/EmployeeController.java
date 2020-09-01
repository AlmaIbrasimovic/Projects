package com.example.ppis.controller;

import com.example.ppis.dto.SkillDTO;
import com.example.ppis.model.Education;
import com.example.ppis.model.Employee;
import com.example.ppis.model.EmployeeSkill;
import com.example.ppis.model.Skill;
import com.example.ppis.service.EmployeeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;

@RestController
public class EmployeeController {

    @Autowired
    EmployeeService employeeService;

    @PostMapping("/employees")
    @ResponseStatus(HttpStatus.CREATED)
    Employee add(@RequestBody Employee employee) throws Exception {
        return employeeService.add(employee);
    }

    @PutMapping("/employees")
    Employee update(@RequestBody Employee newEmployee) throws Exception {
        return employeeService.update(newEmployee, newEmployee.getId());
    }

    @DeleteMapping("/employees/{id}")
    HashMap<String,String> delete(@PathVariable Integer id) throws Exception {
        return employeeService.delete(id);
    }

    @GetMapping("/employees")
    List<Employee> getAll() {
        return employeeService.getAll();
    }

    @GetMapping("/employees/{id}/skills")
    List<SkillDTO> getAllSkills(@PathVariable Integer id) throws Exception {
        return employeeService.getSkillsByEmployee(id);
    }

    @GetMapping("/employees/{id}/educations")
    List<Education> getAllEducations(@PathVariable Integer id) throws Exception {
        return employeeService.getEducationsByEmployee(id);
    }

    @PostMapping("/employees/{id}/skills")
    EmployeeSkill addSkillToEmployee(@RequestBody SkillDTO skillDTO, @PathVariable Integer id) throws  Exception {
        return employeeService.addSkillToEmployee(skillDTO, id);
    }
}
