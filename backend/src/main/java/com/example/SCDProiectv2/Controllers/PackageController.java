package com.example.SCDProiectv2.Controllers;

import com.example.SCDProiectv2.DTOs.PackageCreateRequestDTO;
import com.example.SCDProiectv2.Models.DeliveryPackage;
import com.example.SCDProiectv2.Models.PackageStatus;
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
    public ResponseEntity<?> createDelivery(@RequestBody PackageCreateRequestDTO packageDTO) {
        System.out.println(packageDTO.toString());
        return ResponseEntity.ok(packageService.createDeliveryPackage(packageDTO));
    }

    @GetMapping("get-all")
    public List<DeliveryPackage> getAllPackages(){
        return packageService.findAllPackages();
    }

    @GetMapping("/my-deliveries")
    public ResponseEntity<?> getMyDeliveries(){
        return ResponseEntity.ok().body(packageService.findCurrentCourierDeliveries());
    }

    @GetMapping("/new-deliveries")
    public ResponseEntity<?> getNewDeliveries(){
        return ResponseEntity.ok().body(packageService.findPackagesByStatus(PackageStatus.NEW));
    }

    @PostMapping("accept-delivery/{deliveryAddress}")
    public ResponseEntity<?> acceptDelivery(@PathVariable String deliveryAddress) {

        return ResponseEntity.ok().body(packageService.changeDeliveryStatus(deliveryAddress,PackageStatus.PENDING));
    }

    @PostMapping("complete-delivery/{deliveryAddress}")
    public ResponseEntity<?> completeDelivery(@PathVariable String deliveryAddress) {
        return ResponseEntity.ok().body(packageService.changeDeliveryStatus(deliveryAddress,PackageStatus.DELIVERED));
    }

}
