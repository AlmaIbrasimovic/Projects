package com.etf.anketa_service;

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
public class ApplicationUserControllerTests {
    /*@Autowired
    private MockMvc mockMvc;

    @org.junit.jupiter.api.Test
    public void getAllUsers() throws Exception {
        mockMvc.perform(MockMvcRequestBuilders.get("/v1/applicationUser/all")
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.jsonPath("$", hasSize(2)));
    }

    @org.junit.jupiter.api.Test
    public void getSpecifiedUser() throws Exception {
        int id = 1;
        mockMvc.perform(MockMvcRequestBuilders.get("/v1/applicationUser")
                .param("id", String.valueOf(id))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk());
    }

    @org.junit.jupiter.api.Test
    public void deleteSpecifiedUser() throws Exception {
        int id = 1;
        mockMvc.perform(MockMvcRequestBuilders.delete("/v1/applicationUser/deleteById")
                .param("id", String.valueOf(id))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno obrisan korisnik!")));
    }

    @org.junit.jupiter.api.Test
    public void failDeletingSpecifiedUser() throws Exception {
        int id = -5;
        mockMvc.perform(MockMvcRequestBuilders.delete("/v1/applicationUser/deleteById")
                .param("id", String.valueOf(id))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isBadRequest());
    }*/
}
