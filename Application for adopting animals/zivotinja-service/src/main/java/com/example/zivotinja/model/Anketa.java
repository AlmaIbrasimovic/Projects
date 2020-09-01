package com.example.zivotinja.model;
import javax.persistence.*;

@Entity
public class Anketa {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @ManyToOne
    @JoinColumn (name = "zivotinjaID", nullable = true)
    private Zivotinja zivotinjaID;

    public Anketa() {}

    // GETTERS
    public Long getId() {
        return id;
    }
    public Zivotinja getZivotinjaID() {
        return zivotinjaID;
    }

    // SETTERS
    public void setId(Long id) {
        this.id = id;
    }
    public void setZivotinjaID(Zivotinja zivotinjaID) {
        this.zivotinjaID = zivotinjaID;
    }
}
