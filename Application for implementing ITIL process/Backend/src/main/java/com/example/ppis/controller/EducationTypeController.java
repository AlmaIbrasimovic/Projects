package com.example.ppis.controller;

import com.example.ppis.model.EducationType;
import com.example.ppis.model.SkillType;
import com.example.ppis.service.EducationTypeService;
import com.example.ppis.service.SkillTypeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;

@RestController
public class EducationTypeController {

    @Autowired
    EducationTypeService educationTypeService;

    @PostMapping("/education-types")
    @ResponseStatus(HttpStatus.CREATED)
    EducationType add(@RequestBody EducationType educationType) {
        return educationTypeService.add(educationType);
    }

    @PutMapping("/education-types")
    EducationType update(@RequestBody EducationType newEducationType) throws Exception {
        return educationTypeService.update(newEducationType, newEducationType.getId());
    }

    @DeleteMapping("/education-types/{id}")
    HashMap<String,String> delete(@PathVariable Integer id) throws Exception {
        return educationTypeService.delete(id);
    }

    @GetMapping("/education-types")
    List<EducationType> getAll() {
        return educationTypeService.getAll();
    }
}
