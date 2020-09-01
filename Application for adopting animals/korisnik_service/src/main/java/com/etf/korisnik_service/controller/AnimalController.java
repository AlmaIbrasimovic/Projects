package com.etf.korisnik_service.controller;

import com.etf.korisnik_service.model.Animal;
import com.etf.korisnik_service.repository.AnimalRepository;
import com.etf.korisnik_service.service.AnimalService;
import io.swagger.models.auth.In;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;

@RestController
public class AnimalController {

    @Autowired
    private AnimalService animalService;

    @PostMapping("/zivotinja")
    @ResponseStatus(HttpStatus.CREATED)
    public Animal sacuvajZivotinju(@RequestBody Animal animal) throws Exception {
        return animalService.sacuvajZivotinju(animal);
    }

    @GetMapping("/zivotinja/vrsta/{vrsta}")
    public List<Animal> dajZivotinjeSVrstom(@PathVariable String vrsta) throws Exception {
        return animalService.dajZivotinjuVrste(vrsta);
    }

    @GetMapping("/zivotinja/{id}")
    public Animal dajZivotinjuSId(@PathVariable Integer id) throws Exception {
        return animalService.dajZivotinjuSaId(id);
    }

    @GetMapping("/zivotinja/lista")
    public List<Animal> dajSveZivotinje() throws Exception {
        return animalService.dajSveZivotinje();
    }

    @DeleteMapping("/zivotinja/{animalId}")
    public HashMap<String,String> obrisiZivotinju(@PathVariable Integer animalId) throws Exception {
        return animalService.obrisiSIdem(animalId);
    }
}
