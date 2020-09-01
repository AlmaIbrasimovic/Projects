package com.example.zivotinja.repository;
import com.example.zivotinja.model.Anketa;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

@Repository
public interface AnketaRepository extends JpaRepository<Anketa, Long> {

    @Query(value = "SELECT ZivotinjaID FROM Anketa WHERE id = :id", nativeQuery = true)
    Long findZivotinjaById(@Param("id") Long id);
}
