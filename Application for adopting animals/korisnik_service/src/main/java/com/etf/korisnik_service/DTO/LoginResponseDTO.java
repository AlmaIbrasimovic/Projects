package com.etf.korisnik_service.DTO;

public class LoginResponseDTO {

    Integer id;
    String token;

    public LoginResponseDTO(Integer id, String token) {
        this.id = id;
        this.token = token;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getToken() {
        return token;
    }

    public void setToken(String token) {
        this.token = token;
    }

}
