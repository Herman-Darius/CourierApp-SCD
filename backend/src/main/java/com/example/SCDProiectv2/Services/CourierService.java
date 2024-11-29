package com.example.SCDProiectv2.Services;

import com.example.SCDProiectv2.DTOs.CourierDTO;
import com.example.SCDProiectv2.Models.Courier;
import com.example.SCDProiectv2.Repositories.CourierRepository;
import jakarta.transaction.Transactional;
import lombok.AllArgsConstructor;
import lombok.NoArgsConstructor;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Set;
import java.util.stream.Collectors;

@Service

public class CourierService {
    @Autowired
    private CourierRepository courierRepository;

    @Transactional
    public Courier assignCourierToAdmin(Integer courierId, Integer adminId) {
        Courier courier = courierRepository.findById(courierId)
                .orElseThrow(() -> new RuntimeException("Courier not found with ID: " + courierId));
        Courier admin = courierRepository.findById(adminId)
                .orElseThrow(() -> new RuntimeException("Admin not found with ID: " + adminId));

        if (!"ADMIN".equalsIgnoreCase(admin.getRole().toString())) {
            throw new RuntimeException("User with ID " + adminId + " is not an admin!");
        }

        courier.setManager(admin);
        return courierRepository.save(courier);
    }
    public List<Courier> getAllCouriers() {
        return courierRepository.findAll();
    }
    public Set<CourierDTO> getCouriersManagedByAdmin(Integer adminId) {
        Courier admin = courierRepository.findById(adminId)
                .orElseThrow(() -> new RuntimeException("Admin not found with ID: " + adminId));

        // Convert the couriers to DTOs
        return admin.getCouriers().stream()
                .map(courier -> new CourierDTO(courier.getId(), courier.getUsername()))
                .collect(Collectors.toSet());
    }
}
