package com.example.zivotinja.model;
import com.fasterxml.jackson.annotation.JsonIdentityInfo;
import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;
import com.fasterxml.jackson.annotation.ObjectIdGenerators;

@Entity
@JsonIdentityInfo(generator = ObjectIdGenerators.PropertyGenerator.class, property = "id")
public class Korisnik {

    // Atributi
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    private Boolean brisati;

    // Relacije

    // Zivotinja n-n
    @OneToMany(mappedBy = "korisnikId")
    private Set<Zivotinja> zivotinje = new HashSet<>();

    public Korisnik() {}
    public Korisnik (Boolean brisati) {
        this.brisati = brisati;
    }

    // GETTERS
    public Long getId() {
        return id;
    }
    public Set<Zivotinja> getZivotinje() {
        return zivotinje;
    }
    public Boolean getBrisati() { return brisati; }

    // SETTERS
    public void setId(Long id) {
        this.id = id;
    }
    public void setZivotinje (Set<Zivotinja> listZivotinja) {
        zivotinje = listZivotinja;
    }
    public void setBrisati(Boolean brisati) { this.brisati = brisati; }
}
