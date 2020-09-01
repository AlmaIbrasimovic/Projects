package com.example.ppis.model;

import javax.persistence.*;
import java.util.Date;

@Entity
@Table(name = "Contract")
public class Contract {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @ManyToOne
    private Suplier suplier;

    private String name;

    private Date createdDate;

    private Date expiredDate;

    public Contract() {
    }

    public Contract(Suplier suplier, String name, Date createdDate, Date expiredDate) {
        this.suplier = suplier;
        this.name = name;
        this.createdDate = createdDate;
        this.expiredDate = expiredDate;
    }

    public Integer getId() {
        return id;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public Suplier getSuplier() {
        return suplier;
    }

    public void setSuplier(Suplier suplier) {
        this.suplier = suplier;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Date getCreatedDate() {
        return createdDate;
    }

    public void setCreatedDate(Date createdDate) {
        this.createdDate = createdDate;
    }

    public Date getExpiredDate() {
        return expiredDate;
    }

    public void setExpiredDate(Date expiredDate) {
        this.expiredDate = expiredDate;
    }
}
