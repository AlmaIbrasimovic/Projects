package com.example.zivotinja.service;
import com.example.zivotinja.assembler.BolestModelAssembler;
import com.example.zivotinja.controller.BolestController;
import com.example.zivotinja.exception.BolestException;
import com.example.zivotinja.model.Bolest;
import com.example.zivotinja.repository.BolestRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.hateoas.CollectionModel;
import org.springframework.hateoas.EntityModel;
import org.springframework.stereotype.Service;
import java.util.List;
import java.util.stream.Collectors;
import static org.springframework.hateoas.server.mvc.WebMvcLinkBuilder.linkTo;
import static org.springframework.hateoas.server.mvc.WebMvcLinkBuilder.methodOn;

@Service
public class BolestService {

    @Autowired
    private BolestRepository bolestRepository;
    private final BolestModelAssembler assembler;

    public BolestService(BolestRepository bolestRepository, BolestModelAssembler assembler) {
        this.bolestRepository = bolestRepository;
        this.assembler = assembler;
    }

    public Bolest findById(Long id) {
        return bolestRepository.findById(id).orElseThrow(() -> new BolestException(id));
    }

    public List<Bolest> findAll() {
        return bolestRepository.findAll();
    }

    public List<Bolest> findByName(String ime) throws Exception {
        if (bolestRepository.findByName(ime).size() == 0) {
            throw new Exception("Ne postoji bolest sa trazenim imenom " + ime);
        }
        return bolestRepository.findByName(ime);
    }

    public void deleteAll() throws Exception {
        if (bolestRepository.count() == 0) {
            throw new Exception("Ne postoji vise bolesti u bazi podataka");
        }
        bolestRepository.deleteAll();
    }

    public void deleteByName(String ime) throws Exception {
        if (bolestRepository.count() == 0) {
            throw new Exception("Ne postoji vise bolesti u bazi podataka");
        }
        if (bolestRepository.findByName(ime).size() == 0) {
            throw new Exception("Ne postoji bolest sa trazenim imenom " + ime);
        }
        bolestRepository.deleteByName(ime);
    }

    public void deleteById(Long id) throws Exception {
        if (!bolestRepository.existsById(id)) {
            throw new Exception("Ne postoji bolest sa id " + id);
        }
        bolestRepository.deleteById(id);
    }

    public Bolest put(Bolest novaBolest, Long id) throws Exception {
        if (!bolestRepository.existsById(id)) {
            throw new Exception("Ne postoji bolest sa trazenim id " + id);
        }
        return bolestRepository.findById(id)
                .map(bolest -> {
                    bolest.setIme(novaBolest.getIme());
                    bolest.setLijek(novaBolest.getLijek());
                    return bolestRepository.save(bolest);
                })
                .orElseGet(() -> {
                    novaBolest.setId(id);
                    return bolestRepository.save(novaBolest);
                });
    }

    public Bolest post(Bolest nBol) {
        return bolestRepository.save(nBol);
    }

    public CollectionModel<EntityModel<Bolest>> findAllHateoas() {
        List<EntityModel<Bolest>> employees = bolestRepository.findAll().stream()
                .map(assembler::toModel)
                .collect(Collectors.toList());

        return new CollectionModel<>(employees,
                linkTo(methodOn(BolestController.class).all()).withSelfRel());
    }
}
