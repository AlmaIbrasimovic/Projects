package com.example.zivotinja.repository;

import com.example.zivotinja.model.Bolest;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.data.jpa.repository.JpaRepository;

import javax.transaction.Transactional;
import java.util.List;

@Repository
public interface BolestRepository extends JpaRepository<Bolest, Long> {

    @Query(value = "SELECT * FROM Bolest WHERE ime = :ime", nativeQuery = true)
    List<Bolest> findByName(@Param("ime") String ime);

    @Modifying
    @Transactional
    @Query(value = "DELETE FROM Bolest WHERE ime = :ime", nativeQuery = true)
    void deleteByName(@Param("ime") String ime);
}
