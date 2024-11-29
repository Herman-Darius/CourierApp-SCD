package com.example.SCDProiectv2.Services;

import com.example.SCDProiectv2.Models.AuthenticationResponse;
import com.example.SCDProiectv2.Models.Role;
import com.example.SCDProiectv2.Models.Courier;
import com.example.SCDProiectv2.Repositories.CourierRepository;
import lombok.AllArgsConstructor;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

@Service
@AllArgsConstructor
public class AuthenticationService {
    private final CourierRepository courierRepository;
    private final PasswordEncoder passwordEncoder;
    private final JwtService jwtService;
    private final AuthenticationManager authenticationManager;

    public AuthenticationResponse register(Courier request){
        Courier user = new Courier();
        user.setUsername(request.getUsername());
        user.setPassword(passwordEncoder.encode(request.getPassword()));
        user.setFirstName(request.getFirstName());
        user.setLastName(request.getLastName());
        user.setEmail(request.getEmail());
        user.setRole(Role.ADMIN);
        user = courierRepository.save(user);

        String token = jwtService.generateToken(user);

        return new AuthenticationResponse(token);
    }

    public AuthenticationResponse registerDemo(Courier request){
        Courier user = new Courier();
        user.setUsername(request.getUsername());
        user.setPassword(passwordEncoder.encode(request.getPassword()));
        user.setFirstName("Herman");
        user.setLastName("Darius");
        user.setEmail(request.getEmail());
        user.setRole(Role.ADMIN);

        user = courierRepository.save(user);

        String token = jwtService.generateToken(user);

        return new AuthenticationResponse(token);
    }


    public AuthenticationResponse authenticate(Courier request){
        authenticationManager.authenticate(new UsernamePasswordAuthenticationToken(request.getUsername(), request.getPassword()));
        Courier user = courierRepository.findByUsername(request.getUsername()).orElseThrow();
        String token = jwtService.generateToken(user);
        return new AuthenticationResponse(token);

    }

}
