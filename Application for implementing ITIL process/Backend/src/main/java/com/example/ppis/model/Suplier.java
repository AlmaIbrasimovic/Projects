package com.example.ppis.model;

import javax.persistence.*;

@Entity
@Table(name = "Suplier")
public class Suplier {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    private String name;

    private String adress;

    private String contactPeroson;

    public Suplier() {
    }

    public Suplier(String name, String adress, String contactPeroson) {
        this.name = name;
        this.adress = adress;
        this.contactPeroson = contactPeroson;
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

    public String getAdress() {
        return adress;
    }

    public void setAdress(String adress) {
        this.adress = adress;
    }

    public String getContactPeroson() {
        return contactPeroson;
    }

    public void setContactPeroson(String contactPeroson) {
        this.contactPeroson = contactPeroson;
    }
}
