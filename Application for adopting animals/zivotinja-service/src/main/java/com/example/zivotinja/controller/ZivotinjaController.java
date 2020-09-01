package com.example.zivotinja.controller;

import com.example.zivotinja.model.Korisnik;
import com.example.zivotinja.model.Zivotinja;
import com.example.zivotinja.service.KorisnikService;
import com.example.zivotinja.service.ZivotinjaService;
import com.netflix.discovery.EurekaClient;
import net.minidev.json.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.Bean;
import org.springframework.core.ParameterizedTypeReference;
import org.springframework.http.*;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.client.RestTemplate;

import javax.validation.Valid;
import javax.validation.constraints.Max;
import javax.ws.rs.Produces;
import java.util.List;
import java.util.Map;

import com.netflix.appinfo.InstanceInfo;
import com.netflix.discovery.shared.Application;

import static org.springframework.http.MediaType.APPLICATION_JSON;

@RestController
public class ZivotinjaController {

    private ZivotinjaService zivotinjaService;
    private KorisnikService korisnikService;

    @Autowired
    private RestTemplate restTemplate;

    private EurekaClient eurekaClient;

    ZivotinjaController(ZivotinjaService zivotinjaService, KorisnikService korisnikService) {
        this.zivotinjaService = zivotinjaService;
        this.korisnikService = korisnikService;
    }

    // GET metode

    @GetMapping("/zivotinje/{id}")
    public Zivotinja one(@PathVariable Long id) throws Exception {
        return zivotinjaService.findById(id);
    }

    @GetMapping("zivotinje/{id}/godine")
    public Map<String, Integer> vratiGodine(@PathVariable Long id) throws Exception {
        return zivotinjaService.getGodine(id);
    }

    @GetMapping("/zivotinje")
    public List<Zivotinja> dobaviZivotinjaIme(@RequestParam(value = "ime", required = false) String ime) throws Exception {
        if (ime != null) return zivotinjaService.findByName(ime);
        else return zivotinjaService.findAll();
    }

    // DELETE metode
    @DeleteMapping("/zivotinje")
    ResponseEntity<JSONObject> izbrisiSveZivotinje(@RequestParam(value = "ime", required = false) String ime) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            if (ime != null) {
                zivotinjaService.deleteByName(ime);
                temp.put("message", "Uspjesno obrisana zivotinja sa imenom: " + ime);
                return new ResponseEntity<>(
                        temp,
                        HttpStatus.OK
                );
            } else {
                zivotinjaService.deleteAll();
                temp.put("message", "Uspjesno obrisane sve zivotinje!");
                return new ResponseEntity<>(
                        temp,
                        HttpStatus.OK
                );
            }
        } catch (Exception e) {
            temp.put("message", "Greska pri brisanju zivotinja/e!");
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    @DeleteMapping("/zivotinje/{id}")
    ResponseEntity<JSONObject> izbrisiZivotinju(@PathVariable Long id) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            zivotinjaService.deleteById(id);
            temp.put("message", "Uspjesno obrisana zivotinja sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.OK
            );
        } catch (Exception e) {
            temp.put("message", "Greska pri brisanju zivotinje sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    // PUT metode
    @PutMapping("/zivotinje/{id}")
    ResponseEntity<JSONObject> updateZivotinje(@RequestBody Zivotinja novaZivotinja, @PathVariable Long id) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            zivotinjaService.put(novaZivotinja, id);
            temp.put("message", "Uspjesno azurirana zivotinja sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.OK
            );
        } catch (Exception e) {
            temp.put("message", "Greska pri azuriranju zivotinje sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    // POST metode
    @PostMapping("/zivotinje")
    Zivotinja novaZivotinja(@Valid @RequestBody Zivotinja nZivotinja) {
        return zivotinjaService.post(nZivotinja);
    }


    // Komunikacija između MS Zivotinja i MS Korisnik
    @RequestMapping(value = "/vratiKorisnike", produces = "application/xml", method = RequestMethod.GET)
    public ResponseEntity<String> getKorisnike() {
        String response = restTemplate.exchange("http://korisnikService/korisnik/lista",
                HttpMethod.GET, null, String.class).getBody();
        return new ResponseEntity<>(
                response,
                HttpStatus.OK
        );
    }

    // Za komunikaciju izmedu mikroservisa KORISNIK i ZIVOTINJA (kada udomi)
    @PutMapping("udomljena/{idKorisnika}/{idZivotinje}")
    public ResponseEntity<JSONObject> udomiZivotinja(@PathVariable Long idKorisnika, @PathVariable Long idZivotinje) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            Zivotinja novaZivotinja = zivotinjaService.findById(idZivotinje);
            novaZivotinja.setUdomljena(true);
            Korisnik korisnik = korisnikService.findById(idKorisnika);
            novaZivotinja.setKorisnikId(korisnik);
            zivotinjaService.put(novaZivotinja, idZivotinje);
            temp.put("message", "Zivotinja sa id " + idZivotinje + " je udomljena od strane korisnika sa id " + idKorisnika);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.OK
            );

        } catch (Exception e) {
            temp.put("message", "Greska pri udomljavanju zivotinje!");
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    @GetMapping ("/zivotinje/korisnik/{idKorisnika}")
    public List<Zivotinja> dajZivotinjeKorisnika (@PathVariable Long idKorisnika) throws  Exception {
        return zivotinjaService.zivotinjeKorisnika (idKorisnika);
    }
}
