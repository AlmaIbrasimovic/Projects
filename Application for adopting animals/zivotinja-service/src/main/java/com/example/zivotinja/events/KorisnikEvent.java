package com.example.zivotinja.events;

import com.example.zivotinja.model.Korisnik;
import org.springframework.context.ApplicationEvent;

public class KorisnikEvent  extends ApplicationEvent {

    private Boolean Udomljena = false;
    private Integer Uspjesno;  // -1 oznacava da je vec udomljena i da ne moze, 1 da nije i da moze

    public KorisnikEvent(Object source) {
        super(source);
    }

    public String toString() {
        if (!Udomljena) return "Životinja uspješno udomljena!";
        else return "Životinja je već udomljena!";
    }

    public Boolean getUdomljena() {
        return Udomljena;
    }

    public void setUdomljena(Boolean udomljena) {
        Udomljena = udomljena;
    }

    public Integer getUspjesno() {
        return Uspjesno;
    }

    public void setUspjesno() {
        if (getUdomljena()) Uspjesno = -1;
        else Uspjesno = 1;
    }
}
