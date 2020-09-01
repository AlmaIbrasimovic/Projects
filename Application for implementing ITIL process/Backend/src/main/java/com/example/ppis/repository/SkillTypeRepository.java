package com.example.ppis.repository;

import com.example.ppis.model.SkillType;
import com.sun.xml.bind.v2.model.core.ID;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface SkillTypeRepository extends CrudRepository<SkillType, Integer> {

    SkillType findByName(String name);

    SkillType findById(ID id);
}
