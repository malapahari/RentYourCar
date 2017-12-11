using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace RentYourCar.Models
{
    public class Car
    {
        public Car()
        {            
        }

        public int CarId { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public Decimal Odometer { get; set; }
        public string Color { get; set; }
        public string CarLocation { get; set; }
        public Decimal PricePerDay { get; set; }
        public Decimal PricePerExtraMile { get; set; }
        public int AllowedMileagePerDay { get; set; }

    }


    public enum Make
    {
        Toyota,
        Honda,
        Nissan
    }

    public enum Model
    {
        Corolla,
        Camry,
        Altima,
        Rogue,
        Civic,
        CRV
    }


}
