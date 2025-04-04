package com.example.SCDProiectv2.Filter;

import com.example.SCDProiectv2.Services.JwtService;
import com.example.SCDProiectv2.Services.UserDetailsServiceImp;
import jakarta.servlet.FilterChain;
import jakarta.servlet.ServletException;
import jakarta.servlet.http.HttpServletRequest;
import jakarta.servlet.http.HttpServletResponse;
import org.springframework.lang.NonNull;
import org.springframework.security.authentication.UsernamePasswordAuthenticationToken;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.web.authentication.WebAuthenticationDetailsSource;
import org.springframework.stereotype.Component;
import org.springframework.web.filter.OncePerRequestFilter;

import java.io.IOException;

@Component
public class JwtAuthenticationFilter extends OncePerRequestFilter {

    private final JwtService jwtService;
    private final UserDetailsServiceImp userDetailsImp;
    public JwtAuthenticationFilter(JwtService jwtService, UserDetailsServiceImp userDetailsImp) {
        this.jwtService = jwtService;
        this.userDetailsImp = userDetailsImp;
    }

    @Override
    protected void doFilterInternal(
            @NonNull                 HttpServletRequest request,
            @NonNull                HttpServletResponse response,
            @NonNull                FilterChain filterChain)
            throws ServletException, IOException {
        String authHeader = request.getHeader("Authorization");
        if (authHeader == null || !authHeader.startsWith("Bearer ")) {
            filterChain.doFilter(request, response);
            return;
        }

        String token = authHeader.substring(7);
        String username = jwtService.extractUsername(token);
        System.out.println("Extracted username: " + username);

        if(username != null && SecurityContextHolder.getContext().getAuthentication() == null) {
            UserDetails userDetails = userDetailsImp.loadUserByUsername(username);
            System.out.println("Loaded user details: " + userDetails.getUsername());

            if(jwtService.isValid(token, userDetails)) {
                System.out.println("JWT is valid");
                UsernamePasswordAuthenticationToken authenticationToken = new UsernamePasswordAuthenticationToken(
                        userDetails, null, userDetails.getAuthorities()
                );
                authenticationToken.setDetails(
                        new WebAuthenticationDetailsSource().buildDetails(request)
                );

                SecurityContextHolder.getContext().setAuthentication(authenticationToken);
            } else {
                System.out.println("JWT is invalid");
            }
        }
        filterChain.doFilter(request, response);


    }
}
