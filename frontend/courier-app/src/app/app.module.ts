import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';  // Ensure FormsModule is imported
import { AppComponent } from './app.component';
import { ProductListComponent } from './components/product-list/product-list.component';  // Import the ProductListComponent
import { OrderFormComponent } from './components/order-form/order-form.component';  
// Import OrderFormComponent

@NgModule({
  declarations: [
    AppComponent,
    ProductListComponent,  // Declare the ProductListComponent here
    OrderFormComponent      // Declare the OrderFormComponent here
  ],
  imports: [
    BrowserModule,
    FormsModule  // Ensure FormsModule is imported to support ngModel
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
