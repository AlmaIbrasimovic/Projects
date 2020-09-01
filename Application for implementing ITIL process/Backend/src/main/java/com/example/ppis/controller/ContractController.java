package com.example.ppis.controller;

import com.example.ppis.model.Contract;
import com.example.ppis.model.Skill;
import com.example.ppis.service.ContractService;
import com.example.ppis.service.SkillService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;

import java.util.HashMap;
import java.util.List;

@RestController
public class ContractController {

    @Autowired
    ContractService contractService;

    @PostMapping("/contracts")
    @ResponseStatus(HttpStatus.CREATED)
    Contract add(@RequestBody Contract contract) throws Exception {
        return contractService.add(contract);
    }

    @PutMapping("/contracts")
    Contract update(@RequestBody Contract newContract) throws Exception {
        return contractService.update(newContract, newContract.getId());
    }

    @DeleteMapping("/contracts/{id}")
    HashMap<String,String> delete(@PathVariable Integer id) throws Exception {
        return contractService.delete(id);
    }

    @GetMapping("/contracts")
    List<Contract> getAll() {
        return contractService.getAll();
    }
}
