package com.example.zivotinja;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.cloud.client.discovery.EnableDiscoveryClient;
import org.springframework.cloud.client.loadbalancer.LoadBalanced;
import org.springframework.context.annotation.Bean;
import com.example.zivotinja.repository.*;
import com.example.zivotinja.model.*;
import org.springframework.core.io.Resource;
import org.springframework.core.io.ResourceLoader;
import org.springframework.web.client.RestTemplate;
import org.springframework.web.servlet.config.annotation.CorsRegistry;
import org.springframework.web.servlet.config.annotation.WebMvcConfigurer;

import java.io.BufferedReader;
import java.io.File;
import java.io.InputStream;
import java.io.InputStreamReader;

@EnableDiscoveryClient
@SpringBootApplication
public class ZivotinjaServiceApplication {
    public static void main(String[] args) {
        System.out.print("Pokrenuta APP");
        SpringApplication.run(ZivotinjaServiceApplication.class, args);
    }
    private static final Logger log = LoggerFactory.getLogger(ZivotinjaServiceApplication.class);

    @Autowired
    ResourceLoader resourceLoader;

    @Bean
    @LoadBalanced
    public RestTemplate getRestTemplate() {
        return new RestTemplate();
    }

    @Bean
    public CommandLineRunner demo(AnketaRepository aRepo, ZivotinjaRepository zRepo, BolestRepository bRepo, KorisnikRepository kRepo, VakcinaRepository vRepo, VeterinarRepository vetRepo) {
        return (args) -> {

            // Kreiranje bolesti
            bRepo.save(new Bolest("Bjesnilo", "Antibiotici"));
            bRepo.save(new Bolest("Gripa", "Tablete"));
            bRepo.save(new Bolest("Prehlada", "Injekcija"));

            // Provjera da li je uspjesno kreirano
            log.info("Sve bolesti: ");
            for (Bolest b : bRepo.findAll()) {
                log.info(b.getIme().toString());
            }

            // Kreiranje veterinara
            vetRepo.save(new Veterinar("Abdulah", "Jakupovic", "061546954", "Stjepana Radica 18/15"));
            vetRepo.save(new Veterinar("Ivan", "Simic", "062569412", "Hamdije Cemerlica 1"));
            vetRepo.save(new Veterinar("Amila", "Perenda", "066879145", "Paromlinska 52"));

            // Kreiranje vakcine
            vRepo.save(new Vakcina("Hepatits", 12));
            vRepo.save(new Vakcina("Stenecak", 24));
            vRepo.save(new Vakcina("DHPP", 6));
            Vakcina vak = new Vakcina("Bolest", 8);
            vRepo.save(vak);

            // Kreiranje korisnika
            Korisnik kor = new Korisnik(false);
            kRepo.save(kor);
            Korisnik korA = new Korisnik(false);
            kRepo.save(korA);

            // Slika
            /*Resource resource = resourceLoader.getResource("classpath:viki.jpg");
            File file = resource.getFile();*/

            // Kreiranje zivotinje
            Zivotinja cuko = new Zivotinja("Mini", "Pas", "Labrador", "Z", 2, "Mali pas", 10, "Spremna za Vas dom!", false);
            /*byte[] slika = cuko.kreirajSliku("src/main/java/com/example/zivotinja/viki.jpg");
            cuko.setSlika(slika);*/

            // Kreiranje ankete
            Anketa anketa = new Anketa();
            anketa.setZivotinjaID(cuko);

            // Popunjavanje medjutabele
            cuko.getVakcine().add(vak);
            cuko.setKorisnikId(kor);
            cuko.setUdomljena(true);
            zRepo.save(cuko);
            aRepo.save(anketa);
            //cuko.preuzmiSliku();
           /* resource = resourceLoader.getResource("classpath:rex.jpg");
            InputStream dbAsStream = resource.getInputStream();
            file = resource.getFile();*/
            cuko = new Zivotinja("Rex", "Pas", "Njemacki ovcar", "M", 1, "Veliki pas", 6, "Najbolji pas kojeg cete ikad imati!", false);
           /* slika = cuko.kreirajSliku("src/main/java/com/example/zivotinja/rex.jpg");
            cuko.setSlika(slika);*/
            zRepo.save(cuko);
           /* resource = resourceLoader.getResource("classpath:mini.jpg");
            file = resource.getFile();*/
            Zivotinja maca = (new Zivotinja("Viki", "Macka", "Ruska plava", "Z", 2, "Mali rast", 3, "Preslatka mala maca", false));
            /*slika = maca.kreirajSliku("src/main/java/com/example/zivotinja/mini.jpg");
            maca.setSlika(slika);*/
            zRepo.save(maca);
        };
    }
}
