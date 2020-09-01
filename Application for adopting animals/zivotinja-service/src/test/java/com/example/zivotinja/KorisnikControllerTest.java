//package com.example.zivotinja;
//import org.hamcrest.Matchers;
//import org.springframework.beans.factory.annotation.Autowired;
//import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
//import org.springframework.boot.test.context.SpringBootTest;
//import org.springframework.http.MediaType;
//import org.springframework.test.web.servlet.MockMvc;
//import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
//import org.springframework.test.web.servlet.result.MockMvcResultMatchers;
//import static org.hamcrest.Matchers.hasSize;
//import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;
//
//@SpringBootTest
//@AutoConfigureMockMvc
//public class KorisnikControllerTest {
//
//    @Autowired
//    private MockMvc mockMvc;
//
//    // GET testovi
//    @org.junit.jupiter.api.Test
//    public void dobaviSveKorisnike() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/korisnici")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$", hasSize(2)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$[0].id", Matchers.is(1)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$[1].id", Matchers.is(2)));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void dobaviKorisnikaID() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/korisnici/2")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.id", Matchers.is(2)));
//    }
//
//    // DELETE testovi
//    @org.junit.jupiter.api.Test
//    public void obrisiKorisnika() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/korisnici/1"))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno obrisan korisnik sa id 1" )));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void obrisiKorisnikaGreska() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/korisnici/9"))
//                .andExpect(status().isBadRequest())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Greska pri brisanju korisnika sa id 9" )));
//    }
//}
