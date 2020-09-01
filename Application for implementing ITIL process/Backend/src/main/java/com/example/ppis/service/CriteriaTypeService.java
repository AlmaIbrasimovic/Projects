package com.example.ppis.service;

import com.example.ppis.dto.ResponseMessageDTO;
import com.example.ppis.model.CriteriaType;
import com.example.ppis.model.SkillType;
import com.example.ppis.repository.CriteriaTypeRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

@Service
public class CriteriaTypeService {

    @Autowired
    private CriteriaTypeRepository criteriaTypeRepository;

    public List<CriteriaType> getAll() {
        List<CriteriaType> all = new ArrayList<>();
        criteriaTypeRepository.findAll().forEach(all::add);
        return all;
    }

    public CriteriaType add(CriteriaType criteriaType) {

        return criteriaTypeRepository.save(criteriaType);
    }

    public CriteriaType update(CriteriaType newCriteria, Integer id) throws Exception {
        if (!criteriaTypeRepository.existsById(id)) {
            throw new Exception("Kriterij sa id-em " + id + " ne postoji");
        }
        criteriaTypeRepository.findById(id).map(
                criteriaType -> {
                    criteriaType.setName(newCriteria.getName());
                    criteriaType.setCoeficient(newCriteria.getCoeficient());
                    return criteriaTypeRepository.save(criteriaType);
                }
        );
        return criteriaTypeRepository.findById(id).get();
    }

    public HashMap<String, String> delete(Integer id) throws Exception {
        if (!criteriaTypeRepository.existsById(id)) {
            throw new Exception("Kriterij sa id-em " + id + " ne postoji");
        }

        criteriaTypeRepository.deleteById(id);
        return new ResponseMessageDTO("Uspjesno obrisan kriterij sa id-em " + id).getHashMap();
    }
}
