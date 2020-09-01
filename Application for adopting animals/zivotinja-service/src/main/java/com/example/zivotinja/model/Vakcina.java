package com.example.zivotinja.model;
import com.fasterxml.jackson.annotation.JsonBackReference;
import org.hibernate.validator.constraints.Range;
import javax.persistence.*;
import javax.validation.constraints.*;
import java.util.HashSet;
import java.util.Set;

@Entity
public class Vakcina {

    // Atributi
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotBlank(message = "Tip vakcine je obavezan!")
    private String Tip;

    @NotNull(message = "Vrijednost revakcinacije je obavezan!")
    @Range(min = 1, max = 144, message = "Revakcinacija moze biti izmedu 1 i 144 mjeseci!")
    private Integer Revakcinacija; // Kad je potrebno revakcinisati zivotinju (mjeseci)

    // Relacije

    // Zivotinja n-n
    @ManyToMany(mappedBy = "Vakcine")
    @JsonBackReference
    private Set<Zivotinja> Zivotinje = new HashSet<>();

    // Konstruktori
    public Vakcina() {
    }

    public Vakcina(String tip, Integer revakcinacija) {
        Tip = tip;
        Revakcinacija = revakcinacija;
    }

    // Setters
    public void setRevakcinacija(Integer revakcinacija) {
        Revakcinacija = revakcinacija;
    }

    public void setTip(String tip) {
        Tip = tip;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public void setZivotinje (Set<Zivotinja> zivotinja) {
        Zivotinje = zivotinja;
    }

    // Getters
    public Integer getRevakcinacija() {
        return Revakcinacija;
    }

    public String getTip() {
        return Tip;
    }

    public Set<Zivotinja> getZivotinje() {
        return Zivotinje;
    }

    public Long getId() {
        return id;
    }
}
