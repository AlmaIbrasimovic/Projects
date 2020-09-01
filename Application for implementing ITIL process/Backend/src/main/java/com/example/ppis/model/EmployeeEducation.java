package com.example.ppis.model;

import javax.persistence.*;

@Entity
@Table(name = "EmployeeEducation")
public class EmployeeEducation {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @ManyToOne
    private Employee employee;

    @ManyToOne
    private Education education;

    public EmployeeEducation() {
    }

    public EmployeeEducation(Employee employee, Education education) {
        this.employee = employee;
        this.education = education;
    }

    public Employee getEmployee() {
        return employee;
    }

    public void setEmployee(Employee employee) {
        this.employee = employee;
    }

    public Education getEducation() {
        return education;
    }

    public void setEducation(Education education) {
        this.education = education;
    }
}
