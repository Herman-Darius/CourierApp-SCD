package com.example.SCDProiectv2.Controllers;

import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

import java.util.List;

@RestController
@CrossOrigin
public class CourierController {

    @GetMapping("/courier/{id}/packages")
    public List<Package> getPackagesForCourier(
            @PathVariable("id") int id
    ){
        return List.of();
    }
}
