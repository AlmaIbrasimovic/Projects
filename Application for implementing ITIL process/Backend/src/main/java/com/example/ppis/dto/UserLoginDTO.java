package com.example.ppis.dto;

import javax.validation.constraints.Pattern;

public class UserLoginDTO {

    @Pattern(regexp = "[\\w\\d]{3,}", message = "Username može sadržati najmanje 3 slova ili/i broja")
    String username;

   // @Pattern(regexp = "[\\w\\d]{7,}", message = "Sifra mora imati minimalno 7 znakova (slova ili brojeva)")
    String password;

    public UserLoginDTO() {}

    public UserLoginDTO(@Pattern(regexp = "[\\w\\d]{3,}", message = "Username može sadržati najmanje 3 slova ili/i broja") String username, String password) {
        this.username = username;
        this.password = password;
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
}
