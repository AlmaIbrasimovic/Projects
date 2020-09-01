package com.etf.korisnik_service.DTO;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Pattern;

public class UserEmailDTO {
    @NotNull
    Integer id;

    @NotNull
    @Pattern(regexp = "^(.+)@(.+)$", message = "Email nije dobrog formata")
    String email;

    public UserEmailDTO(@NotNull Integer id, @NotNull String email) {
        this.id = id;
        this.email = email;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
}
