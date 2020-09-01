package com.etf.korisnik_service.service;

import com.etf.korisnik_service.DTO.ResponseMessageDTO;
import com.etf.korisnik_service.model.Animal;
import com.etf.korisnik_service.model.User;
import com.etf.korisnik_service.model.UserAnimal;
import com.etf.korisnik_service.repository.AnimalRepository;
import com.etf.korisnik_service.repository.UserAnimalRepository;
import io.swagger.models.auth.In;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

@Service
public class AnimalService {
    @Autowired
    private AnimalRepository animalRepository;
    @Autowired
    private UserAnimalRepository userAnimalRepository;

    public Animal sacuvajZivotinju(Animal animal) {
        return animalRepository.save(animal);
    }

    public List<Animal> dajZivotinjuVrste(String vrsta) throws Exception {
        List<Animal> lista = animalRepository.findAllBySpecies(vrsta);
        if(lista.size() == 0) {
            throw new Exception("Ne postoji zivotinja navedene vrste");
        }
        return lista;
    }

    public Animal dajZivotinjuSaId(Integer id) throws Exception {
        Animal animal = animalRepository.findByAnimalId(id);
        if(animal == null) {
            throw  new Exception("Ne postoji zivotinja s id-em "+id);
        }
        return animal;
    }

    public List<Animal> dajSveZivotinje() throws Exception {
        if(animalRepository.count() == 0) {
            throw new Exception("Nema zivotinja u bazi");
        }
        List<Animal> sveZivotinje = new ArrayList<>();
        animalRepository.findAll().forEach(sveZivotinje::add);
        return sveZivotinje;
    }

    public HashMap<String,String> obrisiSIdem(Integer id) throws Exception {
        if(!animalRepository.existsByAnimalId(id)) {
            throw new Exception("Ne postoji zivotinja sa id-em "+id);
        }
        deleteDependencies(id);
        animalRepository.deleteByAnimalId(id);
        return new ResponseMessageDTO("Uspjesno obrisana zivotinja sa id-em "+ id).getHashMap();
    }

    private void deleteDependencies(Integer animalId) {
        List<UserAnimal> userAnimalsList = new ArrayList<>();
        userAnimalRepository.findAll().forEach(userAnimalsList::add);
        for (UserAnimal userAnimal : userAnimalsList) {
            if (animalId == -1) {
                userAnimalRepository.deleteAll();
                return;
            } else if (userAnimal.getUser().getId() == animalId) {
                userAnimalRepository.deleteById(userAnimal.getId());
            }
        }
    }


}
