package com.example.SCDProiectv2.Services;

import com.example.SCDProiectv2.Models.Courier;
import com.example.SCDProiectv2.Models.DeliveryPackage;
import com.example.SCDProiectv2.Models.PackageStatus;
import com.example.SCDProiectv2.Models.Product;
import com.example.SCDProiectv2.Repositories.DeliveryPackageRepository;
import com.example.SCDProiectv2.Repositories.CourierRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;
import java.util.Optional;
import java.util.Set;

@Service
public class DeliveryPackageService {

    @Autowired
    private DeliveryPackageRepository packageRepository;

    @Autowired
    private CourierRepository courierRepository;

    @Transactional
    public DeliveryPackage placeOrder(Set<Product> products, String deliveryAddress, String email, String phoneNumber) {

        DeliveryPackage newPackage = new DeliveryPackage();
        //newPackage.setCourier();
        newPackage.setDeliveryAddress(deliveryAddress);
        newPackage.setEmail(email);
        newPackage.setPhoneNumber(phoneNumber);
        newPackage.setStatus(PackageStatus.NEW);
        //newPackage.setProducts(products);

        return packageRepository.save(newPackage);
    }

    @Transactional
    public DeliveryPackage create(DeliveryPackage myPackage) {
        Optional<Courier> courier = courierRepository.findByUsername("admin2");
        myPackage.setCourier(courier.get());
        return packageRepository.save(myPackage);

    }

    public List<DeliveryPackage> findAllPackages() {
        return packageRepository.findAll();
    }

    @Transactional
    public void deletePackageById(Integer id) {
        if (packageRepository.existsById(id)) {
            packageRepository.deleteById(id);
        } else {
            throw new IllegalArgumentException("Package not found with ID: " + id);
        }
    }

    @Transactional
    public DeliveryPackage updatePackage(Integer id, DeliveryPackage updatedPackage) {
        Optional<DeliveryPackage> existingPackageOptional = packageRepository.findById(id);
        if (existingPackageOptional.isPresent()) {
            DeliveryPackage existingPackage = existingPackageOptional.get();
            existingPackage.setCourier(updatedPackage.getCourier());
            existingPackage.setDeliveryAddress(updatedPackage.getDeliveryAddress());
            existingPackage.setPayOnDelivery(updatedPackage.isPayOnDelivery());
            existingPackage.setStatus(updatedPackage.getStatus());
            return packageRepository.save(existingPackage);
        } else {
            throw new IllegalArgumentException("Package not found with ID: " + id);
        }
    }

    public List<DeliveryPackage> findPackagesByCourierId(Integer courierId) {
        return packageRepository.findByCourierId(courierId);
    }

    public List<DeliveryPackage> findPackagesByStatus(String status) {
        return packageRepository.findByStatus(status);
    }
}
