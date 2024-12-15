import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CreateDeliveryComponent } from './create-delivery/create-delivery.component';
import { OrderDetailsComponent } from './order-details/order-details.component';

const routes: Routes = [
  { path: '', redirectTo: '/create-delivery', pathMatch: 'full' },
  { path: 'create-delivery', component: CreateDeliveryComponent },
  { path: 'order-details/:awbNumber', component: OrderDetailsComponent },
  { path: '**', redirectTo: '/create-delivery' }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
