import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DeliveryService } from '../delivery.service';

@Component({
  selector: 'app-create-delivery',
  templateUrl: './create-delivery.component.html',
  styleUrls: ['./create-delivery.component.css']
})
export class CreateDeliveryComponent {

  deliveryForm: FormGroup;
  successMessage: string = '';
  errorMessage: string = '';
  awbNumber: string | null = null;
  manualAWB: string | null = null;
  

  constructor(private fb: FormBuilder, private deliveryService: DeliveryService, private router: Router) {
    this.deliveryForm = this.fb.group({
      deliveryAddress: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phoneNumber: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.deliveryForm.valid) {
      const packageData = this.deliveryForm.value;

      this.deliveryService.createPackage(packageData).subscribe(
        (response) => {
          this.successMessage = 'Package created successfully. AWB: ' + response.awbNumber;
          this.awbNumber = response.awbNumber;
          this.errorMessage = '';
        },
        (error) => {
          this.successMessage = '';
          this.errorMessage = 'Failed to create delivery. Please try again.';
        }
      );
    }
  }

  viewOrderDetails() {
    const url = `/order-details/${this.awbNumber}`;
    console.log('Navigating to:', url);
    this.router.navigateByUrl(url).then((success) => {
      if (success) {
        console.log('Navigation successful');
      } else {
        console.error('Navigation failed');
      }
    }).catch((error) => {
      console.error('Navigation error:', error);
    });
  }
  orderDetails() {
    const awbToView = this.awbNumber || this.manualAWB;
    const url = `/order-details/${this.manualAWB}`;
    console.log('Navigating to:', url);
    this.router.navigateByUrl(url).then((success) => {
      if (success) {
        console.log('Navigation successful');
      } else {
        console.error('Navigation failed');
      }
    }).catch((error) => {
      console.error('Navigation error:', error);
    });
  }
}
