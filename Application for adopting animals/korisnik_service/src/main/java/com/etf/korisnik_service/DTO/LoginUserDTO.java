package com.etf.korisnik_service.DTO;

import javax.validation.constraints.Pattern;

public class LoginUserDTO {

    //    @Pattern(regexp = "^(.+)@(.+)$", message = "Email nije dobrog formata")
//    String email;
    @Pattern(regexp = "[\\w\\d]{4,}", message = "Username mora imati minimalno 4 znaka (karaktera ili brojeva)")
    String username;
    @Pattern(regexp = "[\\w\\d]{7,}", message = "Sifra mora imati minimalno 7 znakova (karaktera ili brojeva)")
    String password;

    public LoginUserDTO(String username, String password) {
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
