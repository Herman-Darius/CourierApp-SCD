using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementUI_CourierApp.Models
{
    public class DeliveryPackage
    {
        //public int id { get; set; }

        public DateTime? createdOn {  get; set; }
        public string deliveryAddress { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        public bool payOnDelivery { get; set; }
        public string status { get; set; }

        public Courier courier { get; set; }

        //public string status { get; set; }
        //public PackageStatus status { get; set; }
        //public bool payOnDelivery { get; set; }
        //public DateTime? DeliveryDate { get; set; }
    }
}
