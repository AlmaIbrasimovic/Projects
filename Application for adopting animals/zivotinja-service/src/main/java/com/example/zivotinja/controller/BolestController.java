package com.example.zivotinja.controller;
import com.example.zivotinja.model.Bolest;
import net.minidev.json.JSONObject;
import org.springframework.hateoas.EntityModel;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import java.util.List;
import org.springframework.hateoas.CollectionModel;
import com.example.zivotinja.service.BolestService;
import javax.validation.Valid;

@RestController
public class BolestController {

    private BolestService bolestService;

    BolestController(BolestService bolestService) {
        this.bolestService = bolestService;
    }

    // Bez Hateoas
    @GetMapping("/bolest")
    List<Bolest> dobaviBolestIme(@RequestParam(value = "ime", required = false) String ime) throws Exception {
        if (ime != null) return bolestService.findByName(ime);
        else return bolestService.findAll();
    }

    // Sa Hateoas
    @GetMapping("/bolesti")
    public CollectionModel<EntityModel<Bolest>> all() {
        return bolestService.findAllHateoas();
    }

    @GetMapping("/bolesti/{id}")
    public Bolest one(@PathVariable Long id) {
        return bolestService.findById(id);
        // return assembler.toModel(bolest);
    }

    // DELETE metode
    @DeleteMapping("/bolesti")
    ResponseEntity<JSONObject> izbrisiSveBolesti(@RequestParam(value = "ime", required = false) String ime) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            if (ime != null) {
                bolestService.deleteByName(ime);
                temp.put("message", "Uspjesno obrisana bolest sa imenom: " + ime);
                return new ResponseEntity<>(
                        temp,
                        HttpStatus.OK
                );
            }
            else {
                bolestService.deleteAll();
                temp.put("message", "Uspjesno obrisane sve bolesti!");
                return new ResponseEntity<>(
                        temp,
                        HttpStatus.OK
                );
            }
        }
        catch (Exception e) {
            temp.put("message", "Greska pri brisanju bolesti!");
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    @DeleteMapping("bolesti/{id}")
    ResponseEntity<JSONObject> izbrisiBolest(@PathVariable Long id) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            bolestService.deleteById(id);
            temp.put("message", "Uspjesno obrisana bolest sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.OK
            );
        }
        catch (Exception e) {
            temp.put("message", "Greska pri brisanju bolesti sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    // PUT metode
    @PutMapping("/bolesti/{id}")
    ResponseEntity<JSONObject> updateBolest(@RequestBody Bolest novaBolest, @PathVariable Long id) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            bolestService.put(novaBolest, id);
            temp.put("message", "Uspjesno azurirana bolest sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.OK
            );
        }
        catch (Exception e) {
            temp.put("message", "Greska pri azuriranje bolesti sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    // POST metode
    @PostMapping("/bolesti")
    Bolest novaBolest(@Valid @RequestBody Bolest nBol) {
        return bolestService.post(nBol);
    }
}

