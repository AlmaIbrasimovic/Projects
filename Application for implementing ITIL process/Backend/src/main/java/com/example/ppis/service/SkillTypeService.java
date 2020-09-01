package com.example.ppis.service;

import com.example.ppis.dto.ResponseMessageDTO;
import com.example.ppis.model.Role;
import com.example.ppis.model.Skill;
import com.example.ppis.model.SkillType;
import com.example.ppis.repository.SkillRepository;
import com.example.ppis.repository.SkillTypeRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

@Service
public class SkillTypeService {

    @Autowired
    SkillTypeRepository skillTypeRepository;

    public List<SkillType> getAll() {
        List<SkillType> all = new ArrayList<>();
        skillTypeRepository.findAll().forEach(all::add);
        return all;
    }

    public SkillType add(SkillType skillType) {

        return skillTypeRepository.save(skillType);
    }

    public SkillType update(SkillType newSkillType, Integer id) throws Exception {
        if (!skillTypeRepository.existsById(id)) {
            throw new Exception("Tip vještine sa id-em " + id + " ne postoji");
        }
        skillTypeRepository.findById(id).map(
                skillType -> {
                    skillType.setName(newSkillType.getName());
                    return skillTypeRepository.save(skillType);
                }
        );
        return skillTypeRepository.findById(id).get();
    }

    public HashMap<String, String> delete(Integer id) throws Exception {
        if (!skillTypeRepository.existsById(id)) {
            throw new Exception("Tip vjestine sa id-em " + id + " ne postoji");
        }

        skillTypeRepository.deleteById(id);
        return new ResponseMessageDTO("Uspjesno obrisan tip vjestine sa id-em " + id).getHashMap();
    }
}
