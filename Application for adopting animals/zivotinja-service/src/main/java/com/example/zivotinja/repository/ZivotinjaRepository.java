package com.example.zivotinja.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import com.example.zivotinja.model.Zivotinja;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import javax.transaction.Transactional;
import java.util.List;


@Repository
public interface ZivotinjaRepository extends JpaRepository<Zivotinja, Long> {

    @Query (value = "SELECT COUNT (korisnikId) FROM Zivotinja WHERE korisnikId = :id", nativeQuery = true)
    Integer existsByKorisnikId(Long id);

    @Query(value = "SELECT * from Zivotinja where ime = :ime", nativeQuery = true)
    List<Zivotinja> findByName(@Param("ime") String ime);

    @Modifying
    @Transactional
    @Query(value = "DELETE from Zivotinja where ime = :ime", nativeQuery = true)
    void deleteByName(@Param("ime") String ime);

    @Query(value = "SELECT * FROM Zivotinja  WHERE id = :id", nativeQuery = true)
    List<Zivotinja> findByAge(@Param("id") Long id);

    @Query(value = "SELECT * FROM Zivotinja WHERE korisnikId = :id", nativeQuery = true)
    List<Zivotinja> zivotinjeKorisnika (@Param ("id") Long id);
}
