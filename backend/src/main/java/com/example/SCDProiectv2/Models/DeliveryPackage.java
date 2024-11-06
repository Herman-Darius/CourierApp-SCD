package com.example.SCDProiectv2.Models;

import jakarta.persistence.*;
import lombok.*;

import java.time.LocalDateTime;

@Entity
@Setter
@Getter
@Table(name = "Package")
public class DeliveryPackage {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer id;

    @ManyToOne
    @JoinColumn(name = "courier_id",nullable = false)
    private Courier courier;

    @Column(name = "created_on", nullable = false, updatable = false)
    private LocalDateTime createdOn = LocalDateTime.now();

    @Column(name = "delivery_address", nullable = false)
    private String deliveryAddress;

    @Column(name = "pay_on_delivery")
    private boolean payOnDelivery = false;

    @Enumerated(EnumType.STRING)
    @Column(name = "status")
    private PackageStatus status;



}
