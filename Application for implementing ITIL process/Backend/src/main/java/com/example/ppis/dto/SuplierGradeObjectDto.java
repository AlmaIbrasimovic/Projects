package com.example.ppis.dto;

import java.util.List;

public class SuplierGradeObjectDto {
    private List<SuplierGradeDto> suplierGradeDtoList;
    private List<Integer> supliers;
    private  List<Integer> years;

    public SuplierGradeObjectDto() {
    }

    public SuplierGradeObjectDto(List<SuplierGradeDto> suplierGradeDtoList, List<Integer> supliers, List<Integer> years) {
        this.suplierGradeDtoList = suplierGradeDtoList;
        this.supliers = supliers;
        this.years = years;
    }

    public List<SuplierGradeDto> getSuplierGradeDtoList() {
        return suplierGradeDtoList;
    }

    public void setSuplierGradeDtoList(List<SuplierGradeDto> suplierGradeDtoList) {
        this.suplierGradeDtoList = suplierGradeDtoList;
    }

    public List<Integer> getSupliers() {
        return supliers;
    }

    public void setSupliers(List<Integer> supliers) {
        this.supliers = supliers;
    }

    public List<Integer> getYears() {
        return years;
    }

    public void setYears(List<Integer> years) {
        this.years = years;
    }
}
