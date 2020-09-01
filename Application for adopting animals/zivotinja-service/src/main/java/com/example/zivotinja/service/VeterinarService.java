package com.example.zivotinja.service;

import java.util.*;
import com.example.zivotinja.exception.VeterinarException;
import com.example.zivotinja.model.Veterinar;
import com.example.zivotinja.repository.VeterinarRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class VeterinarService {
    @Autowired
    private VeterinarRepository veterinarRepository;

    public VeterinarService(VeterinarRepository vet) {
        veterinarRepository = vet;
    }

    public List<Veterinar> findAll() {
        return veterinarRepository.findAll();
    }

    public List<Veterinar> findByName(String ime) throws Exception {
        if (veterinarRepository.findByName(ime).size() == 0) {
            throw new Exception("Ne postoji veterinar sa imenom " + ime);
        }
        return veterinarRepository.findByName(ime);
    }

    public Veterinar findById(Long id) throws Exception {
        return veterinarRepository.findById(id).orElseThrow(() -> new VeterinarException(id));
    }

    public void deleteAll() throws Exception {
        if (veterinarRepository.count() == 0) {
            throw new Exception("Ne postoji vise veterinara u bazi podataka!");
        }
        veterinarRepository.deleteAll();
    }

    public void deleteByName(String ime) throws Exception {
        if (veterinarRepository.findByName(ime).size() == 0) {
            throw new Exception("Ne postoji veterinar sa imenom " + ime);
        }
        if (ime != null) veterinarRepository.deleteByName(ime);
    }

    public void deleteById(Long id) throws Exception {
        if (!veterinarRepository.existsById(id)) {
            throw new Exception("Ne postoji veterinar sa id " + id);
        }
        veterinarRepository.deleteById(id);
    }

    public Veterinar put(Veterinar noviVeterinar, Long id) throws Exception {
        if (!veterinarRepository.existsById(id)) {
            throw new Exception("Ne postoji veterinar sa id " + id);
        }
        return veterinarRepository.findById(id)
                .map(veterinar -> {
                    veterinar.setAdresa(noviVeterinar.getAdresa());
                    veterinar.setIme(noviVeterinar.getIme());
                    veterinar.setKontaktTelefon(noviVeterinar.getKontaktTelefon());
                    veterinar.setPrezime(noviVeterinar.getPrezime());
                    return veterinarRepository.save(veterinar);
                })
                .orElseGet(() -> {
                    noviVeterinar.setId(id);
                    return veterinarRepository.save(noviVeterinar);
                });
    }

    public Veterinar post(Veterinar nVet) {
        return veterinarRepository.save(nVet);
    }
}
