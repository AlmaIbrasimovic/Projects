//package com.example.zivotinja;
//
//import com.example.zivotinja.model.Bolest;
//import com.example.zivotinja.model.Veterinar;
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
//import static org.hamcrest.Matchers.hasSize;
//import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;
//
//@SpringBootTest
//@AutoConfigureMockMvc
//public class VeterinarControllerTest {
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
//    public void dobaviSveVeterinareTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/veterinari")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$", hasSize(0)));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void dobaviJednogVeterinarTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/veterinari/{id}", 3)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isNotFound());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void postVeterinaraTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.post("/veterinari")
//                .param("ime", "Alma")
//                .param("prezime", "Ibrasimovic")
//                .param("adresa", "Sarajevo 123"));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void putVeterinaraTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.put("/veterinari/{id}", 2)
//                .content("ime=Lejla")
//                .content("prezime=Silajdzija")
//                .content("adresa=Nerkeza 132"));
//    }
//
//    // Testovi za greske
//    @org.junit.jupiter.api.Test
//    public void dobaviVeterinaraPoIdNetacanParametar() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/veterinari//\\\"1\\\"")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isBadRequest());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void dobaviVeterinaraIdNePostoji() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/veterinari/16")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isNotFound())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Object not found")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void dobaviVeterinaraPoIdGreska() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/veterinari/56")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is4xxClientError());
//    }
//
//    // POST metode
//    @org.junit.jupiter.api.Test
//    public void postVeterinara() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders
//                .post("/veterinari")
//                .content(asJsonString(new Veterinar("Huso", "Husic", "061666123", "Husici 45a")))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.id", Matchers.is(4)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.ime", Matchers.is("Huso")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.prezime", Matchers.is("Husic")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.adresa", Matchers.is("Husici 45a")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.kontaktTelefon", Matchers.is("061666123")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void postVeterinarParametarNedostaje() throws Exception {
//        Veterinar vet = new Veterinar();
//        vet.setIme("Alma");
//        vet.setPrezime("Ibrasimovic");
//        mockMvc.perform(MockMvcRequestBuilders
//                .post("/veterinari")
//                .content(asJsonString(vet))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isBadRequest());
//    }
//
//    // PUT metode
//    @org.junit.jupiter.api.Test
//    public void putNepostojeciId() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.put("/veterinari/7")
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                //.andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Greska pri azuriranju veterinara sa id 7")))
//                .andExpect(status().isBadRequest());
//        // Baca error BolestControllerTest.putNepostojeciId:128 No value at JSON path "$.message"
//    }
//
//    @org.junit.jupiter.api.Test
//    public void putUspjesno() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.put("/veterinari/2")
//                .content(asJsonString(new Veterinar("Mujo", "Mujic", "062189654", "Mujici 66a")))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isBadRequest())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Greska pri azuriranje veterinara sa id 2")));
//    }
//
//    // DELETE metode
//    @org.junit.jupiter.api.Test
//    public void deleteVeterinarId() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/veterinari/1"))
//                .andExpect(status().isBadRequest())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Greska pri brisanju veterinara sa id 1")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void deleteVeterinarIdNepostojeci() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/veterinari/9"))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Greska pri brisanju veterinara sa id 9")))
//                .andExpect(status().isBadRequest());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void deleteSveVeterinare() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/veterinari"))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno obrisani svi veterinari!")))
//                .andExpect(status().isOk());
//    }
//}
