package com.example.ppis.controller;

import com.example.ppis.model.SkillType;
import com.example.ppis.model.Suplier;
import com.example.ppis.service.SkillTypeService;
import com.example.ppis.service.SuplierService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;

@RestController
public class SuplierController {

    @Autowired
    SuplierService suplierService;

    @PostMapping("/suppliers")
    @ResponseStatus(HttpStatus.CREATED)
    Suplier add(@RequestBody Suplier suplier) {
        return suplierService.add(suplier);
    }

    @PutMapping("/suppliers")
    Suplier update(@RequestBody Suplier newSupplier) throws Exception {
        return suplierService.update(newSupplier, newSupplier.getId());
    }

    @DeleteMapping("/suppliers/{id}")
    HashMap<String,String> delete(@PathVariable Integer id) throws Exception {
        return suplierService.delete(id);
    }

    @GetMapping("/suppliers")
    List<Suplier> getAll() {
        return suplierService.getAll();
    }
}
