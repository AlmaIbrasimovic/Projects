package com.etf.anketa_service.controller;

import com.etf.anketa_service.exception.ApplicationUserException;
import com.etf.anketa_service.model.ApplicationUser;
import com.etf.anketa_service.service.ApplicationUserService;
import net.minidev.json.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpMethod;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.client.RestTemplate;

import java.util.List;

@RequestMapping(path = "/v1/applicationUser")
@RestController
public class ApplicationUserController {
    private ApplicationUserService applicationUserService;
    @Autowired
    private RestTemplate restTemplate;

    public ApplicationUserController(ApplicationUserService applicationUserService) {
        this.applicationUserService = applicationUserService;
    }

    @GetMapping(path = "/getAll")
    List<ApplicationUser> getAllUsers() {
        return applicationUserService.getAll();
    }

    @GetMapping(path = "/getById")
    ApplicationUser getSpecifiedUser(@RequestParam(name = "id", required = true) Long applicationUserId) {
        return applicationUserService.findById(applicationUserId);
    }

    @GetMapping(path = "/getPointsForSurvey")
    Long getPointsForSurvey(@RequestParam(name = "id", required = true) Long applicationUserId, @RequestParam(name = "surveyId", required = true) Long surveyId) {
        String response = restTemplate.exchange("http://korisnikService/korisnik/" + applicationUserId,
                HttpMethod.GET, null, String.class).getBody();
        if(response != null) {
            char fetchedId = response.split("<id>")[1].charAt(0);
            Long parseFetchedId = Long.parseLong(Character.getNumericValue(fetchedId) + "");
            if(parseFetchedId.equals(applicationUserId)) {
                return applicationUserService.getPointsForSurvey(applicationUserId, surveyId);
            }
        }
        throw new ApplicationUserException(applicationUserId);
    }

    @DeleteMapping(path = "/deleteById")
    ResponseEntity<JSONObject> deleteUser(@RequestParam(name = "id", required = true) Long applicationUserId) throws Exception {
        JSONObject response = new JSONObject();
        try {
            applicationUserService.deleteById(applicationUserId);
            response.put("message", "Uspjesno obrisan korisnik!");
            return new ResponseEntity<>(response, HttpStatus.OK);
        }
        catch(Exception err) {
            response.put("message", err.getMessage());
            return new ResponseEntity<>(response, HttpStatus.BAD_REQUEST);
        }
    }
}
