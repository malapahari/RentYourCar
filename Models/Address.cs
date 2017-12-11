using System;
namespace RentYourCar.Models
{
    public class Address
    {
        public Address()
        {
        }

        public int addressId { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipcode { get; set; }
        public string notes { get; set; }
    }
}
