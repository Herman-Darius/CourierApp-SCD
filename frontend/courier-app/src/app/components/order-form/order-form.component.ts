import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-order-form',
  templateUrl: './order-form.component.html',
  styleUrls: ['./order-form.component.css']
})

export class OrderFormComponent {
  @Input() selectedProducts: any[] = [];
  email: string = '';
  phone: string = '';
  address: string = '';

  submitOrder() {
    if (this.email && this.phone && this.address && this.selectedProducts.length > 0) {
      // Handle the order submission logic here, e.g., send order details to the backend.
      console.log('Order submitted:', {
        email: this.email,
        phone: this.phone,
        address: this.address,
        selectedProducts: this.selectedProducts
      });
    } else {
      alert('Please fill in all fields and select at least one product.');
    }
  }
}
