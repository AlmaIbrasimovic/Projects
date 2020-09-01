package com.example.zivotinja.controller;
import com.example.zivotinja.model.Anketa;
import com.example.zivotinja.service.AnketaService;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.*;

@RestController
public class AnketaController {

    private AnketaService anketaService;

    public AnketaController (AnketaService anketaService) {
        this.anketaService = anketaService;
    }

    // GET metode
    @GetMapping ("/ankete")
    List<Anketa> all() {
        return anketaService.findAll();
    }

    @GetMapping("/ankete/{id}")
    public Anketa one(@PathVariable Long id) {
        return anketaService.findById(id);
    }

    @RequestMapping(value = "/ankete/zivotinja/{id}", produces = "application/xml", method = RequestMethod.GET)
    public ResponseEntity<String>  vratiZivotinju (@PathVariable Long id) {
        return anketaService.findZivotinja(id);
    }
}
