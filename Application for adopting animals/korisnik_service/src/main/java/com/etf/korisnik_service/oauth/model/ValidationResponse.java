package com.etf.korisnik_service.oauth.model;

public class ValidationResponse {

    private String username;
    private String password;
    private String authorities;
    private String role;
    private Integer userId;

    public ValidationResponse() {}

    public ValidationResponse(String username, String password, String authorities, String role, Integer userId) {
        this.username = username;
        this.password = password;
        this.authorities = authorities;
        this.role = role;
        this.userId = userId;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getAuthorities() {
        return authorities;
    }

    public void setAuthorities(String authorities) {
        this.authorities = authorities;
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
