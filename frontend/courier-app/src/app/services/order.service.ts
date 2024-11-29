import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  private orderApiUrl = 'http://localhost:8080/api/orders'; // URL to submit the order

  constructor(private http: HttpClient) { }

  placeOrder(orderData: any): Observable<any> {
    return this.http.post<any>(this.orderApiUrl, orderData);
  }
}
