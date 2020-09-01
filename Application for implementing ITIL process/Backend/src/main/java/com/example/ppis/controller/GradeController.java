package com.example.ppis.controller;

import com.example.ppis.dto.SuplierGradeDto;
import com.example.ppis.dto.SuplierGradeObjectDto;
import com.example.ppis.model.Grade;
import com.example.ppis.service.GradeService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class GradeController {

    @Autowired
    GradeService gradeService;

    @PostMapping("/grade")
    @ResponseStatus(HttpStatus.CREATED)
     Grade add(@RequestBody Grade grade) {
        return gradeService.add(grade);
    }

    @GetMapping("/grade/all")
    List<Grade> getAllGrades() throws Exception {
        return gradeService.getAllGrades();
    }

    @GetMapping("/grade/suplier/{suplierId}")
    List<Grade> getAllGradesForSuplier(@PathVariable Integer suplierId) throws Exception {
        return gradeService.getAllGradesForSuplier(suplierId);
    }

    @GetMapping("/grade/user/{userId}")
    List<Grade> getAllGradesFromUser(@PathVariable Integer userId) throws Exception {
        return gradeService.getAllGradesFromUser(userId);
    }

    @DeleteMapping("/grade/suplier/{suplierId}")
    void deleteGradesForSuplier(@PathVariable Integer suplierId) throws Exception {
        gradeService.deleteGradesForSuplier(suplierId);
    }

    @DeleteMapping("/grade/user/{userId}")
    void deleteGradesFromUser(@PathVariable Integer userId) throws Exception {
        gradeService.deleteGradesFromUser(userId);
    }

    @GetMapping("/grade/final/{suplierId}")
    Float getFinalGradeForSuplier(@PathVariable Integer suplierId) throws Exception{
        return gradeService.getFinalGradeForSuplier(suplierId);
    }

    @GetMapping("grades/statistic")
    SuplierGradeObjectDto getStatistic() throws Exception {
        return gradeService.getStatistic();
    }
}
