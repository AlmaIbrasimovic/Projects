package com.example.ppis.service;

import com.example.ppis.dto.ResponseMessageDTO;
import com.example.ppis.model.Education;
import com.example.ppis.model.EducationType;
import com.example.ppis.model.Skill;
import com.example.ppis.model.SkillType;
import com.example.ppis.repository.EducationRepository;
import com.example.ppis.repository.EducationTypeRepository;
import com.example.ppis.repository.SkillRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

@Service
public class EducationService {

    @Autowired
    EducationRepository educationRepository;

    @Autowired
    EducationTypeRepository educationTypeRepository;

    @Autowired
    SkillRepository skillRepository;

    public List<Education> getAll() {
        List<Education> all = new ArrayList<>();
        educationRepository.findAll().forEach(all::add);
        return all;
    }

    public Education add(Education education) throws Exception {

        if(!skillRepository.existsById(education.getSkill().getId())) {
            throw new Exception("Vještina s id "+ education.getSkill().getId() + " ne postoji");
        }

        if(!educationTypeRepository.existsById(education.getEducationType().getId())) {
            throw new Exception("Tip edukacije s id " + education.getEducationType().getId() + " ne postoji");
        }

        Skill skill = skillRepository.findById(education.getSkill().getId()).orElse(null);
        EducationType educationType = educationTypeRepository.findById(education.getEducationType().getId()).orElse(null);

        education.setSkill(skill);
        education.setEducationType(educationType);

        return educationRepository.save(education);
    }

    public Education update(Education newEducation, Integer id) throws Exception {
        if (!educationRepository.existsById(id)) {
            throw new Exception("Edukacija sa id-em " + id + " ne postoji");
        }
        if(!skillRepository.existsById(newEducation.getSkill().getId())) {
            throw new Exception("Vještina s id "+ newEducation.getSkill().getId() + " ne postoji");
        }

        if(!educationTypeRepository.existsById(newEducation.getEducationType().getId())) {
            throw new Exception("Tip edukacije s id " + newEducation.getEducationType().getId() + " ne postoji");
        }

        educationRepository.findById(id).map(
                education -> {

                    education.setSkill(skillRepository.findById(newEducation.getSkill().getId())
                            .orElse(null));
                    education.setEducationType(educationTypeRepository.findById(newEducation.getEducationType().getId())
                    .orElse(null));
                    education.setTopic(newEducation.getTopic());
                    education.setHost(newEducation.getHost());
                    education.setDateTime(newEducation.getDateTime());

                    return educationRepository.save(education);
                }
        );
        return educationRepository.findById(id).get();
    }

    public HashMap<String, String> delete(Integer id) throws Exception {
        if (!educationRepository.existsById(id)) {
            throw new Exception("Edukacija sa id-em " + id + " ne postoji");
        }

        educationRepository.deleteById(id);
        return new ResponseMessageDTO("Uspjesno obrisana edukacija sa id-em " + id).getHashMap();
    }

    public Education findById(Integer id) throws Exception {
        return educationRepository.findById(id).orElseThrow(() -> new Exception("Edukacija sa id-em " + id + " ne postoji"));
    }
}
