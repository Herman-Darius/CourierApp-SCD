package com.example.SCDProiectv2.Controllers;

import com.example.SCDProiectv2.Models.DeliveryPackage;
import com.example.SCDProiectv2.Services.PackageService;
import org.springframework.web.bind.annotation.*;

import java.util.List;
@RestController
@RequestMapping("/package")
@CrossOrigin
public class PackageController {

    private final PackageService packageService;

    public PackageController(PackageService packageService) {
        this.packageService = packageService;
    }

    @PostMapping
    public DeliveryPackage create(@RequestBody DeliveryPackage myPackage)
    {
        return packageService.create(myPackage);
    }

    @GetMapping
    public List<DeliveryPackage> getAllPackages(){
        return packageService.findAllPackages();
    }
}
