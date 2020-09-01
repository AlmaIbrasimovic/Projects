package com.etf.korisnik_service.oauth.controller;

import com.etf.korisnik_service.model.User;
import com.etf.korisnik_service.oauth.JwtService;
import com.etf.korisnik_service.oauth.UserDetailsServiceImpl;
import com.etf.korisnik_service.oauth.model.AuthenticationRequest;
import com.etf.korisnik_service.oauth.model.AuthenticationResponse;
import com.etf.korisnik_service.oauth.model.ValidationRequest;
import com.etf.korisnik_service.oauth.model.ValidationResponse;
import com.etf.korisnik_service.repository.UserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.BadCredentialsException;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RestController;

import static com.etf.korisnik_service.oauth.SecurityConstants.AUTH_URL;
import static com.etf.korisnik_service.oauth.SecurityConstants.VALIDATION_URL;

@RestController
public class AuthenticationController {

    @Autowired
    private AuthenticationManager authenticationManager;

    @Autowired
    private UserDetailsServiceImpl userDetailsService;

    @Autowired
    private JwtService jwtService;

    @Autowired
    private UserRepository userRepository;

    @PostMapping(AUTH_URL)
    public ResponseEntity<?> createToken(@RequestBody AuthenticationRequest request) throws Exception {

        try {
            authenticationManager.authenticate(
                    new UsernamePasswordAuthenticationToken(request.getUsername(), request.getPassword())
            );
        }
        catch (BadCredentialsException e) {
            throw new Exception("Incorrect username or password", e);
        }

        final UserDetails userDetails = userDetailsService.loadUserByUsername(request.getUsername());

        final String token = jwtService.generateToken(userDetails);
        User user = userRepository.findByUsername(request.getUsername());

        return ResponseEntity.ok(new AuthenticationResponse(token,userDetails.getAuthorities().toArray()[0].toString(),user.getId()));
    }

    @PostMapping(VALIDATION_URL)
    public ResponseEntity<?> validateToken(@RequestBody ValidationRequest validationRQ) throws Exception {

        UserDetails userDetails = userDetailsService.loadUserByUsername(validationRQ.getUsername());

        if(!jwtService.validateToken(validationRQ.getToken(), userDetails)) {
            throw new BadCredentialsException("Incorrect username or password") ;
        }

        User user = userRepository.findByUsername(validationRQ.getUsername());
        return ResponseEntity.ok(new ValidationResponse(userDetails.getUsername(), userDetails.getPassword(), user.getRole().getRoleName(), user.getRole().getRoleName(), user.getId()));
    }
}
