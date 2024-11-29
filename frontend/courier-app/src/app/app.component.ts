import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {
  selectedProducts: any[] = []; // To store selected products
  showOrderForm: boolean = false; // To toggle between product list and order form
  title = 'courier-app'; 
  receiveSelectedProducts(products: any[]): void {
    this.selectedProducts = products; // Update selectedProducts
    this.showOrderForm = true; // Show the order form
  }
}
