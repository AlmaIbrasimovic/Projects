package com.example.zivotinja.controller;

import com.example.zivotinja.model.Vakcina;
import com.example.zivotinja.service.VakcinaService;
import net.minidev.json.JSONObject;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.List;

@RestController
public class VakcinaController {

    private VakcinaService vakcinaService;

    public VakcinaController(VakcinaService vakcinaService) {
        this.vakcinaService = vakcinaService;
    }

    // GET metode
    @GetMapping("/vakcine")
    List<Vakcina> dobaviVakcineTip(@RequestParam(value = "tip", required = false) String tip) throws Exception {
        if (tip != null) return vakcinaService.findByType(tip);
        else return vakcinaService.findAll();
    }

    @GetMapping("/vakcine/{id}")
    public Vakcina one(@PathVariable Long id) {
        return vakcinaService.findById(id);
    }

    // DELETE metode
    @DeleteMapping("/vakcine")
    ResponseEntity<JSONObject> izbrisiSveVakcine(@RequestParam(value = "tip", required = false) String tip) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            if (tip != null) {
                vakcinaService.deleteByType(tip);
                temp.put("message", "Uspjesno obrisana vakcina tipa: " + tip);
                return new ResponseEntity<>(
                        temp,
                        HttpStatus.OK
                );
            }
            else {
                vakcinaService.deleteAll();
                temp.put("message", "Uspjesno obrisane sve vakcine!");
                return new ResponseEntity<>(
                        temp,
                        HttpStatus.OK
                );
            }
        }
        catch (Exception e) {
            temp.put("message", "Greska pri brisanju vakcina/e!");
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    @DeleteMapping("vakcine/{id}")
    ResponseEntity<JSONObject> izbrisiVakcinu(@PathVariable Long id) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            vakcinaService.deleteById(id);
            temp.put("message", "Uspjesno obrisana vakcina sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.OK
            );
        }
        catch (Exception e) {
            temp.put("message", "Greska pri brisanju vakcine sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    // PUT metode
    @PutMapping("/vakcine/{id}")
    ResponseEntity<JSONObject> updateVakcina(@RequestBody Vakcina novaVakcina, @PathVariable Long id) throws Exception {
        JSONObject temp = new JSONObject();
        try {
            vakcinaService.put(novaVakcina, id);
            temp.put("message", "Uspjesno azurirana vakcina sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.OK
            );
        }
        catch (Exception e) {
            temp.put("message", "Greska pri azuriranje vakcine sa id " + id);
            return new ResponseEntity<>(
                    temp,
                    HttpStatus.BAD_REQUEST
            );
        }
    }

    // POST metode
    @PostMapping("/vakcine")
    Vakcina novaVakcina(@Valid @RequestBody Vakcina nVak) {
        return vakcinaService.post(nVak);
    }
}
