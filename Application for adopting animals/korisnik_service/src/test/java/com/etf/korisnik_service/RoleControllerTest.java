package com.etf.korisnik_service;

import com.etf.korisnik_service.model.Role;
import com.etf.korisnik_service.model.User;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.hamcrest.Matcher;
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
public class RoleControllerTest {

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
//    public void getListOfRoles() throws Exception{
//        mockMvc.perform(MockMvcRequestBuilders.get("/uloga/lista")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$",hasSize(3)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$[0].roleName", Matchers.is("administrator")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void addRole() throws Exception {
//        Role role = new Role("mesar");
//        mockMvc.perform(MockMvcRequestBuilders.post("/uloga")
//                .content(asJsonString(role))
//                .accept(MediaType.APPLICATION_JSON)
//                .contentType(MediaType.APPLICATION_JSON))
//                .andExpect(status().isCreated());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void addRoleFailed() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.post("/uloga")
//                .accept(MediaType.APPLICATION_JSON)
//                .contentType(MediaType.APPLICATION_JSON))
//                .andExpect(status().is4xxClientError());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void editRole() throws Exception {
//        Role role = new Role("mesar1");
//        role.setId(1);
//        mockMvc.perform(MockMvcRequestBuilders.put("/uloga")
//                .content(asJsonString(role))
//                .accept(MediaType.APPLICATION_JSON)
//                .contentType(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void editRoleFailed() throws Exception {
//        Role role = new Role("mesar1");
//        mockMvc.perform(MockMvcRequestBuilders.put("/uloga")
//                .content(asJsonString(role))
//                .accept(MediaType.APPLICATION_JSON)
//                .contentType(MediaType.APPLICATION_JSON))
//                .andExpect(status().is5xxServerError());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void getRoleWithId() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/uloga/{id}", 1)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void getRoleWithIdFailed() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/uloga/{id}", 551)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is4xxClientError())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Object not found")));
//
//    }
//
//    @org.junit.jupiter.api.Test
//    public void deleteRole() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/uloga/{id}",2)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno obrisana uloga sa id-em 2")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void deleteRoleFailed() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/uloga/{id}",22)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is4xxClientError())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Object not found")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void getRoleWithName() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/uloga/naziv")
//                .param("naziv_uloge","korisnik")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void getRoleWithNameFailed() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/uloga/naziv")
//                .param("naziv_uloge","uloga")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is5xxServerError())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Ne postoji uloga sa unesenim nazivom")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void deleteAllRoles() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/uloga/obrisi_sve")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno obrisane sve uloge")));
//    }

}
