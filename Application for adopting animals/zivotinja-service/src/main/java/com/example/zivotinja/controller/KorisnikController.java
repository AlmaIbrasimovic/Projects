package com.example.zivotinja.controller;

import com.example.zivotinja.events.KorisnikEvent;
import com.example.zivotinja.model.Korisnik;
import com.example.zivotinja.model.Zivotinja;
import com.example.zivotinja.service.KorisnikService;
import com.example.zivotinja.service.ZivotinjaService;
import net.minidev.json.JSONObject;
import org.springframework.context.ApplicationEventPublisher;
import org.springframework.context.ApplicationEventPublisherAware;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.util.List;

@RestController
public class KorisnikController implements ApplicationEventPublisherAware {

    private KorisnikService korisnikService;
    private ZivotinjaService zivotinjaService;
    private ApplicationEventPublisher publisher;

    KorisnikController(KorisnikService korisnikService, ZivotinjaService zivotinjaService) {
        this.korisnikService = korisnikService;
        this.zivotinjaService = zivotinjaService;
    }

    // GET metode
    @GetMapping("/korisnici")
    List<Korisnik> all() {
        return korisnikService.findAll();
    }

    @GetMapping("/korisnici/{id}")
    public Korisnik one(@PathVariable Long id) {
        return korisnikService.findById(id);
    }

    @GetMapping ("korisnici/flag/{id}")
    public Boolean vratiFlag (@PathVariable Long id) {
        return korisnikService.findFlag(id);
    }

    // DELETE metode
    @DeleteMapping ("/korisnici/{id}")
    ResponseEntity<JSONObject> obrisiKorisnika (@PathVariable Long id) throws Exception{
        JSONObject temp = new JSONObject();
        try {
            korisnikService.deleteById(id);
            temp.put("message", "Uspjesno obrisan korisnik sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.OK
            );
        }
        catch (Exception e) {
            temp.put("message", "Greska pri brisanju korisnika sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    // PUT metode
    // Metoda za azuriranje flaga za brisanje
    @PutMapping("/korisnici/{id}")
    ResponseEntity<JSONObject> postaviFlag( @PathVariable Long id) throws Exception {
        return korisnikService.azurirajFlag(id);
    }

    // Za komunikaciju izmedu mikroservisa KORISNIK i ZIVOTINJA (kada udomi)
    @PutMapping("udomi/{idKorisnika}/{idZivotinje}")
    public ResponseEntity<JSONObject> udomiZivotinju(@PathVariable Long idKorisnika, @PathVariable Long idZivotinje) throws Exception {
        JSONObject temp = new JSONObject();
        Boolean udomljena = false;
        try {
            Zivotinja novaZivotinja = zivotinjaService.findById(idZivotinje);
            KorisnikEvent event = new KorisnikEvent(this);
            event.setUdomljena(novaZivotinja.isUdomljena());
            event.setUspjesno();
            publisher.publishEvent(event);
            if (event.getUspjesno() == 1) novaZivotinja.setUdomljena(true);
            else {
                udomljena = true;
                throw new Exception("Životinja je već udomljena!");
            }
            Korisnik korisnik = korisnikService.findById(idKorisnika);
            novaZivotinja.setKorisnikId(korisnik);
            zivotinjaService.put(novaZivotinja, idZivotinje);
            temp.put("message", "Korisnik sa id  " + idKorisnika + " je udomio zivotinju sa id  " + idZivotinje);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.OK
            );
        } catch (Exception e) {
            if (udomljena) temp.put("message","Životinja je već udomljena!");
            else temp.put("message", "Greska pri udomljavanju zivotinje!");
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    @Override
    public void setApplicationEventPublisher(ApplicationEventPublisher publisher) {
        this.publisher = publisher;
    }
}

