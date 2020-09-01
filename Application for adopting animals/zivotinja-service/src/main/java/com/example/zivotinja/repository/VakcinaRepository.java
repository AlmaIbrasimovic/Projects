package com.example.zivotinja.repository;

import com.example.zivotinja.model.Vakcina;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.web.bind.annotation.PathVariable;

import javax.transaction.Transactional;
import java.util.List;

@Repository
public interface VakcinaRepository extends JpaRepository<Vakcina, Long> {

    @Query(value = "SELECT * FROM Vakcina WHERE tip = :tip", nativeQuery = true)
    List<Vakcina> findByType(@Param("tip") String tip);

    @Modifying
    @Transactional
    @Query(value = "DELETE FROM Vakcina WHERE tip = :tip", nativeQuery = true)
    void deleteByType(@Param("tip") String tip);

}
