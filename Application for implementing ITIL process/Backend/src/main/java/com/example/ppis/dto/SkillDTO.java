package com.example.ppis.dto;

import com.example.ppis.model.Skill;

import java.util.Date;

public class SkillDTO {

    private Skill skill;

    private Integer skillLevel;

    private Date dateCreated;

    public SkillDTO() {
    }

    public SkillDTO(Skill skill, Integer skillLevel, Date dateCreated) {
        this.skill = skill;
        this.skillLevel = skillLevel;
        this.dateCreated = dateCreated;
    }

    public Skill getSkill() {
        return skill;
    }

    public void setSkill(Skill skill) {
        this.skill = skill;
    }

    public Integer getSkillLevel() {
        return skillLevel;
    }

    public void setSkillLevel(Integer skillLevel) {
        this.skillLevel = skillLevel;
    }

    public Date getDateCreated() {
        return dateCreated;
    }

    public void setDateCreated(Date dateCreated) {
        this.dateCreated = dateCreated;
    }
}
