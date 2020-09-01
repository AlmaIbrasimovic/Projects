package com.example.ppis.service;

import com.example.ppis.dto.ResponseMessageDTO;
import com.example.ppis.model.SkillType;
import com.example.ppis.model.Suplier;
import com.example.ppis.repository.SuplierRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

@Service
public class SuplierService {

    @Autowired
    private SuplierRepository suplierRepository;

    public List<Suplier> getAll() {
        List<Suplier> all = new ArrayList<>();
        suplierRepository.findAll().forEach(all::add);
        return all;
    }

    public Suplier add(Suplier suplier) {

        return suplierRepository.save(suplier);
    }

    public Suplier update(Suplier newSuplier, Integer id) throws Exception {
        if (!suplierRepository.existsById(id)) {
            throw new Exception("Dobavljac sa id-em " + id + " ne postoji");
        }
        suplierRepository.findById(id).map(
                suplier -> {
                    suplier.setName(newSuplier.getName());
                    suplier.setAdress(newSuplier.getAdress());
                    suplier.setContactPeroson(newSuplier.getContactPeroson());
                    return suplierRepository.save(suplier);
                }
        );
        return suplierRepository.findById(id).get();
    }

    public HashMap<String, String> delete(Integer id) throws Exception {
        if (!suplierRepository.existsById(id)) {
            throw new Exception("Dobavljac sa id-em " + id + " ne postoji");
        }

        suplierRepository.deleteById(id);
        return new ResponseMessageDTO("Uspjesno obrisan dobavljac sa id-em " + id).getHashMap();
    }
}
