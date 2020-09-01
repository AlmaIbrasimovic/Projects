package com.example.systemevents;

import com.example.systemevents.PetFriend;

import javax.persistence.*;

@Entity
@Table(name = "Akcija")
public class Action {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Integer id;
    private String nazivMikroservisa;
    private String Korisnik;
    private PetFriend.Request.tipAkcije Akcija;
    private String Odgovor;

    public Action() {
    }

    public Action(String nazivMikroservisa, String korisnik, PetFriend.Request.tipAkcije akcija, String odgovor) {
        this.nazivMikroservisa = nazivMikroservisa;
        this.Korisnik = korisnik;
        this.Akcija = akcija;
        this.Odgovor = odgovor;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getNazivMikroservisa() {
        return nazivMikroservisa;
    }

    public void setNazivMikroservisa(String nazivMikroservisa) {
        this.nazivMikroservisa = nazivMikroservisa;
    }

    public String getKorisnik() {
        return Korisnik;
    }

    public void setKorisnik(String korisnik) {
        Korisnik = korisnik;
    }

    public PetFriend.Request.tipAkcije getAkcija() {
        return Akcija;
    }

    public void setAkcija(PetFriend.Request.tipAkcije akcija) {
        Akcija = akcija;
    }

    public String getOdgovor() {
        return Odgovor;
    }

    public void setOdgovor(String odgovor) {
        Odgovor = odgovor;
    }

    @Override
    public String toString() {
        return "Action{" +
                "id=" + id +
                ", nazivMikroservisa='" + nazivMikroservisa + '\'' +
                ", Korisnik='" + Korisnik + '\'' +
                ", Akcija=" + Akcija +
                ", Odgovor=" + Odgovor +
                '}';
    }
}
