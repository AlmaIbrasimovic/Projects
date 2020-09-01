package com.etf.anketa_service.model;

import com.fasterxml.jackson.annotation.JsonIdentityInfo;
import com.fasterxml.jackson.annotation.ObjectIdGenerators;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import java.util.List;

@JsonIdentityInfo(generator = ObjectIdGenerators.PropertyGenerator.class, property="id")
@Entity
@Table(name = "animal", schema = "public")
public class Animal {
    @Id
    private Long id;

    @OneToMany(mappedBy = "animal", cascade = CascadeType.REMOVE)
    private List<Survey> surveys;

    public Animal() {}

    public Animal(Long id,
                  List<Survey> surveys) {
        this.id = id;
        this.surveys = surveys;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public List<Survey> getSurveys() {
        return surveys;
    }

    public void setSurveys(List<Survey> surveys) {
        this.surveys = surveys;
    }

    @Override
    public String toString() {
        String print = "Animal{" +
                "id=" + id;
        if(getSurveys() != null) {
            print += ", surveys=" + surveys;
        }
        print += '}';
        return print;
    }
}
