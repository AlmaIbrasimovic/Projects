package com.etf.korisnik_service;

import com.fasterxml.jackson.databind.ObjectMapper;
import org.hamcrest.Matchers;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;

import static org.hamcrest.Matchers.hasSize;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@SpringBootTest
@AutoConfigureMockMvc
public class UserAnimalControllerTest {

    @Autowired
    private MockMvc mockMvc;

    public static String asJsonString(final Object obj) {
        try {
            return new ObjectMapper().writeValueAsString(obj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

//    @org.junit.jupiter.api.Test
//    public void getListOfAnimalsFromUser() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/user_animal/dajZivotinju/{idKorisnika}",1)
//                .accept(MediaType.APPLICATION_XML))
//                .andExpect(status().isOk());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void getListOfAnimalsFromUserFail() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/user_animal/dajZivotinju/{idKorisnika}",2)
//                .accept(MediaType.APPLICATION_XML))
//                .andExpect(status().is5xxServerError());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void getListOfAnimals() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/user_animal/sveZivotinje")
//                .accept(MediaType.APPLICATION_XML))
//                .andExpect(status().is2xxSuccessful());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void getListOfAnimalsFailed() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/user_animal/sveZivotinje")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is4xxClientError());
//    }
}
