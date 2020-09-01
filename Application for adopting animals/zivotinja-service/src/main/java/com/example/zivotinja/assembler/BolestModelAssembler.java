package com.example.zivotinja.assembler;

import static org.springframework.hateoas.server.mvc.WebMvcLinkBuilder.*;

import com.example.zivotinja.controller.BolestController;
import com.example.zivotinja.model.Bolest;
import org.springframework.hateoas.EntityModel;
import org.springframework.hateoas.server.RepresentationModelAssembler;
import org.springframework.stereotype.Component;

@Component
public class BolestModelAssembler implements RepresentationModelAssembler<Bolest, EntityModel<Bolest>> {
    @Override
    public EntityModel<Bolest> toModel(Bolest bolest) {
        return new EntityModel<>(bolest,
                linkTo(methodOn(BolestController.class).one(bolest.getId())).withSelfRel(),
                linkTo(methodOn(BolestController.class).all()).withRel("bolesti"));
    }
}
