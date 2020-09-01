package com.example.ppis.service;

import com.example.ppis.dto.ResponseMessageDTO;
import com.example.ppis.dto.RoleDTO;
import com.example.ppis.model.Role;
import com.example.ppis.repository.RoleRepository;
import com.example.ppis.repository.UserRepository;
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

    public Role addNewRole(RoleDTO role) {
        return roleRepository.save(new Role(role.getRoleName()));
    }

    public Role editRole(Role newRole, Integer id) throws Exception {
        if (!roleRepository.existsById(id)) {
            throw new Exception("Rola sa id-em " + id + " ne postoji");
        }
        roleRepository.findById(id).map(
                role -> {
                    role.setName(newRole.getName());
                    return roleRepository.save(role);
                }
        );
        return roleRepository.findById(id).get();
    }

    public HashMap<String, String> deleteRole(Integer id) throws Exception {
        if (!roleRepository.existsById(id)) {
            throw new Exception("Rola sa id-em " + id + " ne postoji");
        }
        deleteDependencies(id);
        roleRepository.deleteById(id);
        return new ResponseMessageDTO("Uspjesno obrisana uloga sa id-em " + id).getHashMap();
    }

    public List<Role> getAllRoles() {
        List<Role> sveUloge = new ArrayList<>();
        roleRepository.findAll().forEach(sveUloge::add);
        return sveUloge;
    }

    private void deleteDependencies(Integer roleId) {
        userRepository.findAll().forEach(user -> {
            if (user.getRoleList() != null) {
                List<Role> userRoleList = new ArrayList<>();
                if(!user.getRoleList().isEmpty()) {
                    user.getRoleList().forEach(role -> {
                        if (role.getId() == roleId) {
                            userRoleList.add(role);
                        }
                    });
                }
                user.getRoleList().removeAll(userRoleList);
                userRepository.save(user);
            }
        });
    }

}
