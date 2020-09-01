package com.etf.korisnik_service;

import com.etf.korisnik_service.model.*;
import com.etf.korisnik_service.repository.*;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;
import org.springframework.cloud.client.loadbalancer.LoadBalanced;
import org.springframework.context.annotation.Bean;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.web.client.RestTemplate;

@EnableDiscoveryClient
@SpringBootApplication
public class UserServiceApplication {
    private static final Logger log =
            LoggerFactory.getLogger(UserServiceApplication.class);

    public static void main(String[] args) {
        SpringApplication.run(UserServiceApplication.class, args);
    }

    @Bean
    public BCryptPasswordEncoder bCryptPasswordEncoder() {
        return new BCryptPasswordEncoder();
    }

    @Bean
    @LoadBalanced
    public RestTemplate restTemplate() {
        return new RestTemplate();
    }

    @Bean
    public CommandLineRunner addDataToDatabase(UserRepository userRepository, AnimalRepository animalRepository, RoleRepository roleRepository, UserAnimalRepository userAnimalRepository, SurveyRepository surveyRepository, UserSurveyRepository userSurveyRepository) {
        return (args) -> {
            //uloge
            Role admin = roleRepository.save(new Role("administrator"));
            Role korisnik = roleRepository.save(new Role("korisnik"));
            log.info("Sve uloge \n");
            for (Role role : roleRepository.findAll()) {
                log.info(role.getRoleName());
            }
            log.info(" ");

            // korisnici
            User k1 = userRepository.save(new User("ante antic", "1234567899876", korisnik));
            k1.setRole(korisnik);
            User k2 = userRepository.save(new User("amno amnic", "93832979237937", korisnik));
            User newUser = new User("zlata karic", "34324343434", admin);
            newUser.setEmail("zkaric1@etf.unsa.ba");
            newUser.setUsername("zkaric1");
            newUser.setHashPassword("novasifra");
            userRepository.save(newUser);
            User alma = new User("Alma Ibrasimovic", "827727277", korisnik);
            alma.setEmail("aibrasimov1@etf.unsa.ba");
            alma.setUsername("aibrasimov1");
            alma.setHashPassword("sifra123");
            userRepository.save(alma);
            userRepository.save(new User("marko marulic", "323343432342424", korisnik));
            log.info("Svi korisnici \n");
            for (User user : userRepository.findAll()) {
                log.info(user.getFullName());
            }

            log.info(" ");

            //zivotinje
            Animal z1 = animalRepository.save(new Animal(1, "mica", "macka", "Z"));
            Animal z2 = animalRepository.save(new Animal(2, "laki", "pas", "M"));
            Animal z3 = animalRepository.save(new Animal(3, "mica1", "macka", "Z"));
            Animal z4 = animalRepository.save(new Animal(4, "mica2", "macka", "Z"));
            Animal z5 = animalRepository.save(new Animal(5, "mica3", "macka", "Z"));
            log.info("Sve zivotinje \n");
            for (Animal animal : animalRepository.findAll()) {
                log.info(animal.toString());
            }
            log.info(" ");

            //korisnik - zivotinja
            userAnimalRepository.save(new UserAnimal(k1, z1));
            userAnimalRepository.save(new UserAnimal(k1, z2));
            userAnimalRepository.save(new UserAnimal(k2, z2));
            log.info("Sve korisnik-zivotinja \n");
            for (UserAnimal userAnimal : userAnimalRepository.findAll()) {
                log.info(userAnimal.toString());
            }

        };
    }

}
