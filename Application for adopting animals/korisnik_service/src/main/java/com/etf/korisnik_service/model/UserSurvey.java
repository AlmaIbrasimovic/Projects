package com.etf.korisnik_service.model;

import javax.persistence.*;

@Entity
@Table(name = "UserSurvey")
public class UserSurvey {
    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;
    @ManyToOne(cascade = CascadeType.MERGE)
    private User user;
    @ManyToOne(cascade = CascadeType.MERGE)
    private Survey survey;

    public UserSurvey() {}

    public UserSurvey(User user, Survey survey) {
        this.user = user;
        this.survey = survey;
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

    public Survey getSurvey() {
        return survey;
    }

    public void setSurvey(Survey survey) {
        this.survey = survey;
    }
}
