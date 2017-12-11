using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentYourCar.Models
{
    public class UserRental
    {
        public UserRental()
        {
        }

        public int UserRentalId { get; set; }
        public int RenterUserId { get; set; }
        public int CarId { get; set; }
        public Decimal StartOdometer { get; set; }
        public Decimal EndOdometer { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public string Notes { get; set; }
        public Decimal CarRating { get; set; }
        public Decimal RentersRating { get; set; }
        public Decimal RentalPrice { get; set; }

        public virtual Car Car { get; set; }
        [ForeignKey("RenterUserId")]
        public virtual User User { get; set; }

    }
}