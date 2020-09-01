package com.example.ppis.dto;

import javax.validation.constraints.NotBlank;

public class UserRoleDTO {

    @NotBlank
    Integer roleId;

    public UserRoleDTO() {}

    public UserRoleDTO(@NotBlank Integer roleId) {
        this.roleId = roleId;
    }

    public Integer getRoleId() {
        return roleId;
    }

    public void setRoleId(Integer roleId) {
        this.roleId = roleId;
    }
}
