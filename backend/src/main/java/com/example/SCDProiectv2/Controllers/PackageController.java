package com.example.SCDProiectv2.Controllers;

import com.example.SCDProiectv2.DTOs.PackageCreateRequestDTO;
import com.example.SCDProiectv2.Models.DeliveryPackage;
import com.example.SCDProiectv2.Services.DeliveryPackageService;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.util.List;
@RestController
@RequestMapping("/package")
@CrossOrigin(origins = "http://localhost:8080")
public class PackageController {

    private final DeliveryPackageService packageService;

    public PackageController(DeliveryPackageService packageService) {
        this.packageService = packageService;
    }

    //@PreAuthorize("hasRole('ADMIN')")
    @PostMapping("create")
    public ResponseEntity<?> create(@RequestBody PackageCreateRequestDTO packageDTO) {
        try {
            DeliveryPackage newPackage = new DeliveryPackage();
            newPackage.setDeliveryAddress(packageDTO.getDeliveryAddress());
            newPackage.setEmail(packageDTO.getEmail());
            newPackage.setPhoneNumber(packageDTO.getPhoneNumber());
            System.out.println("Saving package: " + newPackage);
            DeliveryPackage createdPackage = packageService.create(newPackage);
            return ResponseEntity.ok(createdPackage);
        } catch (Exception e) {
            e.printStackTrace();
            return ResponseEntity.status(HttpStatus.INTERNAL_SERVER_ERROR).body("An error occurred while creating the package.");
        }
    }

    @GetMapping("get-all")
    public List<DeliveryPackage> getAllPackages(){
        return packageService.findAllPackages();
    }
}
