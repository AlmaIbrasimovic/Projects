package com.etf.anketa_service.service;

import com.etf.anketa_service.exception.AnimalException;
import com.etf.anketa_service.model.Animal;
import com.etf.anketa_service.repository.AnimalRepository;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;

@Service
public class AnimalService {
    private AnimalRepository animalRepository;

    public AnimalService(AnimalRepository animalRepository) {
        this.animalRepository = animalRepository;
    }

    public List<Animal> getAll() {
        return animalRepository.findAll();
    }

    public List<Animal> addAnimals(List<Animal> animals) {
        List<Animal> returnValue = new ArrayList<>();
        for (Animal a: animals) {
            returnValue.add(animalRepository.save(a));
        }
        return returnValue;
    }

    public Animal findById(Long id) {
        return animalRepository.findById(id).orElseThrow(() -> new AnimalException(id));
    }

    public void deleteById(Long id) throws Exception {
        animalRepository.deleteById(id);
    }
}
