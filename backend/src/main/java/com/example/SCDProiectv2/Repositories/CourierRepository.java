package com.example.SCDProiectv2.Repositories;

import com.example.SCDProiectv2.Models.Courier;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;
import java.util.Optional;

public interface CourierRepository extends JpaRepository<Courier, Integer> {
    Optional<Courier> findByUsername(String username);
    boolean existsByEmail(String email);
    Optional<List<Courier>> findAllByManagerId(int managerId);

}
