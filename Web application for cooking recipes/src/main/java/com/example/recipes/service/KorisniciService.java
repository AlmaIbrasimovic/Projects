package com.example.recipes.service;

import com.example.recipes.Exceptions.KorisniciException;
import com.example.recipes.Exceptions.RecipeException;
import com.example.recipes.model.Korisnici;
import com.example.recipes.repository.KorisniciRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import java.util.List;

@Service
public class KorisniciService {
    @Autowired
    private KorisniciRepository korisniciRepository;

    public KorisniciService(KorisniciRepository korisniciRepository) {
        this.korisniciRepository = korisniciRepository;
    }

    public List<Korisnici> getAll() {
        return korisniciRepository.findAll();
    }

    public Korisnici findOne (Long id) {
        return korisniciRepository.findById(id).orElseThrow(() -> new KorisniciException(id));
    }
}
