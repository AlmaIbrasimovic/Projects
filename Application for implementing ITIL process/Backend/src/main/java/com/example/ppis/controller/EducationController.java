package com.example.ppis.controller;

import com.example.ppis.model.Education;
import com.example.ppis.model.Skill;
import com.example.ppis.service.EducationService;
import com.example.ppis.service.SkillService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;

@RestController
public class EducationController {

    @Autowired
    EducationService educationService;

    @PostMapping("/educations")
    @ResponseStatus(HttpStatus.CREATED)
    Education add(@RequestBody Education education) throws Exception {
        return educationService.add(education);
    }

    @PutMapping("/educations")
    Education update(@RequestBody Education newEducation) throws Exception {
        return educationService.update(newEducation, newEducation.getId());
    }

    @DeleteMapping("/educations/{id}")
    HashMap<String,String> delete(@PathVariable Integer id) throws Exception {
        return educationService.delete(id);
    }

    @GetMapping("/educations")
    List<Education> getAll() {
        return educationService.getAll();
    }

    @GetMapping("/educations/{id}")
    public Education one(@PathVariable Integer id) throws Exception {
        return educationService.findById(id);
    }
}
