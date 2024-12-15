import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'courier-app';
  constructor(private router: Router) {}

  navigateToCreateDelivery() {
    this.router.navigate(['/create-delivery']);
  }
}

