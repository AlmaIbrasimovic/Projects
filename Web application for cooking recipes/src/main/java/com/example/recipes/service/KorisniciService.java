package com.example.recipes.service;

import com.example.recipes.Exceptions.KorisniciException;
import com.example.recipes.Exceptions.RecipeException;
import com.example.recipes.model.Korisnici;
import com.example.recipes.repository.KorisniciRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import javax.validation.Valid;
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

    public Korisnici findOne (Long id) throws KorisniciException {
        return korisniciRepository.findById(id).orElseThrow(() -> new KorisniciException(id));
    }

    public void deleteAllUsers() throws Exception {
        if (korisniciRepository.count() == 0)  throw new Exception("There is no users to delete!");
        else korisniciRepository.deleteAll();
    }

    public void deleteById (Long id) throws Exception {
        if (!korisniciRepository.existsById(id)) throw new KorisniciException(id);
        else if (korisniciRepository.count() == 0) throw new Exception("There is no users to delete!");
        else korisniciRepository.deleteById(id);
    }

    public Korisnici createUser (Korisnici newUser) {
        return korisniciRepository.save(newUser);
    }

    public Korisnici updateUser (Korisnici newUser, Long id) throws Exception {
        if (!korisniciRepository.existsById(id)) throw new KorisniciException(id);
        return korisniciRepository.findById(id)
                .map(user -> {
                    user.setFirstName(newUser.getFirstName());
                    user.setLastName(newUser.getLastName());
                    user.setPassword(newUser.getPassword());
                    user.setUsername(newUser.getUsername());
                    return korisniciRepository.save(user);
                })
                .orElseGet(() -> {
                    newUser.setId(id);
                    return korisniciRepository.save(newUser);
                });
    }
}
