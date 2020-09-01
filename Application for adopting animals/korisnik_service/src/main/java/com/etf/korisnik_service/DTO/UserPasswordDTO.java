package com.etf.korisnik_service.DTO;

import javax.validation.constraints.NotBlank;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Pattern;

public class UserPasswordDTO {

    @NotNull
    Integer id;

    @NotNull
    @NotBlank
    @Pattern(regexp = "[\\w\\d]{7,}", message = "Sifra mora imati minimalno 7 znakova (karaktera ili brojeva)")
    String password;

    public UserPasswordDTO(@NotNull Integer id, @NotNull @NotBlank String password) {
        this.id = id;
        this.password = password;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }
}
