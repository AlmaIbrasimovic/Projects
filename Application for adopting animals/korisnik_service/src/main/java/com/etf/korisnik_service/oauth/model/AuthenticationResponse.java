package com.etf.korisnik_service.oauth.model;

public class AuthenticationResponse {

    private String token;
    private String role;
    private Integer userId;

    public AuthenticationResponse() {}

    public AuthenticationResponse(String token, String role,Integer userId) {
        this.role = role;
        this.token = token;
        this.userId = userId;
    }

    public String getToken() {
        return token;
    }

    public void setToken(String token) {
        this.token = token;
    }

    public String getRole() {
        return role;
    }

    public void setRole(String role) {
        this.role = role;
    }

    public Integer getUserId() {
        return userId;
    }

    public void setUserId(Integer userId) {
        this.userId = userId;
    }
}
