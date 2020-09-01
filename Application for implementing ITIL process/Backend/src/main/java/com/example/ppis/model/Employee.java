package com.example.ppis.model;

import javax.persistence.*;
import javax.validation.constraints.NotBlank;
import java.util.Date;
import java.util.List;

@Entity
@Table(name = "Employee")
public class Employee {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @NotBlank
    private String firstName;

    @NotBlank
    private String lastName;

    private Date birthDate;

    private Date dateOfEmployment;

    @ManyToMany
    private List<Education> educations;

    public Employee() {
    }

    public Employee(@NotBlank String firstName, @NotBlank String lastName, Date birthDate, Date dateOfEmployment, List<Education> educations) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthDate = birthDate;
        this.dateOfEmployment = dateOfEmployment;
        this.educations = educations;
    }

    public Employee(@NotBlank String firstName, @NotBlank String lastName, Date birthDate, Date dateOfEmployment) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.birthDate = birthDate;
        this.dateOfEmployment = dateOfEmployment;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public Date getBirthDate() {
        return birthDate;
    }

    public void setBirthDate(Date birthDate) {
        this.birthDate = birthDate;
    }

    public Date getDateOfEmployment() {
        return dateOfEmployment;
    }

    public void setDateOfEmployment(Date dateOfEmployment) {
        this.dateOfEmployment = dateOfEmployment;
    }

    public List<Education> getEducations() {
        return educations;
    }

    public void setEducations(List<Education> educations) {
        this.educations = educations;
    }
}
