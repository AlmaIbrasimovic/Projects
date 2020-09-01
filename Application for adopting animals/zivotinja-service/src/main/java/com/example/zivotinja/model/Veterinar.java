package com.example.zivotinja.model;
import javax.persistence.*;
import javax.validation.constraints.NotBlank;
import java.util.HashSet;
import java.util.Set;

@Entity
public class Veterinar {

    // Atributi
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotBlank(message = "Ime je obavezno!")
    private String Ime;

    @NotBlank(message = "Prezime je obavezno!")
    private String Prezime;

    @NotBlank(message = "Kontakt telefon je obavezan!")
    private String kontaktTelefon; // Kad je potrebno revakcinisati zivotinju (mjeseci)

    @NotBlank(message = "Adresa je obavezna!")
    private String Adresa;

    // Relacije

    // Zivotinja n-n
    @ManyToMany(fetch = FetchType.LAZY, cascade = CascadeType.MERGE)
    @JoinTable(name = "veterinar_zivotinja",
            joinColumns = {
                    @JoinColumn(name = "zivotinjaID", referencedColumnName = "id", nullable = false, updatable = false)},
            inverseJoinColumns = {
                    @JoinColumn(name = "veterinarID", referencedColumnName = "id", nullable = false, updatable = false)})
    private Set<Zivotinja> Zivotinje = new HashSet<>();


    // Konstruktori
    public Veterinar() {
    }

    public Veterinar(String ime, String prezime, String telefon, String adresa) {
        Ime = ime;
        Prezime = prezime;
        kontaktTelefon = telefon;
        Adresa = adresa;
    }

    // Setters
    public void setAdresa(String adresa) {
        Adresa = adresa;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public void setKontaktTelefon(String kontaktTelefon) {
        this.kontaktTelefon = kontaktTelefon;
    }

    public void setIme(String ime) {
        Ime = ime;
    }

    public void setPrezime(String prezime) {
        Prezime = prezime;
    }

    // Getters
    public String getAdresa() {
        return Adresa;
    }

    public Set<Zivotinja> getZivotinje() {
        return Zivotinje;
    }

    public String getIme() {
        return Ime;
    }

    public String getKontaktTelefon() {
        return kontaktTelefon;
    }

    public String getPrezime() {
        return Prezime;
    }

    public Long getId() {
        return id;
    }
}
