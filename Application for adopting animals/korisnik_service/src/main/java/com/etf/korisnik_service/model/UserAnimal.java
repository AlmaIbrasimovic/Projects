package com.etf.korisnik_service.model;

import javax.persistence.*;

@Entity
@Table(name = "UserAnimal")
public class UserAnimal {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;
    @ManyToOne(cascade = CascadeType.MERGE)
    private User user;
    @ManyToOne(cascade = CascadeType.MERGE) //@OneToOne?
    private Animal animal;


    public UserAnimal() {
    }

    public UserAnimal(User user, Animal animal) {
        this.user = user;
        this.animal = animal;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public User getUser() {
        return user;
    }

    public void setUser(User user) {
        this.user = user;
    }

    public Animal getAnimal() {
        return animal;
    }

    public void setAnimal(Animal animal) {
        this.animal = animal;
    }

    @Override
    public String toString() {
        return "UserAnimal{" +
                "id=" + id +
                ", user=" + user +
                ", animal=" + animal +
                '}';
    }
}
