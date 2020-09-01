package com.example.zivotinja.controller;
import com.example.zivotinja.model.Veterinar;
import com.example.zivotinja.service.VeterinarService;
import net.minidev.json.JSONObject;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import javax.validation.Valid;
import java.util.List;

@RestController
public class VeterinarController {

    private VeterinarService veterinarService;

    VeterinarController(VeterinarService veterinarService) {
        this.veterinarService = veterinarService;
    }

    // GET metode
    @GetMapping("/veterinari")
    public List<Veterinar> dobaviVeterinareIme(@RequestParam(value = "ime", required = false) String ime) throws Exception {
        if (ime != null) return veterinarService.findByName(ime);
        else return veterinarService.findAll();
    }

    @GetMapping("/veterinari/{id}")
    public Veterinar one(@PathVariable Long id) throws Exception {
        return veterinarService.findById(id);
    }

    // DELETE metode
    @DeleteMapping("/veterinari")
    ResponseEntity<JSONObject> izbrisiSveVeterinare(@RequestParam(value = "ime", required = false) String ime) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            if (ime != null) {
                veterinarService.deleteByName(ime);
                temp.put("message", "Uspjesno obrisan veterinar sa imenom: " + ime);
                return new ResponseEntity<>(
                        temp,
                        HttpStatus.OK
                );
            }
            else {
                veterinarService.deleteAll();
                temp.put("message", "Uspjesno obrisani svi veterinari!");
                return new ResponseEntity<>(
                        temp,
                        HttpStatus.OK
                );
            }
        }
        catch (Exception e) {
            temp.put("message", "Greska pri brisanju veterinara!");
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    @DeleteMapping("/veterinari/{id}")
    ResponseEntity<JSONObject> izbrisiVeterinara(@PathVariable Long id) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            veterinarService.deleteById(id);
            temp.put("message", "Uspjesno obrisan veterinar sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.OK
            );
        }
        catch (Exception e) {
            temp.put("message", "Greska pri brisanju veterinara sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    // PUT metode
    @PutMapping("/veterinari/{id}")
    ResponseEntity<JSONObject> updateVeterinar(@RequestBody Veterinar noviVeterinar, @PathVariable Long id) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            veterinarService.put(noviVeterinar, id);
            temp.put("message", "Uspjesno azuriran veterinar sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.OK
            );
        }
        catch (Exception e) {
            temp.put("message", "Greska pri azuriranje veterinara sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    // POST metode
    @PostMapping("/veterinari")
    Veterinar noviVeterinar(@Valid @RequestBody Veterinar nVet) {
        return veterinarService.post(nVet);
    }
}
