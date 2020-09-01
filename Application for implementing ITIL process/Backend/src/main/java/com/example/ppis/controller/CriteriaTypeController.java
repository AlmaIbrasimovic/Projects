package com.example.ppis.controller;

import com.example.ppis.model.CriteriaType;
import com.example.ppis.model.SkillType;
import com.example.ppis.service.CriteriaTypeService;
import com.example.ppis.service.SkillTypeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;

@RestController
public class CriteriaTypeController {

    @Autowired
    CriteriaTypeService criteriaTypeService;

    @PostMapping("/criteria")
    @ResponseStatus(HttpStatus.CREATED)
    CriteriaType add(@RequestBody CriteriaType criteriaType) {
        return criteriaTypeService.add(criteriaType);
    }

    @PutMapping("/criteria")
    CriteriaType update(@RequestBody CriteriaType criteriaType) throws Exception {
        return criteriaTypeService.update(criteriaType, criteriaType.getId());
    }

    @DeleteMapping("/criteria/{id}")
    HashMap<String,String> delete(@PathVariable Integer id) throws Exception {
        return criteriaTypeService.delete(id);
    }

    @GetMapping("/criteria")
    List<CriteriaType> getAll() {
        return criteriaTypeService.getAll();
    }
}
