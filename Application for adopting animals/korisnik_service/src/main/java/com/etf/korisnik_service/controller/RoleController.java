package com.etf.korisnik_service.controller;

import com.etf.korisnik_service.model.Role;
import com.etf.korisnik_service.service.RoleService;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import javax.validation.Valid;
import java.util.HashMap;
import java.util.List;

@RestController
public class RoleController {

    private RoleService roleService;

    public RoleController(RoleService roleService) {
        this.roleService = roleService;
    }

    //Dodavanje uloga
    @PostMapping("/uloga")
    @ResponseStatus(HttpStatus.CREATED)
    Role dodajUlogu(@RequestBody @Valid Role role) {
        return roleService.addNewRole(role);
    }

    //Editovanje uloge
    @PutMapping("/uloga")
    Role editujUlogu(@RequestBody Role novaRole) throws Exception {
        return roleService.editRole(novaRole,novaRole.getId());
    }

    //Brisanje uloge
    @DeleteMapping("/uloga/{id}")
    HashMap<String,String> obrisiUlogu(@PathVariable Integer id) throws Exception {
        return roleService.deleteRole(id);
    }

    //Lista svih uloga
    @GetMapping("/uloga/lista")
    List<Role> listaUloga() {
        return roleService.getAllRoles();
    }

    //Uloga sa određenim id-em
    @GetMapping("/uloga/{id}")
    Role dajUlogu(@PathVariable Integer id) throws Exception {
        return roleService.getById(id);
    }

    @GetMapping("/uloga/naziv")
    Role dajUloguSaNazivom(@RequestParam(name = "naziv_uloge", required = false) String naziv) throws Exception {
        return roleService.getByName(naziv);
    }

    //Obrisi sve uloge
    @DeleteMapping("/uloga/obrisi_sve")
    HashMap<String,String> obrisiSveUlog() throws Exception {
        return roleService.deleteAllRoles();
    }
}
