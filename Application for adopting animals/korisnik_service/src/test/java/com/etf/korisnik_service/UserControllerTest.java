package com.etf.korisnik_service;

import com.etf.korisnik_service.DTO.LoginUserDTO;
import com.etf.korisnik_service.DTO.UserEmailDTO;
import com.etf.korisnik_service.DTO.UserPasswordDTO;
import com.etf.korisnik_service.DTO.UserRoleDTO;
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

import java.util.HashMap;

import static org.hamcrest.Matchers.hasSize;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@SpringBootTest
@AutoConfigureMockMvc
public class UserControllerTest {

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
//    public void login() throws Exception {
//        LoginUserDTO loginUserDTO = new LoginUserDTO("zkaric1@etf.unsa.ba", "novasifra");
//        mockMvc.perform(MockMvcRequestBuilders.post("/korisnik/prijava")
//                .content(asJsonString(loginUserDTO))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno ste prijavljeni na sistem")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void loginFailed() throws Exception {
//        LoginUserDTO loginUserDTO = new LoginUserDTO("zkaric1@etf.unsa.ba", "novasifra1");
//        mockMvc.perform(MockMvcRequestBuilders.post("/korisnik/prijava")
//                .content(asJsonString(loginUserDTO))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is5xxServerError())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Pogresna sifra!")));
//    }
//
//
//    @org.junit.jupiter.api.Test
//    public void getListOfUsers() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/korisnik/lista")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$", hasSize(4)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$[2].fullName", Matchers.is("zlata karic")));
//    }

//
//    @org.junit.jupiter.api.Test
//    public void failedApi() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/korisnik/listah")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is4xxClientError());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void geUserWithId() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/korisnik/{id}", 5)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void geUserWithIdFailed() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/korisnik/{id}", 55)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is4xxClientError())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Object not found")));
//
//    }
//
//    @org.junit.jupiter.api.Test
//    public void geUserWithFullName() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/korisnik/ime_prezime/{imePrezime}", "zlata karic")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void geUserWithFullNameFailed() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/korisnik/ime_prezime/{imePrezime}", "nema")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is5xxServerError())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Nema korisnika nema")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void changeEmail() throws Exception {
//        UserEmailDTO userEmailDTO = new UserEmailDTO(6,"novimail@gmail.com");
//        mockMvc.perform(MockMvcRequestBuilders.put("/korisnik/promijeni_email")
//                .content(asJsonString(userEmailDTO))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno promijenjen email")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void changeEmailFailed() throws Exception {
//        UserEmailDTO userEmailDTO = new UserEmailDTO(1,"novimail@gmail.com");
//        mockMvc.perform(MockMvcRequestBuilders.put("/korisnik/promijeni_email")
//                .content(asJsonString(userEmailDTO))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is4xxClientError())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Object not found")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void changeRole() throws Exception {
//        UserRoleDTO userRoleDTO = new UserRoleDTO(6,"veterinar");
//        mockMvc.perform(MockMvcRequestBuilders.put("/korisnik/promijeni_ulogu")
//                .content(asJsonString(userRoleDTO))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void changeRoleFailed() throws Exception {
//        UserRoleDTO userRoleDTO = new UserRoleDTO(6,"radnik");
//        mockMvc.perform(MockMvcRequestBuilders.put("/korisnik/promijeni_ulogu")
//                .content(asJsonString(userRoleDTO))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is5xxServerError())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Ne postoji uloga sa unesenim nazivom")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void addUser() throws Exception {
//        Role role = new Role("korisnik");
//        role.setId(2); //nema sve potrebne podatke za validaciju
//        User user = User.getDummyUser();
//        mockMvc.perform(MockMvcRequestBuilders.post("/korisnik")
//                .content(asJsonString(user))
//                .accept(MediaType.APPLICATION_JSON)
//                .contentType(MediaType.APPLICATION_JSON))
//                .andExpect(status().isCreated());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void addUserFailed() throws Exception {
//        Role role = new Role("korisnik");
//        role.setId(2); //nema sve potrebne podatke za validaciju
//        User user = new User("ante antic", "1234567899876", role);
//        mockMvc.perform(MockMvcRequestBuilders.post("/korisnik")
//                .content(asJsonString(user))
//                .contentType(MediaType.APPLICATION_JSON))
//                .andExpect(status().is5xxServerError());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void changePassword() throws Exception {
//        UserPasswordDTO userPasswordDTO = new UserPasswordDTO(7,"veterinar");
//        mockMvc.perform(MockMvcRequestBuilders.put("/korisnik/sifra")
//                .content(asJsonString(userPasswordDTO))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void changePasswordFailed() throws Exception {
//        UserPasswordDTO userPasswordDTO = new UserPasswordDTO(56,"veterinar");
//        mockMvc.perform(MockMvcRequestBuilders.put("/korisnik/sifra")
//                .content(asJsonString(userPasswordDTO))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is4xxClientError());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void getUsersWithRole() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/korisnik/uloga")
//                .param("uloga","korisnik")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void getUsersWithRoleError() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/korisnik/uloga")
//                .param("uloga","cistacica")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is5xxServerError());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void getUsersWithRoleFailed() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/korisnik/uloga")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is4xxClientError())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Required String parameter 'uloga' is not present")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void deleteUser() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/korisnik/{id}",4)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno obrisan korisnik sa id-em 4")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void deleteUserFailed() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/korisnik/{id}",66)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is4xxClientError())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Object not found")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void deleteAllUsers() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/korisnik/obrisi_sve")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno obrisani korisnici")));
//    }

}
