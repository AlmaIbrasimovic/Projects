package com.example.zivotinja.service;
import java.util.*;
import com.example.zivotinja.exception.ZivotinjaException;
import com.example.zivotinja.model.Zivotinja;
import com.example.zivotinja.repository.ZivotinjaRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class ZivotinjaService {

    @Autowired
    private ZivotinjaRepository zivotinjaRepository;

    public ZivotinjaService(ZivotinjaRepository repo) {
        zivotinjaRepository = repo;
    }

    public List<Zivotinja> findAll() {
        return zivotinjaRepository.findAll();
    }

    public List<Zivotinja> findByName(String ime) throws Exception {
        if (zivotinjaRepository.findByName(ime).size() == 0) {
            throw new Exception("Ne postoji zivotinja sa imenom " + ime);
        }
        return zivotinjaRepository.findByName(ime);
    }

    public Zivotinja findById(Long id) throws Exception {
        return zivotinjaRepository.findById(id).orElseThrow(() -> new ZivotinjaException(id));
    }

    public void deleteAll() throws Exception {
        if (zivotinjaRepository.count() == 0) {
            throw new Exception("Baza ne sadrzi niti jednu zivotinju!");
        }
        zivotinjaRepository.deleteAll();
    }

    public void deleteByName(String ime) throws Exception {
        if (zivotinjaRepository.findByName(ime).size() == 0) {
            throw new Exception("Ne postoji zivotinja sa imenom " + ime);
        }
        zivotinjaRepository.deleteByName(ime);
    }

    public void deleteById(Long id) throws Exception {
        if (!zivotinjaRepository.existsById(id)) {
            throw new Exception("Ne postoji zivotinja sa id " + id);
        }
        zivotinjaRepository.deleteById(id);
    }

    public Zivotinja put(Zivotinja novaZivotinja, Long id) throws Exception {
        if (!zivotinjaRepository.existsById(id)) {
            throw new Exception("Zivotinja sa id " + id + " ne postoji u bazi!");
        }
        return zivotinjaRepository.findById(id)
                .map(zivotinja -> {
                    zivotinja.setSlika(novaZivotinja.getSlika());
                    zivotinja.setDodatniOpis(novaZivotinja.getDodatniOpis());
                    zivotinja.setGodine(novaZivotinja.getGodine());
                    zivotinja.setIme(novaZivotinja.getIme());
                    zivotinja.setRasa(novaZivotinja.getRasa());
                    zivotinja.setSpol(novaZivotinja.getSpol());
                    zivotinja.setTezina(novaZivotinja.getTezina());
                    zivotinja.setUdomljena(novaZivotinja.isUdomljena());
                    zivotinja.setVelicina(novaZivotinja.getVelicina());
                    zivotinja.setVrsta(novaZivotinja.getVrsta());
                    zivotinja.setKorisnikId(novaZivotinja.getKorisnikId());
                    return zivotinjaRepository.save(zivotinja);
                })
                .orElseGet(() -> {
                    novaZivotinja.setId(id);
                    return zivotinjaRepository.save(novaZivotinja);
                });
    }

    public Zivotinja post(Zivotinja zivotinja) {
        return zivotinjaRepository.save(zivotinja);
    }

    public Map<String, Integer> getGodine(Long id) throws Exception {
        if (!zivotinjaRepository.existsById(id)) {
            throw new Exception("Ne postoji zivotinja sa id " + id);
        }
        List<Zivotinja> ziv = zivotinjaRepository.findByAge(id);
        HashMap<String, Integer> mapa = new HashMap<>();
        int godine = 0;
        for (Zivotinja ob : ziv) {
            godine = ob.getGodine();
        }
        mapa.put("godine", godine);
        return mapa;
    }

    public List<Zivotinja> zivotinjeKorisnika (Long id) throws Exception{
        if (zivotinjaRepository.existsByKorisnikId(id) == 0) {
            throw new Exception("Korisnik sa id "+ id + " nije udomio niti jednu zivotinju!");
        }
        return zivotinjaRepository.zivotinjeKorisnika (id);
    }
}
