package com.example.SCDProiectv2.Services;

import com.example.SCDProiectv2.DTOs.PackageCreateRequestDTO;
import com.example.SCDProiectv2.Models.Courier;
import com.example.SCDProiectv2.Models.DeliveryPackage;
import com.example.SCDProiectv2.Models.PackageStatus;
import com.example.SCDProiectv2.Models.Product;
import com.example.SCDProiectv2.Repositories.DeliveryPackageRepository;
import com.example.SCDProiectv2.Repositories.CourierRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.core.Authentication;
import org.springframework.security.core.context.SecurityContextHolder;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

import java.sql.Date;
import java.time.LocalDateTime;
import java.util.ArrayList;
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

    /* @Transactional
    public DeliveryPackage create(DeliveryPackage myPackage) {
        Optional<Courier> courier = courierRepository.findByUsername("admin2");
        myPackage.setCourier(courier.get());
        return packageRepository.save(myPackage);
    } */

    public List<DeliveryPackage> findAllPackages() {
        return packageRepository.findAll();
    }

    @Transactional
    public ResponseEntity<?> deletePackageById(Integer packageId) {
        try{
            Authentication auth = SecurityContextHolder.getContext().getAuthentication();
            String managerName = auth.getName();
            Optional<DeliveryPackage> myPackage = packageRepository.findById(packageId);
            if(myPackage.isPresent()) {
                packageRepository.delete(myPackage.get());
                return ResponseEntity.status(HttpStatus.OK).body("Package deleted successfully");
            }else
                return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Package not found");
        } catch (Exception e){
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body(e.getMessage());
        }
    }

    /*@Transactional
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
    }*/

    public List<DeliveryPackage> findPackagesByCourierId(Integer courierId) {
        return packageRepository.findByCourierId(courierId);
    }

    public List<DeliveryPackage> findPackagesByStatus(PackageStatus status) {
        return packageRepository.findByStatus(status);
    }
    //De aici fac iar ca m-am enervat pe mine ala din trecut de a facut prostii

    @Transactional
    public ResponseEntity<?> createDeliveryPackage(PackageCreateRequestDTO deliveryPackageDTO) {
        try{
            //Authentication auth = SecurityContextHolder.getContext().getAuthentication();
            //String managerName = auth.getName();
            DeliveryPackage myPackage = new DeliveryPackage();
            myPackage.setDeliveryAddress(deliveryPackageDTO.getDeliveryAddress());
            myPackage.setEmail(deliveryPackageDTO.getEmail());
            myPackage.setPhoneNumber(deliveryPackageDTO.getPhoneNumber());
            myPackage.setCreatedOn(LocalDateTime.now());
            myPackage.setStatus(PackageStatus.NEW);
            packageRepository.save(myPackage);
            return ResponseEntity.status(HttpStatus.CREATED).body("Package created successfully");
        } catch (Exception e){
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body("ERROR FROM BACKEND ---------------->" + e.getMessage());
        }
    }

    public ResponseEntity<?> findPackageByCourierUsername(String username) {
        try{
            List<DeliveryPackage> deliveries = packageRepository.findByCourierId(Integer.parseInt(username));
            return ResponseEntity.status(HttpStatus.OK).body(deliveries);
        }
        catch (Exception e){
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body(e.getMessage());
        }
    }

    public List<DeliveryPackage> findCurrentCourierDeliveries(){
        try{
            Authentication auth = SecurityContextHolder.getContext().getAuthentication();
            String username = auth.getName();
            Optional<Courier> courier = courierRepository.findByUsername(username);
            //Sa nu uiti ca aici trebuie sa scoti alea DELIVERED si sa le afisezi altundeva, ca in C# apar si PENDING si DELIVERED <3
            if(courier.isPresent()) {
                List<DeliveryPackage> deliveries = packageRepository.findByCourierId(courier.get().getId());
                System.out.println("---------------------------------------------------------------" + deliveries.toString());
                return deliveries;
            }
            else
                return new ArrayList<>();

        } catch (Exception e){
            System.out.println(e.getMessage());
            return new ArrayList<>();
        }
    }

    /*public ResponseEntity<?> takeDelivery(String address) {

        try{
            Authentication auth = SecurityContextHolder.getContext().getAuthentication();
            String username = auth.getName();
            System.out.println("Asta e contu care vrea sa ia comanda: "+ username);
            Optional<Courier> courier = courierRepository.findByUsername(username);
            Optional<DeliveryPackage> myPackage = packageRepository.findByDeliveryAddress(address);
            if(courier.isPresent()) {
                if(myPackage.isPresent()) {
                    myPackage.get().setStatus(PackageStatus.PENDING);
                    myPackage.get().setCourier(courier.get());
                    packageRepository.save(myPackage.get());
                    return ResponseEntity.status(HttpStatus.OK).body("Package taken successfully");
                } else{
                    return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Package not found");
                }

            } else {
                return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Courier not found");
            }
        } catch (Exception e){
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body(e.getMessage());
        }
    }*/

    public ResponseEntity<?> changeDeliveryStatus(String address, PackageStatus status) {

        try{
            Authentication auth = SecurityContextHolder.getContext().getAuthentication();
            String username = auth.getName();

            Optional<Courier> courier = courierRepository.findByUsername(username);
            Optional<DeliveryPackage> myPackage = packageRepository.findByDeliveryAddress(address);
            if(courier.isPresent()) {
                if(myPackage.isPresent()) {
                    myPackage.get().setStatus(status);
                    myPackage.get().setCourier(courier.get());
                    packageRepository.save(myPackage.get());
                    System.out.println(username + "a schimbat statusul pachetului in " +status);
                    return ResponseEntity.status(HttpStatus.OK).body("Package taken successfully");
                } else{
                    return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Package not found");
                }

            } else {
                return ResponseEntity.status(HttpStatus.NOT_FOUND).body("Courier not found");
            }
        } catch (Exception e){
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body(e.getMessage());
        }
    }




}
