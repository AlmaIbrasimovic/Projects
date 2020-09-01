package com.etf.anketa_service.model;

import com.fasterxml.jackson.annotation.JsonIdentityInfo;
import com.fasterxml.jackson.annotation.ObjectIdGenerators;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;
import javax.validation.constraints.NotNull;
import java.util.List;

@JsonIdentityInfo(generator = ObjectIdGenerators.PropertyGenerator.class, property="id")
@Entity
@Table(name = "possible_answer", schema = "public")
public class PossibleAnswer {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column
    @NotNull(message = "Obavezno je zadati tekst ponudjenog odgovora!")
    private String answer;

    @Column
    @NotNull(message = "Obavezno je unijeti broj bodova za pitanje")
    private Long points;

    @ManyToOne
    @JoinColumn(name = "question_id", nullable = false)
    private Question question;

    @OneToMany(mappedBy = "possibleAnswer", cascade = CascadeType.REMOVE)
    private List<Answer> givenAnswers;

    public PossibleAnswer() {}

    public PossibleAnswer(String answer, Long points, Question question, List<Answer> givenAnswers) {
        this.answer = answer;
        this.points = points;
        this.question = question;
        this.givenAnswers = givenAnswers;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getAnswer() {
        return answer;
    }

    public void setAnswer(String answer) {
        this.answer = answer;
    }

    public Long getPoints() {
        return points;
    }

    public void setPoints(Long points) {
        this.points = points;
    }

    public Question getQuestion() {
        return question;
    }

    public void setQuestion(Question question) {
        this.question = question;
    }

    public List<Answer> getGivenAnswers() {
        return givenAnswers;
    }

    public void setGivenAnswers(List<Answer> givenAnswers) {
        this.givenAnswers = givenAnswers;
    }
}
