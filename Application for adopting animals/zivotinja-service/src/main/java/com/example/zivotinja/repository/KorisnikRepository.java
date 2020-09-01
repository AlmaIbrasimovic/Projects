package com.example.zivotinja.repository;

import com.example.zivotinja.model.Korisnik;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import javax.transaction.Transactional;

@Repository
public interface KorisnikRepository extends JpaRepository<Korisnik, Long> {

    @Modifying
    @Transactional
    @Query(value = "DELETE FROM Zivotinja WHERE korisnikid = :id", nativeQuery = true)
    void deleteZivotinjaById(@Param("id") Long id);

    @Query (value = "SELECT COUNT (zivotinjaID) FROM vakcina_zivotinja WHERE zivotinjaID = :id", nativeQuery = true)
    Integer getZivotinja (@Param ("id") Long id);

    @Query (value = "SELECT COUNT (zivotinjaID) FROM ANKETA WHERE zivotinjaID = :id", nativeQuery = true)
    Integer getAnketa (@Param ("id") Long id);

    @Modifying
    @Transactional
    @Query(value = "DELETE FROM vakcina_zivotinja WHERE zivotinjaID = :id", nativeQuery = true)
    void deleteMedjuTabela(@Param("id") Long id);

    @Modifying
    @Transactional
    @Query(value = "DELETE FROM ANKETA WHERE zivotinjaID = :id", nativeQuery = true)
    void deleteAnketa(@Param("id") Long id);

    @Query(value = "SELECT brisati FROM Korisnik WHERE id = :id", nativeQuery = true)
    Boolean findFlag (@Param ("id") Long id);
}
