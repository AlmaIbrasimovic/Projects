package com.example.ppis.model;

import javax.persistence.*;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import java.util.Date;

@Entity
@Table(name = "Education")
public class Education {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @ManyToOne
    private Skill skill;

    @ManyToOne
    private EducationType educationType;

    @NotBlank
    private String topic;

    @NotBlank
    private String host;

    @NotNull
    private Date dateTime;

    public Education() {
    }

    public Education(Skill skill, EducationType educationType, @NotBlank String topic, @NotBlank String host, @NotNull Date dateTime) {
        this.skill = skill;
        this.educationType = educationType;
        this.topic = topic;
        this.host = host;
        this.dateTime = dateTime;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Skill getSkill() {
        return skill;
    }

    public void setSkill(Skill skill) {
        this.skill = skill;
    }

    public EducationType getEducationType() {
        return educationType;
    }

    public void setEducationType(EducationType educationType) {
        this.educationType = educationType;
    }

    public String getTopic() {
        return topic;
    }

    public void setTopic(String topic) {
        this.topic = topic;
    }

    public String getHost() {
        return host;
    }

    public void setHost(String host) {
        this.host = host;
    }

    public Date getDateTime() {
        return dateTime;
    }

    public void setDateTime(Date dateTime) {
        this.dateTime = dateTime;
    }

    @Override
    public String toString() {
        return new String(topic + " " + host + " Type: " + educationType.getName() + " Skill: " + skill.getName() + " " + dateTime);
    }
}
