package com.example.ppis.controller;

import com.example.ppis.model.Employee;
import com.example.ppis.model.Skill;
import com.example.ppis.service.SkillService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;

@RestController
public class SkillController {

    @Autowired
    SkillService skillService;

    @PostMapping("/skills")
    @ResponseStatus(HttpStatus.CREATED)
    Skill add(@RequestBody Skill skill) throws Exception {
        return skillService.add(skill);
    }

    @PutMapping("/skills")
    Skill update(@RequestBody Skill newSkill) throws Exception {
        return skillService.update(newSkill, newSkill.getId());
    }

    @DeleteMapping("/skills/{id}")
    HashMap<String,String> delete(@PathVariable Integer id) throws Exception {
        return skillService.delete(id);
    }

    @GetMapping("/skills")
    List<Skill> getAll() {
        return skillService.getAll();
    }

    @GetMapping("skills/{id}/employees")
    List<Employee> getEmployees(@PathVariable Integer id) throws Exception {
        return skillService.getEmployeesBySkill(id);
    }
}
