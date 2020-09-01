package com.example.ppis.service;

import com.example.ppis.dto.ResponseMessageDTO;
import com.example.ppis.model.Contract;
import com.example.ppis.model.Suplier;
import com.example.ppis.repository.ContractRepository;
import com.example.ppis.repository.SuplierRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

@Service
public class ContractService {

    @Autowired
    private ContractRepository contractRepository;

    @Autowired
    private SuplierRepository suplierRepository;

    public List<Contract> getAll() {
        List<Contract> all = new ArrayList<>();
        contractRepository.findAll().forEach(all::add);
        return all;
    }

    public Contract add(Contract contract) throws Exception {

        if(!suplierRepository.existsById(contract.getSuplier().getId())) {
            throw new Exception("Dobavljac s id "+ contract.getSuplier().getId() + "ne postoji");
        }

        Suplier suplier = suplierRepository.findById(contract.getSuplier().getId()).orElse(null);
        contract.setSuplier(suplier);
        return contractRepository.save(contract);
    }

    public Contract update(Contract newContract, Integer id) throws Exception {
        if (!contractRepository.existsById(id)) {
            throw new Exception("Ugovor sa id-em " + id + " ne postoji");
        }
        if(!suplierRepository.existsById(newContract.getSuplier().getId())) {
            throw new Exception("Dobavljac s id "+ newContract.getSuplier().getId() + "ne postoji");
        }

        contractRepository.findById(id).map(
                contract -> {
                    contract.setName(newContract.getName());
                    contract.setSuplier(suplierRepository.findById(newContract.getSuplier().getId())
                            .orElse(null));
                    contract.setCreatedDate(newContract.getCreatedDate());
                    contract.setExpiredDate(newContract.getExpiredDate());
                    return contractRepository.save(contract);
                }
        );
        return contractRepository.findById(id).get();
    }

    public HashMap<String, String> delete(Integer id) throws Exception {
        if (!contractRepository.existsById(id)) {
            throw new Exception("Ugovor sa id-em " + id + " ne postoji");
        }

        contractRepository.deleteById(id);
        return new ResponseMessageDTO("Uspjesno obrisan ugovor sa id-em " + id).getHashMap();
    }
}
