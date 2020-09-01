package com.example.ppis.service;

import com.example.ppis.dto.ResponseMessageDTO;
import com.example.ppis.dto.SkillDTO;
import com.example.ppis.model.*;
import com.example.ppis.repository.EmployeeEducationRepository;
import com.example.ppis.repository.EmployeeRepository;
import com.example.ppis.repository.EmployeeSkillRepository;
import com.example.ppis.repository.SkillRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

@Service
public class EmployeeService {

    @Autowired
    EmployeeRepository employeeRepository;

    @Autowired
    EmployeeSkillRepository employeeSkillRepository;

    @Autowired
    SkillRepository skillRepository;

    @Autowired
    EmployeeEducationRepository employeeEducationRepository;

    public List<Employee> getAll() {
        List<Employee> all = new ArrayList<>();
        employeeRepository.findAll().forEach(all::add);
        return all;
    }

    public Employee add(Employee employee) throws Exception {

        return employeeRepository.save(employee);
    }

    public Employee update(Employee newEmployee, Integer id) throws Exception {
        if (!employeeRepository.existsById(id)) {
            throw new Exception("Uposlenik sa id-em " + id + " ne postoji");
        }

        employeeRepository.findById(id).map(
                employee -> {
                    employee.setFirstName(newEmployee.getFirstName());
                    employee.setLastName(newEmployee.getLastName());
                    employee.setBirthDate(newEmployee.getBirthDate());
                    employee.setDateOfEmployment(newEmployee.getDateOfEmployment());
                    return employeeRepository.save(employee);
                }
        );
        return employeeRepository.findById(id).get();
    }

    public HashMap<String, String> delete(Integer id) throws Exception {
        if (!employeeRepository.existsById(id)) {
            throw new Exception("Uposlenik sa id-em " + id + " ne postoji");
        }

        employeeRepository.deleteById(id);
        return new ResponseMessageDTO("Uspjesno obrisan uposlenik sa id-em " + id).getHashMap();
    }

    public List<SkillDTO> getSkillsByEmployee(Integer id) throws Exception {

        if (!employeeRepository.existsById(id)) {
            throw new Exception("Uposlenik sa id-em " + id + " ne postoji");
        }

        List<SkillDTO> skills = new ArrayList<>();
        for (EmployeeSkill employeeSkill : employeeSkillRepository.findAll()) {
            if(employeeSkill.getEmployee().getId() == id) {
                skills.add(new SkillDTO(employeeSkill.getSkill(), employeeSkill.getSkillLevel(), employeeSkill.getDateCreated()));
            }
        }

        return skills;
    }


    public List<Education> getEducationsByEmployee(Integer id) throws Exception {
        if (!employeeRepository.existsById(id)) {
            throw new Exception("Uposlenik sa id-em " + id + " ne postoji");
        }

        List<Education> educations = new ArrayList<>();
        for(EmployeeEducation employeeEducation : employeeEducationRepository.findAll()) {
            if(employeeEducation.getEmployee().getId()==id) {
                educations.add(employeeEducation.getEducation());
            }
        }
        return educations;
    }

    public EmployeeSkill addSkillToEmployee(SkillDTO skillDTO, Integer employeeId) throws Exception {
        if (!employeeRepository.existsById(employeeId)) {
            throw new Exception("Uposlenik sa id-em " + employeeId + " ne postoji");
        }

        if(!skillRepository.existsById(skillDTO.getSkill().getId())) {
            throw new Exception("Vještina sa id-em " + skillDTO.getSkill().getId() + " ne postoji");
        }

        Employee employee = employeeRepository.findById(employeeId).orElse(null);
        Skill skill = skillRepository.findById(skillDTO.getSkill().getId()).orElse(null);

        EmployeeSkill employeeSkill = new EmployeeSkill(employee, skill, skillDTO.getSkillLevel(), skillDTO.getDateCreated());

        return employeeSkillRepository.save(employeeSkill);
    }
}
