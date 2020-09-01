package com.etf.korisnik_service;

import com.etf.korisnik_service.model.Animal;
import com.etf.korisnik_service.model.Role;
import com.etf.korisnik_service.model.User;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.hamcrest.Matchers;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;

import javax.transaction.Transactional;

import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@SpringBootTest
@AutoConfigureMockMvc
public class AnimalControllerTest {

    @Autowired
    private MockMvc mockMvc;

    public static String asJsonString(final Object obj) {
        try {
            return new ObjectMapper().writeValueAsString(obj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }
//
//   @Transactional
//    @org.junit.jupiter.api.Test
//    public void deleteUser() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/zivotinja/{animalId}",1)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno obrisana zivotinja sa id-em 1")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void addAnimal() throws Exception {
//        Animal animal = new Animal(53,"Albus","pas","M");
//        mockMvc.perform(MockMvcRequestBuilders.post("/zivotinja")
//                .content(asJsonString(animal))
//                .accept(MediaType.APPLICATION_JSON)
//                .contentType(MediaType.APPLICATION_JSON))
//                .andExpect(status().isCreated());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void geAnimalWithId() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/zivotinja/{id}",2)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void geAnimalWithIdFailed() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/zivotinja/{id}",234)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is5xxServerError());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void getAllAnimals() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/zivotinja/lista")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void getAnimalsWithSpecies() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/zivotinja/vrsta/{vrsta}","pas")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void getAnimalsWithSpeciesFailed() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/zivotinja/vrsta/{vrsta}","veliki pas")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is5xxServerError());
//    }
}
