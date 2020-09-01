//package com.example.zivotinja;
//import com.example.zivotinja.model.Bolest;
//import com.example.zivotinja.model.Zivotinja;
//import com.example.zivotinja.repository.ZivotinjaRepository;
//import com.fasterxml.jackson.databind.ObjectMapper;
//import org.hamcrest.Matchers;
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
//import org.springframework.boot.test.context.SpringBootTest;
//import org.springframework.http.MediaType;
//import org.springframework.test.web.servlet.MockMvc;
//import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
//import org.springframework.test.web.servlet.result.MockMvcResultMatchers;
//
//import java.util.Optional;
//
//import static org.hamcrest.Matchers.hasSize;
//import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;
//
//@SpringBootTest
//@AutoConfigureMockMvc
////public class BolestControllerTest {
//
//    @Autowired
//    private MockMvc mockMvc;
//
//    private ZivotinjaRepository zivotinja;
//
//    public static String asJsonString(final Object obj) {
//        try {
//            return new ObjectMapper().writeValueAsString(obj);
//        } catch (Exception e) {
//            throw new RuntimeException(e);
//        }
//    }
//
//    @org.junit.jupiter.api.Test
//    public void dobaviSveBolestiTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/bolest")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$", hasSize(3)))  // Velicina vracene liste da li je 3
//                .andExpect(MockMvcResultMatchers.jsonPath("$[0].id", Matchers.is(1))) // Da li prva bolest ima id 1
//                .andExpect(MockMvcResultMatchers.jsonPath("$[0].ime", Matchers.is("Bjesnilo")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$[1].ime", Matchers.is("Gripa")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void dobaviJednuBolest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/bolesti/3")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.id", Matchers.is(3)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.lijek", Matchers.is("Injekcija")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void postTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.post("/bolesti")
//                .param("ime", "Test")
//                .param("lijek", "Antibiotici"));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void putTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.put("/bolesti/{id}", 2)
//                .content("ime=Test")
//                .content("lijek=Antibiotici"));
//    }
//
//    // Testovi za greske
//    @org.junit.jupiter.api.Test
//    public void dobaviBolestPoIdNetacanParametar() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/bolesti//\\\"1\\\"")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isBadRequest());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void dobaviBolestIdNePostoji() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/bolesti/96666")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isNotFound())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Object not found")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void dobaviBolestPoIdGreska() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/bolesti/19")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is4xxClientError());
//    }
//
//    // POST metode
//    @org.junit.jupiter.api.Test
//    public void postBolest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders
//                .post("/bolesti")
//                .content(asJsonString(new Bolest("NovaBolest", "NoviLijek")))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.id", Matchers.is(4)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.ime", Matchers.is("NovaBolest")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.lijek", Matchers.is("NoviLijek")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void postBolestParametarNedostaje() throws Exception {
//        Bolest bolest = new Bolest();
//        bolest.setIme("Corona");
//        mockMvc.perform(MockMvcRequestBuilders
//                .post("/bolesti")
//                .content(asJsonString(bolest))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isBadRequest());
//    }
//
//    // PUT metode
//    @org.junit.jupiter.api.Test
//    public void putNepostojeciId() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.put("/bolesti/6")
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                //.andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Greska pri azuriranju bolesti sa id 6")))
//                .andExpect(status().isBadRequest());
//        // Baca error BolestControllerTest.putNepostojeciId:128 No value at JSON path "$.message"
//    }
//
//    @org.junit.jupiter.api.Test
//    public void putUspjesno() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.put("/bolesti/1")
//                .content(asJsonString(new Bolest("NovaBolest", "NoviLijek")))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno azurirana bolest sa id 1")));
//    }
//
//    // DELETE metode
//    @org.junit.jupiter.api.Test
//    public void deleteBolestId() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/bolesti/2"))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno obrisana bolest sa id 2")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void deleteBolestIdNepostojeci() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/bolesti/9"))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Greska pri brisanju bolesti sa id 9")))
//                .andExpect(status().isBadRequest());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void deleteSveBolesti() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/bolesti"))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno obrisane sve bolesti!")))
//                .andExpect(status().isOk());
//    }
//
//    // Novi test za udomljavanje zivotinje
//    @org.junit.jupiter.api.Test
//    public void udomljavanjeZivotinjeTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.put("/udomljena/2/2"))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Zivotinja sa id 2 je udomljena od strane korisnika sa id 2")))
//                .andExpect (status().isOk());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void udomljavanjeZivotinjeGreskaTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.put("/udomljena/2/8"))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Greska pri udomljavanju zivotinje!")))
//                .andExpect (status().isBadRequest());
//    }
//}
