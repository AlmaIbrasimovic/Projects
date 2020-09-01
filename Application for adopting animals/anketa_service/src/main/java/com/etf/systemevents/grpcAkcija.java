package com.etf.systemevents;

import java.util.Date;

public class grpcAkcija {

    // Enum tipovi
    enum tipAkcije {
        CREATE,
        DELETE,
        GET,
        UPDATE
    }
    enum tipOdgovora {
        USPJESNO,
        GRESKA
    };

    private Date timeStampAkcije;
    private String nazivMikroservisa;
    private String Korisnik;
    private tipAkcije Akcija;
    private tipOdgovora Odgovor;
    private String nazivResursa;

    // Konstruktori
    public grpcAkcija() {}

    public grpcAkcija(Date timeStampAkcije,
                      String nazivMikroservisa,
                      String korisnik,
                      tipAkcije akcija,
                      tipOdgovora odgovor,
                      String nazivResursa) {
        this.timeStampAkcije = timeStampAkcije;
        this.nazivMikroservisa = nazivMikroservisa;
        Korisnik = korisnik;
        Akcija = akcija;
        Odgovor = odgovor;
        this.nazivResursa = nazivResursa;
    }

    // Getter i setter
    public Date getTimeStampAkcije() {
        return timeStampAkcije;
    }

    public void setTimeStampAkcije(Date timeStampAkcije) {
        this.timeStampAkcije = timeStampAkcije;
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

    public tipAkcije getAkcija() {
        return Akcija;
    }

    public void setAkcija(tipAkcije akcija) {
        Akcija = akcija;
    }

    public tipOdgovora getOdgovor() {
        return Odgovor;
    }

    public void setOdgovor(tipOdgovora odgovor) {
        Odgovor = odgovor;
    }

    public String getNazivResursa() {
        return nazivResursa;
    }

    public void setNazivResursa(String nazivResursa) {
        this.nazivResursa = nazivResursa;
    }

    @Override
    public String toString() {
        return "Akcija(" +
                ", timestamp" + timeStampAkcije.toString() +
                ", tipAkcije" + Akcija +
                ", nazivMikroserivsa" + nazivMikroservisa +
                ", nazivResursa" + nazivResursa +
                ")";
    }
}
