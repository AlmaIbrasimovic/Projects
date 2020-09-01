package com.example.zivotinja.model;

import com.fasterxml.jackson.annotation.*;
import org.hibernate.validator.constraints.Range;

import javax.persistence.*;
import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Pattern;
import java.io.File;
import java.io.FileInputStream;
import java.util.HashSet;
import java.util.Set;
import java.io.FileOutputStream;

@Entity
@JsonIdentityInfo(generator = ObjectIdGenerators.PropertyGenerator.class, property = "id")
public class Zivotinja {

    // Atributi
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @NotBlank(message = "Ime zivotinje je obavezno!")
    @Column(unique = true)
    private String Ime;

    @NotBlank(message = "Vrsta zivotinje je obavezna!")
    private String Vrsta;

    @NotBlank(message = "Rasa zivotinje je obavezna!")
    private String Rasa;

    @NotBlank(message = "Spol zivotinje je obavezan!")
    @Pattern(regexp = "Z|M", message = "Spol moze biti samo M ili Z!", flags = Pattern.Flag.CASE_INSENSITIVE)
    private String Spol;

    @NotNull(message = "Godine zivotinje su obavezna!")
    @Range(min = 1, max = 25, message = "Godine zivotinje ne mogu biti vece od 25 i manje od 1!")
    private int Godine;

    @NotBlank(message = "Velicina zivotinje je obavezna!")
    private String Velicina;

    @NotNull(message = "Tezina zivotinje je obavezna")
    private int Tezina;

    private String dodatniOpis;

    @NotNull(message = "Status zivotinje, da li je udomljena ili ne, je obavezno!")
    private Boolean Udomljena;

    @Lob
    private byte[] Slika;

    // Relacije
    // Vakcina n-n

    @ManyToMany(fetch = FetchType.LAZY, cascade = CascadeType.MERGE)
    @JoinTable(name = "vakcina_zivotinja",
            joinColumns = {
                    @JoinColumn(name = "zivotinjaID", referencedColumnName = "id", nullable = false, updatable = false)},
            inverseJoinColumns = {
                    @JoinColumn(name = "vakcinaID", referencedColumnName = "id", nullable = false, updatable = false)})
    private Set<Vakcina> Vakcine = new HashSet<>();

    // Veterinar n-n
    @ManyToMany(fetch = FetchType.LAZY, cascade = CascadeType.MERGE)
    @JoinTable(name = "veterinar_zivotinja",
            joinColumns = {
                    @JoinColumn(name = "zivotinjaID", referencedColumnName = "id", nullable = false, updatable = false)},
            inverseJoinColumns = {
                    @JoinColumn(name = "veterinarID", referencedColumnName = "id", nullable = false, updatable = false)})
    private Set<Veterinar> Veterinari = new HashSet<>();

    // Bolest n-n
    @ManyToMany(fetch = FetchType.LAZY, cascade = CascadeType.MERGE)
    @JoinTable(name = "bolest_zivotinja",
            joinColumns = {
                    @JoinColumn(name = "zivotinjaID", referencedColumnName = "id", nullable = false, updatable = false)},
            inverseJoinColumns = {
                    @JoinColumn(name = "bolestID", referencedColumnName = "id", nullable = false, updatable = false)})
    private Set<Bolest> Bolesti = new HashSet<>();

    // Korisnik 1-N
    @ManyToOne
    @JoinColumn(name = "korisnikID", nullable = true)
    private Korisnik korisnikId;

    // Anketa n-1
    @OneToMany(mappedBy = "zivotinjaID")
    private Set<Anketa> ankete = new HashSet<>();

    // Konstruktori
    public Zivotinja() {
    }

    public Zivotinja(String ime, String vrsta, String rasa, String spol, int godine, String velicina, int tezina, String opis, Boolean udomljena, byte[] slika) {
        Ime = ime;
        Vrsta = vrsta;
        Rasa = rasa;
        Spol = spol;
        Godine = godine;
        Velicina = velicina;
        Tezina = tezina;
        Slika = slika;
        dodatniOpis = opis;
        Udomljena = udomljena;
    }

    public Zivotinja(String ime, String vrsta, String rasa, String spol, int godine, String velicina, int tezina, String opis, Boolean udomljena) {
        Ime = ime;
        Vrsta = vrsta;
        Rasa = rasa;
        Spol = spol;
        Godine = godine;
        Velicina = velicina;
        Tezina = tezina;
        dodatniOpis = opis;
        Udomljena = udomljena;
    }

    // Getters
    public String getIme() {
        return Ime;
    }

    public String getVrsta() {
        return Vrsta;
    }

    public String getRasa() {
        return Rasa;
    }

    public int getGodine() {
        return Godine;
    }

    public String getSpol() {
        return Spol;
    }

    public String getVelicina() {
        return Velicina;
    }

    public int getTezina() {
        return Tezina;
    }

    public Boolean isUdomljena() {
        return Udomljena;
    }

    public Korisnik getKorisnikId() {
        return korisnikId;
    }

    public Long getId() {
        return id;
    }

    public String getDodatniOpis() {
        return dodatniOpis;
    }

    public byte[] getSlika() {
        return Slika;
    }

    public Set<Bolest> getBolesti() {
        return Bolesti;
    }

    public Set<Vakcina> getVakcine() {
        return Vakcine;
    }

    public Set<Veterinar> getVeterinari() {
        return Veterinari;
    }

    public Set<Anketa> getAnkete() {
        return ankete;
    }

    // Setters
    public void setIme(String ime) {
        Ime = ime;
    }

    public void setAnkete(Set<Anketa> ankete) {
        this.ankete = ankete;
    }

    public void setDodatniOpis(String dodatniOpis) {
        this.dodatniOpis = dodatniOpis;
    }

    public void setGodine(int godine) {
        Godine = godine;
    }

    public void setRasa(String rasa) {
        Rasa = rasa;
    }

    public void setSlika(byte[] slika) {
        Slika = slika;
    }

    public void setSpol(String spol) {
        Spol = spol;
    }

    public void setTezina(int tezina) {
        Tezina = tezina;
    }

    public void setVelicina(String velicina) {
        Velicina = velicina;
    }

    public void setVrsta(String vrsta) {
        Vrsta = vrsta;
    }

    public void setUdomljena(Boolean udomljena) {
        Udomljena = udomljena;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public void setKorisnikId(Korisnik Id) {
        korisnikId = Id;
    }

    // Metode

    // Metoda za kreiranje i snimanje slike u bazu
    public byte[] kreirajSliku(String putanja) {
        File slika = new File(putanja);
        byte[] bFile = new byte[(int) slika.length()];
        try {
            FileInputStream iStream = new FileInputStream(slika);

            // Konverzija u niz byte
            iStream.read(bFile);
            iStream.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
        return bFile;
    }

    // Metoda za preuzimanje slike iz baze i spremanje lokalno
    public void preuzmiSliku() {
        byte[] slika = this.getSlika();
        try {
            FileOutputStream oStream = new FileOutputStream("C:\\Users\\belma\\Desktop\\ETF\\NWT2020-petFriend\\zivotinja-service\\Slike iz baze\\test.jpg");
            oStream.write(slika);
            oStream.close();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
