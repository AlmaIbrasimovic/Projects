package com.example.ppis.model;

import javax.persistence.*;
import javax.validation.constraints.NotBlank;

@Entity
@Table(name = "Criteria_Type")
public class CriteriaType {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @NotBlank
    private String name;

    private Double coeficient;

    public CriteriaType() {
    }

    public CriteriaType(@NotBlank String name, Double coeficient) {
        this.name = name;
        this.coeficient = coeficient;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Double getCoeficient() {
        return coeficient;
    }

    public void setCoeficient(Double coeficient) {
        this.coeficient = coeficient;
    }
}
