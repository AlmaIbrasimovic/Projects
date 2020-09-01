package com.example.ppis.service;

import com.example.ppis.dto.ResponseMessageDTO;
import com.example.ppis.dto.UserLoginDTO;
import com.example.ppis.dto.UserRegisterDTO;
import com.example.ppis.dto.UserRoleDTO;
import com.example.ppis.model.Role;
import com.example.ppis.model.User;
import com.example.ppis.repository.RoleRepository;
import com.example.ppis.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Optional;

@Service
public class UserService {

    @Autowired
    private UserRepository userRepository;
    @Autowired
    private RoleRepository roleRepository;
    private BCryptPasswordEncoder passwordEncoder = new BCryptPasswordEncoder();

    public User register(UserRegisterDTO userRegisterDTO) {
        User newUser = new User(userRegisterDTO.getUsername(),userRegisterDTO.getPassword(),userRegisterDTO.getEmail(),getRoles(userRegisterDTO.getRoleList()));
        newUser.setPassword(hashPassword(newUser.getPassword()));
        return userRepository.save(newUser);
    }

    private List<Role> getRoles(List<UserRoleDTO> roleDTOS) {
        List<Role> roles = new ArrayList<>();
        for (UserRoleDTO role: roleDTOS) {
            Optional<Role> _role = roleRepository.findById(role.getRoleId());
            _role.ifPresent(roles::add);
        }
        return roles;
    }

    private String hashPassword(String password) {
        String hashPassword = passwordEncoder.encode(password);
        return hashPassword;
    }

    private boolean matchPasswords(String plainText, String hashPassword) {
        return passwordEncoder.matches(plainText, hashPassword);
    }

    public HashMap<String, String> login(UserLoginDTO user) throws Exception {
        User userWithEmail = userRepository.findByUsername(user.getUsername());

        if (userWithEmail == null) {
            throw new Exception("Korisnik s usernameom " + user.getUsername() + " ne postoji");
        } else if (!matchPasswords(user.getPassword(), userWithEmail.getPassword())) {
            throw new Exception("Pogresna sifra!");
        }
        return new ResponseMessageDTO("Uspjesno ste prijavljeni na sistem").getHashMap();
    }

    public HashMap<String, String> deleteUserById(Integer id) throws Exception {
        if (!userRepository.existsById(id)) {
            throw new Exception("Obrisan user sa id-em "+id);
        }
        userRepository.deleteById(id);
        return new ResponseMessageDTO("Uspjesno obrisan korisnik sa id-em " + id).getHashMap();
    }

    public List<User> getListOfUsers() throws Exception {
        if (userRepository.count() == 0) {
            throw new Exception("Nema korisnika u bazi");
        }
        List<User> sviKorisnici = new ArrayList<>();
        userRepository.findAll().forEach(sviKorisnici::add);
        return sviKorisnici;
    }
}
