package com.example.ppis.model;

import javax.persistence.*;
import javax.validation.constraints.NotBlank;
import java.util.List;

@Entity
@Table(name = "Role")
public class Role {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @NotBlank
    private String name;

 //   @ManyToMany
 //   private List<User> usersWithRole;

    public Role() {}

    public Role(@NotBlank String name) {
        this.name = name;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

  /*  public List<User> getUsersWithRole() {
        return usersWithRole;
    }

    public void setUsersWithRole(List<User> usersWithRole) {
        this.usersWithRole = usersWithRole;
    }*/

    @Override
    public String toString() {
        return "Role{" +
                "id=" + id +
                ", name='" + name + '\'' +
               // ", usersWithRole=" + usersWithRole +
                '}';
    }
}
