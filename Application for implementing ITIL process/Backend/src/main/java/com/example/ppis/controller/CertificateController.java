package com.example.ppis.controller;

import com.example.ppis.model.Certificate;
import com.example.ppis.repository.CertificateRepository;
import com.example.ppis.service.CertificateService;
import io.swagger.models.auth.In;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
public class CertificateController {

    @Autowired
    CertificateService certificateService;

    @PostMapping("/certificate")
    @ResponseStatus(HttpStatus.CREATED)
    Certificate add(@RequestBody Certificate certificate) {
        return certificateService.addCertificate(certificate);
    }

    @GetMapping("/certificate/{id}")
    Certificate getCertificateById(@PathVariable Integer id) throws Exception {
        return certificateService.getCertificateById(id);
    }

    @GetMapping("/certificate/all")
    List<Certificate> getAllCertificates() throws Exception {
        return certificateService.getAllCertificates();
    }

    @DeleteMapping("/certificate/{id}")
    void deleteCertificate(@PathVariable Integer id) throws Exception {
        certificateService.deleteCertificate(id);
    }
}
