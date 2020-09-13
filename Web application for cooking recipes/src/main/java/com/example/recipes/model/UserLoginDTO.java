package com.example.recipes.model;


public class UserLoginDTO {

    String eMail;
    String password;

    public UserLoginDTO() {
    }

    public UserLoginDTO(String eMail, String password) {
        this.eMail = eMail;
        this.password = password;
    }

    public String getEmail() {
        return eMail;
    }

    public void setEmail(String eMail) {
        this.eMail = eMail;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }
}
