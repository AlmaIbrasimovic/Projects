package com.etf.anketa_service.model;

import com.fasterxml.jackson.annotation.JsonIdentityInfo;
import com.fasterxml.jackson.annotation.ObjectIdGenerators;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.persistence.Id;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.validation.constraints.NotNull;
import java.util.List;

@JsonIdentityInfo(generator = ObjectIdGenerators.PropertyGenerator.class, property="id")
@Entity
@Table(name = "survey", schema = "public")
public class Survey {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(unique = true)
    @NotNull(message = "Obavezno je unijeti opis za anketu!")
    private String description;

    @Column
    @NotNull(message = "Obavezno je unijeti podatke o aktivnosti za anketu!")
    private boolean active;

    @OneToMany(mappedBy = "survey", cascade = CascadeType.REMOVE)
    private List<Question> surveyQuestions;

    @ManyToOne
    @JoinColumn(name = "animal_id", nullable = false)
    private Animal animal;

    public Survey() {}

    public Survey(String description, boolean active, List<Question> surveyQuestions, Animal animal) {
        this.description = description;
        this.active = active;
        this.surveyQuestions = surveyQuestions;
        this.animal = animal;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public boolean isActive() {
        return active;
    }

    public void setActive(boolean active) {
        this.active = active;
    }

    public List<Question> getSurveyQuestions() {
        return surveyQuestions;
    }

    public void setSurveyQuestions(List<Question> surveyQuestions) {
        this.surveyQuestions = surveyQuestions;
    }

    public Animal getAnimal() {
        return animal;
    }

    public void setAnimal(Animal animal) {
        this.animal = animal;
    }

    @Override
    public String toString() {
        String print = "Survey{" +
                       "id=" + id +
                       ", description='" + description + '\'' +
                       ", active=" + active +
                       ", animal=" + animal;
        if(getSurveyQuestions() != null) {
            print += ", surveyQuestions=" + surveyQuestions;
        }
        print += '}';
        return print;
    }
}
