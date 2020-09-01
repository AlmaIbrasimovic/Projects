//package com.example.zivotinja;
//import com.example.zivotinja.model.Vakcina;
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
//public class VakcinaControllerTest {
//
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
//    public void dobaviSveVakcineTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/vakcine")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$", hasSize(3)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$[0].id", Matchers.is(1)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$[0].tip", Matchers.is("Hepatits")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$[1].revakcinacija", Matchers.is(24)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$[2].tip", Matchers.is("Bolest")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void dobaviJednuVakcinuTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/vakcine/1")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.id", Matchers.is(1)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.tip", Matchers.is("Hepatits")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.revakcinacija", Matchers.is(12)));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void postVakcineTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.post("/vakcine")
//                .param("tip", "Random vakcina")
//                .param("revakcinacija", "36"));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void putVakcineTest() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.put("/vakcine/{id}", 2)
//                .content("tip=TestVakcine")
//                .content("revakcinacija=6"));
//    }
//
//
//    @org.junit.jupiter.api.Test
//    public void dobaviVakcinuIdNetacanParametar() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/vakcine//\\\"55\\\"")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isBadRequest());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void dobaviVakcinuIdNePostoji() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/vakcine/23")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isNotFound())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Object not found")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void dobaviVakcinuPoIdGreska() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.get("/vakcine/21")
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is4xxClientError());
//    }
//
//    // POST metode
//    @org.junit.jupiter.api.Test
//    public void postVakcinu() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders
//                .post("/vakcine")
//                .content(asJsonString(new Vakcina("NovaVakcina", 36)))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().is2xxSuccessful())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.id", Matchers.is(5)))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.tip", Matchers.is("NovaVakcina")))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.revakcinacija", Matchers.is(36)));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void postVakcinaParametarNedostaje() throws Exception {
//        Vakcina vakcina = new Vakcina();
//        vakcina.setTip("Corona");
//        mockMvc.perform(MockMvcRequestBuilders
//                .post("/vakcine")
//                .content(asJsonString(vakcina))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isBadRequest());
//    }
//
//    // PUT metode
//    @org.junit.jupiter.api.Test
//    public void putNepostojeciId() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.put("/vakcine/10")
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                //.andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Greska pri azuriranju vakcine sa id 10")))
//                .andExpect(status().isBadRequest());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void putUspjesno() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.put("/vakcine/1")
//                .content(asJsonString(new Vakcina("NovaVakcina", 24)))
//                .contentType(MediaType.APPLICATION_JSON)
//                .accept(MediaType.APPLICATION_JSON))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno azurirana vakcina sa id 1")));
//    }
//
//    // DELETE metode
//    @org.junit.jupiter.api.Test
//    public void deleteVakcinaId() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/vakcine/3"))
//                .andExpect(status().isOk())
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno obrisana vakcina sa id 3")));
//    }
//
//    @org.junit.jupiter.api.Test
//    public void deleteVakcinuIdNepostojeci() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/vakcine/19"))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Greska pri brisanju vakcine sa id 19")))
//                .andExpect(status().isBadRequest());
//    }
//
//    @org.junit.jupiter.api.Test
//    public void deleteSveVakcine() throws Exception {
//        mockMvc.perform(MockMvcRequestBuilders.delete("/vakcine"))
//                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno obrisane sve vakcine!")))
//                .andExpect(status().isOk());
//    }
//}
