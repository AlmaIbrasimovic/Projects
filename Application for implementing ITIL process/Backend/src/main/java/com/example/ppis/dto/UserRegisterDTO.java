package com.example.ppis.dto;

import com.example.ppis.model.Role;

import javax.persistence.ManyToMany;
import javax.validation.constraints.Pattern;
import java.util.List;

public class UserRegisterDTO {

    @Pattern(regexp = "[\\w\\d]{3,}", message = "Username može sadržati najmanje 3 slova ili/i broja")
    String username;

    //@Pattern(regexp = "[\\w\\d]{7,}", message = "Sifra mora imati minimalno 7 znakova (slova ili brojeva)")
    String password;

    @Pattern(regexp = "^(.+)@(.+)$", message = "Email nije dobrog formata")
    String email;

    List<UserRoleDTO> roleList;

    public UserRegisterDTO() {}

    public UserRegisterDTO(@Pattern(regexp = "[\\w\\d]{3,}", message = "Username može sadržati najmanje 3 slova ili/i broja") String username, String password, @Pattern(regexp = "^(.+)@(.+)$", message = "Email nije dobrog formata") String email, List<UserRoleDTO> roleList) {
        this.username = username;
        this.password = password;
        this.email = email;
        this.roleList = roleList;
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

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public List<UserRoleDTO> getRoleList() {
        return roleList;
    }

    public void setRoleList(List<UserRoleDTO> roleList) {
        this.roleList = roleList;
    }
}
