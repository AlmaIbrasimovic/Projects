package com.etf.korisnik_service.service;

import com.etf.korisnik_service.DTO.ResponseMessageDTO;
import com.etf.korisnik_service.exception.RoleException;
import com.etf.korisnik_service.model.Role;
import com.etf.korisnik_service.repository.RoleRepository;
import com.etf.korisnik_service.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

@Service
public class RoleService {

    @Autowired
    private RoleRepository roleRepository;
    @Autowired
    private UserRepository userRepository;

    public Role addNewRole(Role role) {
        return roleRepository.save(role);
    }

    public Role editRole(Role newRole, Integer id) throws RoleException {
        if (!roleRepository.existsById(id)) {
            throw new RoleException(id);
        }
        roleRepository.findById(id).map(
                role -> {
                    role.setRoleName(newRole.getRoleName());
                    return roleRepository.save(role);
                }
        );
        return roleRepository.findById(id).get();
    }

    public HashMap<String,String> deleteRole(Integer id) throws RoleException {
        if (!roleRepository.existsById(id)) {
            throw new RoleException(id);
        }
        deleteDependencies(id);
        roleRepository.deleteById(id);
        return new ResponseMessageDTO("Uspjesno obrisana uloga sa id-em "+id).getHashMap();
    }

    public List<Role> getAllRoles() {
        List<Role> sveUloge = new ArrayList<>();
        roleRepository.findAll().forEach(sveUloge::add);
        return sveUloge;
    }

    public Role getById(Integer id) throws RoleException {
        if (!roleRepository.existsById(id)) {
            throw new RoleException(id);
        }
        return roleRepository.findById(id).get();
    }

    public Role getByName(String naziv) throws Exception {
        List<Role> sveUloge = getAllRoles();
        for (Role role : sveUloge) {
            if (role.getRoleName().equals(naziv)) {
                return role;
            }
        }
        throw new Exception("Ne postoji uloga sa unesenim nazivom");
    }

    public HashMap<String,String> deleteAllRoles() throws Exception {
        if (roleRepository.count() == 0) {
            throw new Exception("Ne postoji vise uloga u bazi");
        }
        deleteDependencies(-1);
        roleRepository.deleteAll();
        return new ResponseMessageDTO("Uspjesno obrisane sve uloge").getHashMap();
    }

    private void deleteDependencies(Integer roleId) {
        userRepository.findAll().forEach( user -> {
            if(user.getRole().getId() == roleId || roleId == -1) {
                user.setRole(null);
                userRepository.save(user);
            }
        });
    }
}
