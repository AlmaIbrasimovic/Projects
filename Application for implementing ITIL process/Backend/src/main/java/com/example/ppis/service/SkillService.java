package com.example.ppis.service;

import com.example.ppis.dto.ResponseMessageDTO;
import com.example.ppis.dto.SkillDTO;
import com.example.ppis.model.Employee;
import com.example.ppis.model.EmployeeSkill;
import com.example.ppis.model.Skill;
import com.example.ppis.model.SkillType;
import com.example.ppis.repository.EmployeeSkillRepository;
import com.example.ppis.repository.SkillRepository;
import com.example.ppis.repository.SkillTypeRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Optional;

@Service
public class SkillService {
    @Autowired
    SkillRepository skillRepository;

    @Autowired
    SkillTypeRepository skillTypeRepository;

    @Autowired
    EmployeeSkillRepository employeeSkillRepository;

    public List<Skill> getAll() {
        List<Skill> all = new ArrayList<>();
        skillRepository.findAll().forEach(all::add);
        return all;
    }

    public Skill add(Skill skill) throws Exception {

        if(!skillTypeRepository.existsById(skill.getSkillType().getId())) {
            throw new Exception("Tip vještine s id "+ skill.getSkillType().getId() + "ne postoji");
        }

        SkillType skillType = skillTypeRepository.findById(skill.getSkillType().getId()).orElse(null);
        skill.setSkillType(skillType);
        return skillRepository.save(skill);
    }

    public Skill update(Skill newSkill, Integer id) throws Exception {
        if (!skillRepository.existsById(id)) {
            throw new Exception("Vještina sa id-em " + id + " ne postoji");
        }
        if(!skillTypeRepository.existsById(newSkill.getSkillType().getId())) {
            throw new Exception("Tip vještine s id "+ newSkill.getSkillType().getId() + "ne postoji");
        }

        skillRepository.findById(id).map(
                skill -> {
                    skill.setName(newSkill.getName());
                    skill.setSkillType(skillTypeRepository.findById(newSkill.getSkillType().getId())
                            .orElse(null));
                    return skillRepository.save(skill);
                }
        );
        return skillRepository.findById(id).get();
    }

    public HashMap<String, String> delete(Integer id) throws Exception {
        if (!skillRepository.existsById(id)) {
            throw new Exception("Vjestina sa id-em " + id + " ne postoji");
        }

        skillRepository.deleteById(id);
        return new ResponseMessageDTO("Uspjesno obrisana vjestina sa id-em " + id).getHashMap();
    }

    public List<Employee> getEmployeesBySkill(Integer id) throws Exception {
        if (!skillRepository.existsById(id)) {
            throw new Exception("Vještina sa id-em " + id + " ne postoji");
        }

        List<Employee> employees = new ArrayList<>();
        for (EmployeeSkill employeeSkill : employeeSkillRepository.findAll()) {
            if(employeeSkill.getSkill().getId() == id) {
                employees.add(employeeSkill.getEmployee());
            }
        }
        return employees;
    }
}
