package com.etf.anketa_service.service;

import com.etf.anketa_service.exception.ApplicationUserException;
import com.etf.anketa_service.model.ApplicationUser;
import com.etf.anketa_service.repository.ApplicationUserRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class ApplicationUserService {
    private ApplicationUserRepository applicationUserRepository;

    public ApplicationUserService(ApplicationUserRepository applicationUserRepository) {
        this.applicationUserRepository = applicationUserRepository;
    }

    public List<ApplicationUser> getAll() {
        return applicationUserRepository.findAll();
    }

    public Long getPointsForSurvey(Long applicationUserId, Long surveyId) {
        return applicationUserRepository.getPointsForSpecifiedSurvey(applicationUserId, surveyId);
    }

    public ApplicationUser findById(Long id) {
        return applicationUserRepository.findById(id).orElseThrow(() -> new ApplicationUserException(id));
    }

    public void deleteById(Long id) throws Exception {
        applicationUserRepository.deleteById(id);
    }
}
