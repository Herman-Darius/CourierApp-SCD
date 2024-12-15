import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DeliveryService } from '../delivery.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css'],
})
export class OrderDetailsComponent implements OnInit {
  orderDetails: any = null;
  errorMessage: string = '';
  awbNumber2: string | null = null;
  editableAddress: string = '';
  showEditForm: boolean = false;
  isButtonDisabled: boolean = false; 

  constructor(
    private route: ActivatedRoute,
    private deliveryService: DeliveryService
  ) {}

  ngOnInit(): void {
    const awbNumber = this.route.snapshot.paramMap.get('awbNumber');
    this.awbNumber2 = awbNumber;

    if (awbNumber) {
      this.deliveryService.getOrderDetails(awbNumber).subscribe(
        (response) => {
          console.log('Order details response:', response);
          this.orderDetails = response;

          if (response && response.createdOn) {
            this.checkButtonDisabled(response.createdOn);
          }
        },
        (error) => {
          console.error('Error fetching order details:', error);
          this.errorMessage = 'Order details could not be fetched.';
        }
      );
    } else {
      this.errorMessage = 'AWB number is missing.';
    }
  }

  checkButtonDisabled(createdOn: string): void {
    const minutesSinceCreation = this.timeDiffInMinutes(createdOn);
    console.log(`Time since creation: ${minutesSinceCreation} minutes`);
    this.isButtonDisabled = minutesSinceCreation > 5;
  }

  timeDiffInMinutes(createdOn: string): number {
    const createdTime = new Date(createdOn).getTime();
    const currentTime = new Date().getTime();
    return Math.floor((currentTime - createdTime) / (1000 * 60));
  }

  editAddress(): void {
    this.showEditForm = !this.showEditForm;
    this.editableAddress = this.orderDetails.deliveryAddress;
  }

  saveEditedAddress(): void {
    if (this.editableAddress !== this.orderDetails.deliveryAddress) {
      this.deliveryService.updateAddress(this.orderDetails.awbNumber, this.editableAddress).subscribe(
        (response) => {
          this.orderDetails.deliveryAddress = this.editableAddress;
          this.showEditForm = false;
          console.log('Address updated successfully');
        },
        (error) => {
          console.error('Error updating address:', error);
          this.errorMessage = 'Failed to update the address.';
        }
      );
    } else {
      this.showEditForm = false;
    }
  }

  deleteOrder(): void {
    if (confirm('Are you sure you want to delete this order?')) {
      this.deliveryService.deletePackage(this.orderDetails.awbNumber).subscribe(
        (response) => {
          console.log('Order deleted successfully');
          this.orderDetails = null;
        },
        (error) => {
          console.error('Error deleting order:', error);
          this.errorMessage = 'Failed to delete the order.';
        }
      );
    }
  }
}
