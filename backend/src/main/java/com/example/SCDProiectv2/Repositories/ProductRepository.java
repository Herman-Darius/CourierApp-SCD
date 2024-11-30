package com.example.SCDProiectv2.Repositories;

import com.example.SCDProiectv2.Models.Product;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface ProductRepository extends JpaRepository<Product, Integer> {
    Optional<Product> findByName(String productName);
}
