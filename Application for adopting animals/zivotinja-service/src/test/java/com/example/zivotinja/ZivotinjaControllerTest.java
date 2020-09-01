//package com.example.zivotinja;
//import com.example.zivotinja.model.Korisnik;
//import com.example.zivotinja.model.Zivotinja;
//import com.example.zivotinja.service.KorisnikService;
//import com.fasterxml.jackson.databind.ObjectMapper;
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
//public class ZivotinjaControllerTest {
//    @Autowired
//    private MockMvc mockMvc;
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
//    public void dobaviSveZiotinjeTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/zivotinje")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$", hasSize(2)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$[0].id", Matchers.is(1)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$[0].ime", Matchers.is("Mini")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$[1].rasa", Matchers.is("Labrador")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$[0].vrsta", Matchers.is("Pas")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$[1].godine", Matchers.is(2)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$[0].spol", Matchers.is("Z")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void dobaviGodineZaZivotinju() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/zivotinje/1/godine")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.godine", Matchers.is(2)));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void dobaviJednuZivotinjuTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/zivotinje/{id}", 1)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isNotFound());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void postZivotinjeTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.post("/zivotinje")
//                .param("dodatniOpis", "Slatkica mala")
//                .param("ime", "Cicko")
//                .param("godine", "3")
//                .param("spol", "M")
//                .param("velicina", "Mala macka")
//                .param("tezina", "3")
//                .param("vrsta", "Macka")
//                .param("udomljena", "false")
//                .param("rasa", "Ruska plava"));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void putZivotinjeTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.put("/zivotinje/{id}", 2)
//                .content("ime=Miki")
//                .content("godine=5"));
//    }
//
//    // Testovi za greske
//    @org.junit.jupiter.api.Test
//    public void dobaviZivotinjuPoIdNetacanParametar() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/zivotinje//\\\"okk511\\\"")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isBadRequest());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void dobaviZivotinjuIdNePostoji() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/zivotinje/8")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isNotFound())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Object not found")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void dobaviZivotinjuPoIdGreska() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/zivotinje/19")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is4xxClientError());
//    }
//
//    // POST metode
//    @org.junit.jupiter.api.Test
//    public void postZivotinja() throws Exception {
//        Zivotinja ziv = new Zivotinja ("Cicko", "Macka", "Perzijska", "Z", 2, "Srednji rast", 5, "Fluffy slatka maca", false);
//        mockMvc.perform(MockMvcRequestBuilders
//                .post("/zivotinje")
//                .content(asJsonString(ziv))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.id", Matchers.is(3)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.ime", Matchers.is("Cicko")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.vrsta", Matchers.is("Macka")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.rasa", Matchers.is("Perzijska")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.godine", Matchers.is(2)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.velicina", Matchers.is("Srednji rast")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.tezina", Matchers.is(5)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.dodatniOpis", Matchers.is("Fluffy slatka maca")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.udomljena", Matchers.is(false)));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void postZivotinjaParametarNedostaje() throws Exception {
//        Zivotinja ziv = new Zivotinja();
//        ziv.setIme("Vicko");
//        ziv.setVrsta("Kornjaca");
//        ziv.setTezina(2);
//        mockMvc.perform(MockMvcRequestBuilders
//                .post("/zivotinje")
//                .content(asJsonString(ziv))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isBadRequest());
//    }
//
//    // PUT metode
//    @org.junit.jupiter.api.Test
//    public void putNepostojeciId() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.put("/zivotinje/6")
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                //.andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Greska pri azuriranju zivotinje sa id 6")))
//                .andExpect(status().isBadRequest());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void putUspjesno() throws Exception {
//        Zivotinja zivotinja = new Zivotinja();
//        zivotinja.setIme("Brundo");
//        zivotinja.setVrsta("Medvjed");
//        zivotinja.setTezina(200);
//        mockMvc.perform(MockMvcRequestBuilders.put("/zivotinje/1")
//                .content(asJsonString(zivotinja))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isBadRequest())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Greska pri azuriranju zivotinje sa id 1")));
//    }
//
//    // DELETE metode
//    @org.junit.jupiter.api.Test
//    public void deleteZivotinjaId() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/zivotinje/2"))
//                .andExpect(status().isBadRequest())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Greska pri brisanju zivotinje sa id 2")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void deleteZivotinjaIdNepostojeci() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/zivotinje/9"))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Greska pri brisanju zivotinje sa id 9")))
//                .andExpect(status().isBadRequest());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void deleteSveZivotinje() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/zivotinje"))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno obrisane sve zivotinje!")))
//                .andExpect(status().isOk());
//    }
//}
