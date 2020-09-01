package com.example.ppis.dto;

import com.example.ppis.model.Grade;

import java.util.List;

public class SuplierGradeDto {

    private Integer suplierId;
    private String suplierName;
    private List<Grade> gradesByCriteria;
    private Double finalGrade;
    private Integer year;

    public SuplierGradeDto() {
    }

    public SuplierGradeDto(Integer suplierId, String suplierName, List<Grade> gradesByCriteria, Double finalGrade, Integer year) {
        this.gradesByCriteria = gradesByCriteria;
        this.finalGrade = finalGrade;
        this.year = year;
        this.suplierId = suplierId;
        this.suplierName = suplierName;
    }

    public Integer getSuplierId() {
        return suplierId;
    }

    public void setSuplierId(Integer suplierId) {
        this.suplierId = suplierId;
    }

    public String getSuplierName() {
        return suplierName;
    }

    public void setSuplierName(String suplierName) {
        this.suplierName = suplierName;
    }

    public List<Grade> getGradesByCriteria() {
        return gradesByCriteria;
    }

    public void setGradesByCriteria(List<Grade> gradesByCriteria) {
        this.gradesByCriteria = gradesByCriteria;
    }

    public Double getFinalGrade() {
        return finalGrade;
    }

    public void setFinalGrade(Double finalGrade) {
        this.finalGrade = finalGrade;
    }

    public Integer getYear() {
        return year;
    }

    public void setYear(Integer year) {
        this.year = year;
    }
}
