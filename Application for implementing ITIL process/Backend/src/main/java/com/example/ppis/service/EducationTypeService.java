package com.example.ppis.service;

import com.example.ppis.dto.ResponseMessageDTO;
import com.example.ppis.model.EducationType;
import com.example.ppis.model.SkillType;
import com.example.ppis.repository.EducationTypeRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

@Service
public class EducationTypeService {

    @Autowired
    EducationTypeRepository educationTypeRepository;

    public List<EducationType> getAll() {
        List<EducationType> all = new ArrayList<>();
        educationTypeRepository.findAll().forEach(all::add);
        return all;
    }

    public EducationType add(EducationType educationType) {

        return educationTypeRepository.save(educationType);
    }

    public EducationType update(EducationType newEducationType, Integer id) throws Exception {
        if (!educationTypeRepository.existsById(id)) {
            throw new Exception("Tip edukacije sa id-em " + id + " ne postoji");
        }
        educationTypeRepository.findById(id).map(
                educationType -> {
                    educationType.setName(newEducationType.getName());
                    return educationTypeRepository.save(educationType);
                }
        );
        return educationTypeRepository.findById(id).get();
    }

    public HashMap<String, String> delete(Integer id) throws Exception {
        if (!educationTypeRepository.existsById(id)) {
            throw new Exception("Tip vjestine sa id-em " + id + " ne postoji");
        }

        educationTypeRepository.deleteById(id);
        return new ResponseMessageDTO("Uspjesno obrisan tip edukacije sa id-em " + id).getHashMap();
    }
}
