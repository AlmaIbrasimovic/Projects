package com.example.zivotinja.service;
import com.example.zivotinja.exception.AnketaException;
import com.example.zivotinja.model.Anketa;
import com.example.zivotinja.repository.AnketaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpMethod;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.web.client.RestTemplate;
import java.util.List;

@Service
public class AnketaService {
    @Autowired
    private AnketaRepository anketaRepository;

    @Autowired
    private RestTemplate restTemplate;

    public AnketaService(AnketaRepository anketaRepository) {
        this.anketaRepository = anketaRepository;
    }

    public List<Anketa> findAll() {
        return anketaRepository.findAll();
    }

    public Anketa findById(Long id) {
        return anketaRepository.findById(id).orElseThrow(() -> new AnketaException(id));
    }

    public ResponseEntity<String> findZivotinja(Long id) {
        Long idZivotinje = anketaRepository.findZivotinjaById(id);
        String url = "http://zivotinjaService/zivotinje/" + idZivotinje;
        String response = restTemplate.exchange(url,
                HttpMethod.GET, null, String.class).getBody();
        return new ResponseEntity<>(
                response,
                HttpStatus.OK
        );
    }
}
