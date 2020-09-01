package com.example.ppis.dto;

public class EmployeeEducationDTO {

    Integer employeeId;
    Integer educationId;

    public EmployeeEducationDTO() {

    }

    public EmployeeEducationDTO(Integer employeeId, Integer educationId) {
        this.employeeId = employeeId;
        this.educationId = educationId;
    }

    public Integer getEmployeeId() {
        return employeeId;
    }

    public void setEmployeeId(Integer employeeId) {
        this.employeeId = employeeId;
    }

    public Integer getEducationId() {
        return educationId;
    }

    public void setEducationId(Integer educationId) {
        this.educationId = educationId;
    }
}
