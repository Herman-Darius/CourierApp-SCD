import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PackageCreateRequestDTO } from './create-delivery/package-create-request.dto';
import { PackageEditDTO } from '../DTOs/package-edit.dto';

@Injectable({
  providedIn: 'root'
})
export class DeliveryService {

  private apiUrl = 'http://localhost:8080/package';

  constructor(private http: HttpClient) {}

  createPackage(packageData: PackageCreateRequestDTO): Observable<any> {
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    return this.http.post<any>(`${this.apiUrl}/create`, packageData, { headers });
  }

  getOrderDetails(awbNumber: string): Observable<any> {
    return this.http.get<any>(`http://localhost:8080/package/get-order-details/${awbNumber}`);
  }
  updateAddress(awbNumber: string, newAddress: string): Observable<any> {
    const editPackageDTO = new PackageEditDTO(awbNumber, newAddress);
    return this.http.post<any>(`${this.apiUrl}/edit/${awbNumber}`, editPackageDTO);
  }

  deletePackage(awbNumber: string): Observable<any> {
    return this.http.delete<any>(`${this.apiUrl}/delete/${awbNumber}`);
  }
}

