package com.etf.korisnik_service.service;

import com.etf.korisnik_service.DTO.*;
import com.etf.korisnik_service.exception.LoginException;
import com.etf.korisnik_service.exception.UserException;
import com.etf.korisnik_service.model.Role;
import com.etf.korisnik_service.model.User;
import com.etf.korisnik_service.model.UserAnimal;
import com.etf.korisnik_service.repository.UserAnimalRepository;
import com.etf.korisnik_service.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpMethod;
import org.springframework.http.HttpStatus;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.web.client.RestTemplate;

@Service
public class UserService  {

    @Autowired
    private UserRepository userRepository;
    @Autowired
    private UserAnimalRepository userAnimalRepository;
    @Autowired
    private RoleService roleService;
    @Autowired
    RestTemplate restTemplate;
    private List<User> sviKorisnici;
    private BCryptPasswordEncoder passwordEncoder = new BCryptPasswordEncoder();

    public User addUser(User noviUser) throws Exception {
       User isti = userRepository.findByUsername(noviUser.getUsername());
       if(isti != null) {
            throw new Exception("Postoji korisnik sa istim usernameom");
        }
        noviUser.setPassword(hashPassword(noviUser.getPassword()));
        return userRepository.save(noviUser);
    }

    private String hashPassword(String password) {
        String hashPassword = passwordEncoder.encode(password);
        return hashPassword;
    }

    private boolean matchPasswords(String plainText, String hashPassword) {
        return passwordEncoder.matches(plainText, hashPassword);
    }

    public HashMap<String, String> loginUser(LoginUserDTO user) throws LoginException {
        User userWithEmail = userRepository.findByEmail(user.getUsername());

        if (userWithEmail == null) {
            throw new LoginException("Korisnik s emailom " + user.getUsername() + " ne postoji");
        } else if (!matchPasswords(user.getPassword(), userWithEmail.getPassword())) {
            throw new LoginException("Pogresna sifra!");
        }
        return new ResponseMessageDTO("Uspjesno ste prijavljeni na sistem").getHashMap();
    }

    public User getUserById(Integer id) throws UserException {
        return userRepository.findById(id).orElseThrow(() -> new UserException(id));
    }

    public HashMap<String, String> deleteUserById(Integer id) throws UserException {
        if (!userRepository.existsById(id)) {
            throw new UserException(id);
        }
        deleteDependencies(id);
        userRepository.deleteById(id);
        return new ResponseMessageDTO("Uspjesno obrisan korisnik sa id-em " + id).getHashMap();
    }

    public User editUser(User noviUser) throws UserException {
        userRepository.findById(noviUser.getId()).orElseThrow(() -> new UserException(noviUser.getId()));
        userRepository.findById(noviUser.getId()).map(
                user -> {
                    user.setFullName(noviUser.getFullName());
                    user.setAddress(noviUser.getAddress());
                    user.setEmail(noviUser.getEmail());
                    user.setPhoneNumber(noviUser.getPhoneNumber());
                    return userRepository.save(user);
                }
        );
        return userRepository.findById(noviUser.getId()).get();
    }

    public HashMap<String, String> resetPassword(UserPasswordDTO user) throws UserException {
        if (!userRepository.existsById(user.getId())) {
            throw new UserException(user.getId());
        }
        userRepository.findById(user.getId()).map(_user -> {
            _user.setPassword(hashPassword(user.getPassword()));
            return userRepository.save(_user);
        });
        return new ResponseMessageDTO("Uspjesno promijenjena sifra").getHashMap();
    }

    public HashMap<String, String> resetEmail(UserEmailDTO user) throws UserException {
        if (!userRepository.existsById(user.getId())) {
            throw new UserException(user.getId());
        }
        userRepository.findById(user.getId()).map(_user -> {
            _user.setEmail(user.getEmail());
            return userRepository.save(_user);
        });
        return new ResponseMessageDTO("Uspjesno promijenjen email").getHashMap();
    }

    public User changeRole(UserRoleDTO userRoleDto) throws Exception {
        Role newRole = roleService.getByName(userRoleDto.getRoleName());
        if (!userRepository.existsById(userRoleDto.getUserId())) {
            throw new UserException(userRoleDto.getUserId());
        }
        userRepository.findById(userRoleDto.getUserId()).map(user -> {
            user.setRole(newRole);
            return userRepository.save(user);
        });

        return userRepository.findById(userRoleDto.getUserId()).get();
    }

    public List<User> getListOfUsers() throws Exception {
        if (userRepository.count() == 0) {
            throw new Exception("Nema korisnika u bazi");
        }
        List<User> sviKorisnici = new ArrayList<>();
        userRepository.findAll().forEach(sviKorisnici::add);
        return sviKorisnici;
    }

    public List<User> getAllUsersWithRole(String uloga) throws Exception {
        sviKorisnici = getListOfUsers();
        List<User> korisnici = new ArrayList<>();
        for (User user : sviKorisnici) {
            if (user.getRole() != null && user.getRole().getRoleName().equals(uloga)) {
                korisnici.add(user);
            }
        }
        if (korisnici.size() == 0) {
            throw new Exception("Nema korisnika sa tom ulogom");
        }
        return korisnici;
    }

    public User getUserWithName(String imePrezime) throws Exception {
        sviKorisnici = getListOfUsers();
        for (User user : sviKorisnici) {
            if (user.getFullName() != null && user.getFullName().equals(imePrezime)) {
                return user;
            }
        }
        throw new Exception("Nema korisnika " + imePrezime);
    }

    public HashMap<String, String> deleteAllUsers() throws Exception {
        if (userRepository.count() == 0) {
            throw new Exception("U bazi nema vise korisnika");
        }
        deleteDependencies(-1);
        userRepository.deleteAll();
        return new ResponseMessageDTO("Uspjesno obrisani korisnici").getHashMap();
    }

    public void deleteAnimalAndSurvey(Integer userId) throws Exception {
        if(!userRepository.existsById(userId)) {
            throw new UserException(userId);
        }

        HttpStatus responseZivotinja = restTemplate.exchange("http://zivotinjaService/korisnici/flag/"+userId,
                HttpMethod.GET, null,String.class).getStatusCode();
        HttpStatus responseAnketa = restTemplate.exchange("http://anketaService/v1/applicationUser/deleteById?id="+userId,
                HttpMethod.GET, null,String.class).getStatusCode();

        if(responseZivotinja.is2xxSuccessful() && responseAnketa.is2xxSuccessful()) {
            userRepository.findById(userId).map(user -> {
                user.setSoftDelete(true);
                return userRepository.save(user);
            });
        }
    }

    public Boolean checkSoftDelete(Integer userId) throws Exception {
        if(!userRepository.existsById(userId)) {
            throw new UserException(userId);
        }
        return userRepository.findById(userId).get().getSoftDelete();
    }

    public void deleteAllWithSoftDelete() {
        userRepository.deleteAllBySoftDelete(true);
    }

    private void deleteDependencies(Integer userId) {
        List<UserAnimal> userAnimalsList = new ArrayList<>();
        userAnimalRepository.findAll().forEach(userAnimalsList::add);
        for (UserAnimal userAnimal : userAnimalsList) {
            if (userId == -1) {
                userAnimalRepository.deleteAll();
                return;
            } else if (userAnimal.getUser().getId() == userId) {
                userAnimalRepository.deleteById(userAnimal.getId());
            }
        }
    }

//    @Override
//    public UserDetails loadUserByUsername(String s) throws UsernameNotFoundException {
//        User user = userRepository.findByEmail(s);
//        return new org.springframework.security.core.userdetails.User(user.getEmail(),user.getPassword(),null);
//    }
}
