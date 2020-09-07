package com.example.recipes.service;

import com.example.recipes.repository.KorisniciRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class KorisniciService {
    @Autowired
    private KorisniciRepository korisniciRepository;

    public KorisniciService(KorisniciRepository korisniciRepository) {
        this.korisniciRepository = korisniciRepository;
    }
}
