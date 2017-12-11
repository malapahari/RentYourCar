using System;
namespace RentYourCar.Models
{
    public class UserCar
    {
        public UserCar()
        {
        }

        public int UserCarId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string Status{ get; set; }

        public virtual User User { get; set; }
        public virtual Car Car { get; set; }

    }
}
