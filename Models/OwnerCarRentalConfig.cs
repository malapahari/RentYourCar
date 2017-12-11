using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentYourCar.Models
{
    public class OwnerCarRentalConfig
    {
        public OwnerCarRentalConfig()
        {
        }

        public int OwnerCarRentalConfigId { get; set; }
        public int CarId { get; set; }
        public string CarLocation { get; set; }
        public Decimal PricePerDay { get; set; }
        public Decimal PricePerExtraMile { get; set; }
        public int AllowedMileagePerDay { get; set; }

    }
}
