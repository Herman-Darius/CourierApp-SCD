package com.example.SCDProiectv2.Models;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.Setter;

import java.time.LocalDateTime;
import java.util.Set;

@Entity
@Setter
@Getter
@Table(name = "Package")
public class DeliveryPackage {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @ManyToOne
    @JoinColumn(name = "courier_id", nullable = false)
    private Courier courier;

    @Column(name = "created_on", nullable = false, updatable = false)
    private LocalDateTime createdOn = LocalDateTime.now();

    @Column(name = "delivery_address", nullable = false)
    private String deliveryAddress;

    @Column(name = "email", nullable = false)
    private String email;

    @Column(name = "phone_number", nullable = false)
    private String phoneNumber;

    @Column(name = "pay_on_delivery")
    private boolean payOnDelivery = false;

    @Enumerated(EnumType.STRING)
    @Column(name = "status")
    private PackageStatus status;

    // Many-to-many relationship with Product
    /*
    @ManyToMany
    @JoinTable(
            name = "package_products",
            joinColumns = @JoinColumn(name = "package_id"),
            inverseJoinColumns = @JoinColumn(name = "product_id")
    )
    private Set<Product> products;
    */

    @Override
    public String toString() {
        return "DeliveryPackage{" +
                "id=" + id +
                ", deliveryAddress='" + deliveryAddress + '\'' +
                ", email='" + email + '\'' +
                ", phoneNumber='" + phoneNumber + '\'' +
                '}';
    }
}
