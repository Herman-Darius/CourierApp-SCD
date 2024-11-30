package com.example.SCDProiectv2.Repositories;

import com.example.SCDProiectv2.Models.DeliveryPackage;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import java.util.List;
import java.util.Optional;

@Repository
public interface DeliveryPackageRepository extends JpaRepository<DeliveryPackage, Integer> {

    List<DeliveryPackage> findByCourierId(Integer courierId);

    List<DeliveryPackage> findByStatus(String status);

    Optional<DeliveryPackage> findByCourierIdAndStatus(Integer courierId, String status);
    //Optional<DeliveryPackage> findByPhoneNumberAndName(String phoneNumber, String name);
}
