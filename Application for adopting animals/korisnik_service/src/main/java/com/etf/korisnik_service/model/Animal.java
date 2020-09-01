package com.etf.korisnik_service.model;

import javax.persistence.*;

@Entity
@Table(name = "Animal")
public class Animal {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;
    private Integer animalId;
    private String name;
    private String species;
    private String gender;

    public Animal() {
    }

    public Animal(Integer animalId, String name, String species, String gender) {
        this.animalId = animalId;
        this.name = name;
        this.species = species;
        this.gender = gender;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Integer getAnimalId() {
        return animalId;
    }

    public void setAnimalId(Integer animalId) {
        this.animalId = animalId;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSpecies() {
        return species;
    }

    public void setSpecies(String vrsta) {
        this.species = vrsta;
    }

    public String getGender() {
        return gender;
    }

    public void setGender(String spol) {
        this.gender = spol;
    }

    @Override
    public String toString() {
        return "Animal{" +
                "id=" + id +
                ", animalId=" + animalId +
                ", name='" + name + '\'' +
                ", species='" + species + '\'' +
                ", gender='" + gender + '\'' +
                '}';
    }
}

