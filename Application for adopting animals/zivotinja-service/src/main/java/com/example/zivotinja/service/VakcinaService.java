package com.example.zivotinja.service;
import com.example.zivotinja.exception.VakcinaException;
import com.example.zivotinja.model.Vakcina;
import com.example.zivotinja.repository.VakcinaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import java.util.*;

@Service
public class VakcinaService {
    @Autowired
    private VakcinaRepository vakcinaRepository;

    public VakcinaService(VakcinaRepository repo) {
        vakcinaRepository = repo;
    }

    public List<Vakcina> findAll() {
        return vakcinaRepository.findAll();
    }

    public List<Vakcina> findByType(String tip) throws Exception {
        if (vakcinaRepository.findByType(tip).size() == 0) {
            throw new Exception("Ne postoji vakcina za bolest " + tip);
        }
        return vakcinaRepository.findByType(tip);
    }

    public Vakcina findById(Long id) {
        return vakcinaRepository.findById(id).orElseThrow(() -> new VakcinaException(id));
    }

    public void deleteAll() throws Exception {
        if (vakcinaRepository.count() == 0) {
            throw new Exception("Ne postoji vise vakcina u bazi podataka");
        }
        vakcinaRepository.deleteAll();
    }

    public void deleteByType(String tip) throws Exception {
        if (vakcinaRepository.findByType(tip).size() == 0) {
            throw new Exception("Ne postoji vakcina za bolest " + tip);
        }
        vakcinaRepository.deleteByType(tip);
    }

    public void deleteById(Long id) throws Exception {
        if (!vakcinaRepository.existsById(id)) {
            throw new Exception("Ne postoji vakcina sa id " + id);
        }
        vakcinaRepository.deleteById(id);
    }

    public Vakcina put(Vakcina novaVakcina, Long id) throws Exception {
        if (!vakcinaRepository.existsById(id)) {
            throw new Exception("Ne postoji vakcina sa trazenim id " + id);
        }
        return vakcinaRepository.findById(id)
                .map(vakcina -> {
                    vakcina.setRevakcinacija(novaVakcina.getRevakcinacija());
                    vakcina.setTip(novaVakcina.getTip());
                    return vakcinaRepository.save(vakcina);
                })
                .orElseGet(() -> {
                    novaVakcina.setId(id);
                    return vakcinaRepository.save(novaVakcina);
                });
    }

    public Vakcina post(Vakcina nVak) {
        return vakcinaRepository.save(nVak);
    }

}
