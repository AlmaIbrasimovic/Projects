package com.etf.anketa_service;

import com.etf.anketa_service.model.Survey;
import com.fasterxml.jackson.databind.ObjectMapper;
import org.hamcrest.Matchers;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;

import java.util.ArrayList;

import static org.hamcrest.Matchers.hasSize;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@SpringBootTest
@AutoConfigureMockMvc
public class SurveyControllerTests {
    /*@Autowired
    private MockMvc mockMvc;

    public static String asJsonObject(final Object object) {
        try {
            return new ObjectMapper().writeValueAsString(object);
        }
        catch(Exception error) {
            throw new RuntimeException(error);
        }
    }

    @org.junit.jupiter.api.Test
    public void addSurveyFail() throws Exception {
        Survey survey = new Survey("Anketa za testiranje POST metode", true, new ArrayList<>(), null);
        mockMvc.perform(MockMvcRequestBuilders.post("/v1/survey")
                .content(asJsonObject(survey))
                .contentType(MediaType.APPLICATION_JSON)
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().is(500));
    }

    @org.junit.jupiter.api.Test
    public void getAllSurveys() throws Exception {
        mockMvc.perform(MockMvcRequestBuilders.get("/v1/survey")
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.jsonPath("$", hasSize(2)));
    }

    @org.junit.jupiter.api.Test
    public void getSpecifiedSurvey() throws Exception {
        int id = 1;
        mockMvc.perform(MockMvcRequestBuilders.get("/v1/survey/getById")
                .param("id", String.valueOf(id))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk());
    }

    @org.junit.jupiter.api.Test
    public void failGettingSpecifiedSurvey() throws Exception {
        int id = -5;
        mockMvc.perform(MockMvcRequestBuilders.get("/v1/survey/getById")
                .param("id", String.valueOf(id))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().is4xxClientError());
    }

    @org.junit.jupiter.api.Test
    public void getSurveysByActiveStatus() throws Exception {
        boolean status = false;
        mockMvc.perform(MockMvcRequestBuilders.get("/v1/survey/getByActiveStatus")
                .param("active", String.valueOf(status))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.jsonPath("$", hasSize(1)));
    }

    @org.junit.jupiter.api.Test
    public void deleteAllSurveys() throws Exception {
        mockMvc.perform(MockMvcRequestBuilders.delete("/v1/survey")
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno obrisane ankete!")));
    }

    @org.junit.jupiter.api.Test
    public void deleteSpecifiedSurvey() throws Exception {
        int id = 1;
        mockMvc.perform(MockMvcRequestBuilders.delete("/v1/survey/deleteById")
                .param("id", String.valueOf(id))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isOk())
                .andExpect(MockMvcResultMatchers.jsonPath("$.message", Matchers.is("Uspjesno obrisana anketa!")));
    }

    @org.junit.jupiter.api.Test
    public void failDeletingSpecifiedSurvey() throws Exception {
        int id = -5;
        mockMvc.perform(MockMvcRequestBuilders.delete("/v1/survey/deleteById")
                .param("id", String.valueOf(id))
                .accept(MediaType.APPLICATION_JSON))
                .andExpect(status().isBadRequest());
    }*/
}
