package com.example.ppis.model;

import javax.persistence.*;
import java.util.Date;

@Entity
@Table(name = "Certificate")
public class Certificate {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @ManyToOne
    private Employee empolyeeOnCrtificate;

    @ManyToOne
    private Skill skillOnCetrificate;

    private String name;

    private Date dateOfIssue;

    private Date expireDate;

    public Certificate(Employee empolyeeOnCrtificate, Skill skillOnCetrificate, String name, Date dateOfIssue, Date expireDate) {
        this.empolyeeOnCrtificate = empolyeeOnCrtificate;
        this.skillOnCetrificate = skillOnCetrificate;
        this.name = name;
        this.dateOfIssue = dateOfIssue;
        this.expireDate = expireDate;
    }

    public Certificate() {}

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Employee getEmpolyeeOnCrtificate() {
        return empolyeeOnCrtificate;
    }

    public void setEmpolyeeOnCrtificate(Employee empolyeeOnCrtificate) {
        this.empolyeeOnCrtificate = empolyeeOnCrtificate;
    }

    public Skill getSkillOnCetrificate() {
        return skillOnCetrificate;
    }

    public void setSkillOnCetrificate(Skill skillOnCetrificate) {
        this.skillOnCetrificate = skillOnCetrificate;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Date getDateOfIssue() {
        return dateOfIssue;
    }

    public void setDateOfIssue(Date dateOfIssue) {
        this.dateOfIssue = dateOfIssue;
    }

    public Date getExpireDate() {
        return expireDate;
    }

    public void setExpireDate(Date expireDate) {
        this.expireDate = expireDate;
    }

    @Override
    public String toString() {
        return "Certificate{" +
                "id=" + id +
                ", empolyeeOnCrtificate=" + empolyeeOnCrtificate +
                ", skillOnCetrificate=" + skillOnCetrificate +
                ", name='" + name + '\'' +
                ", dateOfIssue=" + dateOfIssue +
                ", expireDate=" + expireDate +
                '}';
    }
}
