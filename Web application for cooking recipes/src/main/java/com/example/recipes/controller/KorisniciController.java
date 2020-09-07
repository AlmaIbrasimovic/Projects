package com.example.recipes.controller;

import com.example.recipes.Exceptions.KorisniciException;
import com.example.recipes.model.Korisnici;
import com.example.recipes.repository.KorisniciRepository;
import com.example.recipes.service.KorisniciService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.server.ResponseStatusException;
import javax.validation.Valid;
import javax.validation.constraints.Min;
import java.util.List;
import java.util.Map;
import java.util.List;

@RestController
public class KorisniciController {

    @Autowired
    private KorisniciService korisniciService;
    public KorisniciController (KorisniciService korisniciService) {
        this.korisniciService = korisniciService;

    }

    @GetMapping ("/users")
    public List<Korisnici> getAllUsers () {
        return korisniciService.getAll();
    }

    /*
    @GetMapping ("/user/{id}")
    public Korisnici one (@PathVariable Long id) {
        return korisniciService.findOne(id);

       /* try {
            return korisniciService.findOne(id);
        }
        catch (KorisniciException e) {
            throw new ResponseStatusException(
                    HttpStatus.NOT_FOUND, "not found", e);
        }

    }*/
}
