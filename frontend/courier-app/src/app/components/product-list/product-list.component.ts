import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent {
  @Output() productsSelected = new EventEmitter<any[]>();

  products = [
    { name: 'Product 1', price: 10 },
    { name: 'Product 2', price: 20 },
    { name: 'Product 3', price: 30 },
  ];

  selectedProducts: any[] = [];

  toggleProductSelection(product: any) {
    const index = this.selectedProducts.indexOf(product);
    if (index === -1) {
      this.selectedProducts.push(product);
    } else {
      this.selectedProducts.splice(index, 1);
    }
    this.productsSelected.emit(this.selectedProducts); // Emit selected products
  }
}
