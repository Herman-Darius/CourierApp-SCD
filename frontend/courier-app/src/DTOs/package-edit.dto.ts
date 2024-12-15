// Define the DTO for editing the package
export class PackageEditDTO {
    awbNumber: string;
    deliveryAddress: string;

  constructor(awbNumber: string, deliveryAddress: string) {
    this.awbNumber = awbNumber;
    this.deliveryAddress = deliveryAddress;
    
  }
  }
  