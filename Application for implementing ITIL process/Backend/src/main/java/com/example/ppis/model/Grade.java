package com.example.ppis.model;

import io.swagger.models.auth.In;

import javax.persistence.*;
import java.util.Date;

@Entity
@Table(name = "Grade")
public class Grade {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @ManyToOne
    private CriteriaType criteriaType;

    @ManyToOne
    private Suplier suplier;

    @ManyToOne
    private User user;

    private Date dateOfGrading;

    private Integer grade;

    private Integer year;

    public Grade() {
    }

    public Grade(CriteriaType criteriaType, Suplier suplier, User user, Date dateOfGrading, Integer grade, Integer year) {
        this.criteriaType = criteriaType;
        this.suplier = suplier;
        this.user = user;
        this.dateOfGrading = dateOfGrading;
        this.grade = grade;
        this.year = year;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public CriteriaType getCriteriaType() {
        return criteriaType;
    }

    public void setCriteriaType(CriteriaType criteriaType) {
        this.criteriaType = criteriaType;
    }

    public Suplier getSuplier() {
        return suplier;
    }

    public void setSuplier(Suplier suplier) {
        this.suplier = suplier;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public Date getDateOfGrading() {
        return dateOfGrading;
    }

    public void setDateOfGrading(Date dateOfGrading) {
        this.dateOfGrading = dateOfGrading;
    }

    public Integer getGrade() {
        return grade;
    }

    public void setGrade(Integer grade) {
        this.grade = grade;
    }

    public Integer getYear() {
        return year;
    }

    public void setYear(Integer year) {
        this.year = year;
    }
}
