package com.example.SCDProiectv2.Controllers;

import com.example.SCDProiectv2.DTOs.CourierDTO;
import com.example.SCDProiectv2.Models.Courier;
import com.example.SCDProiectv2.Repositories.CourierRepository;
import com.example.SCDProiectv2.Services.CourierService;
import lombok.AllArgsConstructor;
import lombok.NoArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.*;

import java.util.ArrayList;
import java.util.List;
import java.util.Set;

@RestController
@CrossOrigin
@AllArgsConstructor

public class CourierController {
    private CourierService courierService;

    @GetMapping("/courier/{id}/packages")
    public List<Package> getPackagesForCourier(
            @PathVariable("id") int id
    ){
        return List.of();
    }


    @PostMapping("/courier/assign")
    public ResponseEntity<?> assignCourierToAdmin(@RequestParam Integer courierId, @RequestParam Integer adminId) {
        Courier updatedCourier = courierService.assignCourierToAdmin(courierId, adminId);
        return ResponseEntity.ok(updatedCourier);
    }
    @GetMapping("/courier/{adminId}/couriers")
    public ResponseEntity<?> getCouriersManagedByAdmin(@PathVariable Integer adminId) {
        Set<CourierDTO> couriers = courierService.getCouriersManagedByAdmin(adminId);
        return ResponseEntity.ok(couriers);
    }
    @GetMapping("/courier/get-all")
    public ResponseEntity<?> getAllCouriers() {
        return ResponseEntity.ok(courierService.getAllCouriers());
    }

}
