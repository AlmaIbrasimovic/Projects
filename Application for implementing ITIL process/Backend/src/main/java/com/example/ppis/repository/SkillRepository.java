package com.example.ppis.repository;

import com.example.ppis.model.Skill;
import com.example.ppis.model.SkillType;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;


public interface SkillRepository extends CrudRepository<Skill, Integer> {

    Skill findByName(String name);
}
