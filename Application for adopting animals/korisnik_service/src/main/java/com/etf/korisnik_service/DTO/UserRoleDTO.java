package com.etf.korisnik_service.DTO;

import javax.validation.constraints.NotNull;

public class UserRoleDTO {

    @NotNull
    Integer userId;

    @NotNull
    String roleName;

    public UserRoleDTO(@NotNull Integer userId, @NotNull String roleName) {
        this.userId = userId;
        this.roleName = roleName;
    }

    public Integer getUserId() {
        return userId;
    }

    public void setUserId(Integer userId) {
        this.userId = userId;
    }

    public String getRoleName() {
        return roleName;
    }

    public void setRoleName(String roleName) {
        this.roleName = roleName;
    }
}
