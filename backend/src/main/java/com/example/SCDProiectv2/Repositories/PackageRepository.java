package com.example.SCDProiectv2.Repositories;

import com.example.SCDProiectv2.Models.DeliveryPackage;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface PackageRepository extends JpaRepository<DeliveryPackage, Integer> {

    List<DeliveryPackage> findByCourierId(Integer courierId);

    List<DeliveryPackage> findByStatus(String status);
}
