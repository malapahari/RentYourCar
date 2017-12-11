using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentYourCar.Models
{
    public class User
    {
        public User()
        {
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

    }
}
