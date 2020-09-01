package com.example.ppis.repository;

import com.example.ppis.model.Education;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface EducationRepository extends CrudRepository<Education, Integer> {

    Education findByHost(String host);

    Education findByTopic(String topic);
}
