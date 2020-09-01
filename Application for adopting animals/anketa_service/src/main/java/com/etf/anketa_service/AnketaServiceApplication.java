package com.etf.anketa_service;

import com.etf.anketa_service.model.Animal;
import com.etf.anketa_service.model.Answer;
import com.etf.anketa_service.model.ApplicationUser;
import com.etf.anketa_service.model.PossibleAnswer;
import com.etf.anketa_service.model.Question;
import com.etf.anketa_service.model.Survey;
import com.etf.anketa_service.repository.AnimalRepository;
import com.etf.anketa_service.repository.AnswerRepository;
import com.etf.anketa_service.repository.ApplicationUserRepository;
import com.etf.anketa_service.repository.PossibleAnswerRepository;
import com.etf.anketa_service.repository.QuestionRepository;
import com.etf.anketa_service.repository.SurveyRepository;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;
import org.springframework.cloud.client.loadbalancer.LoadBalanced;
import org.springframework.context.annotation.Bean;
import org.springframework.web.client.RestTemplate;

import java.util.ArrayList;

@EnableDiscoveryClient
@SpringBootApplication
public class AnketaServiceApplication {
    @Bean
    @LoadBalanced
    public RestTemplate getRestTemplate() {
        return new RestTemplate();
    }

    public static void main(String[] args) {
        SpringApplication.run(AnketaServiceApplication.class, args);
    }

    @Bean
    public CommandLineRunner addData(AnimalRepository animalRepository, AnswerRepository answerRepository, ApplicationUserRepository applicationUserRepository, PossibleAnswerRepository possibleAnswerRepository, QuestionRepository questionRepository, SurveyRepository surveyRepository) {
        return (args) -> {
            // Kreiranje zivotinja
            /*Animal testAnimal_1 = new Animal();
            animalRepository.save(testAnimal_1);
            Animal testAnimal_2 = new Animal();
            animalRepository.save(testAnimal_2);

            // Kreiranje anketa
            Survey testSurvey_1 = new Survey("Anketa za prvu testnu zivotinju", true, new ArrayList<>(), testAnimal_1);
            surveyRepository.save(testSurvey_1);
            Survey testSurvey_2 = new Survey("Anketa za drugu testnu zivotinju", false, null, testAnimal_2);
            surveyRepository.save(testSurvey_2);

            // Kreiranje pitanja za prvu anketu
            Question question_1 = new Question("Da li Vam je ovo prvi kucni ljubimac?", true, null, testSurvey_1);
            questionRepository.save(question_1);
            Question question_2 = new Question("Da li imate djece?", true, null, testSurvey_1);
            questionRepository.save(question_2);
            Question question_3 = new Question("Da li namjeravate udomiti jos zivotinja u buducnosti?", false, null, testSurvey_2);
            questionRepository.save(question_3);

            // Kreiranje ponudjenih odgovora
            PossibleAnswer possibleAnswer_1 = new PossibleAnswer("Ne", Long.parseLong("1"), question_1, null);
            possibleAnswerRepository.save(possibleAnswer_1);
            PossibleAnswer possibleAnswer_2 = new PossibleAnswer("Da", Long.parseLong("0"), question_1, null);
            possibleAnswerRepository.save(possibleAnswer_2);

            PossibleAnswer possibleAnswer_3 = new PossibleAnswer("Ne", Long.parseLong("1"), question_2, null);
            possibleAnswerRepository.save(possibleAnswer_3);
            PossibleAnswer possibleAnswer_4 = new PossibleAnswer("Da", Long.parseLong("0"), question_2, null);
            possibleAnswerRepository.save(possibleAnswer_4);

            PossibleAnswer possibleAnswer_5 = new PossibleAnswer("Ne", Long.parseLong("1"), question_3, null);
            possibleAnswerRepository.save(possibleAnswer_5);
            PossibleAnswer possibleAnswer_6 = new PossibleAnswer("Manje od 5", Long.parseLong("1"), question_3, null);
            possibleAnswerRepository.save(possibleAnswer_6);
            PossibleAnswer possibleAnswer_7 = new PossibleAnswer("5 i vise", Long.parseLong("0"), question_3, null);
            possibleAnswerRepository.save(possibleAnswer_7);

            // Kreiranje korisnika
            ApplicationUser user_1 = new ApplicationUser();
            applicationUserRepository.save(user_1);
            ApplicationUser user_2 = new ApplicationUser();
            applicationUserRepository.save(user_2);
            ApplicationUser user_3 = new ApplicationUser();
            applicationUserRepository.save(user_3);
            ApplicationUser user_4 = new ApplicationUser();
            applicationUserRepository.save(user_4);

            // Kreiranje odgovora na pitanja za korisnike
            Answer answer_1 = new Answer(possibleAnswer_1, user_4);
            answerRepository.save(answer_1);
            Answer answer_2 = new Answer(possibleAnswer_4, user_4);
            answerRepository.save(answer_2);

            Answer answer_3 = new Answer(possibleAnswer_2, user_2);
            answerRepository.save(answer_3);
            Answer answer_4 = new Answer(possibleAnswer_3, user_2);
            answerRepository.save(answer_4);
            Answer answer_5 = new Answer(possibleAnswer_7, user_2);
            answerRepository.save(answer_5);*/
        };
    }
}
