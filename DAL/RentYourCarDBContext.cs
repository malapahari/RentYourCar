using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using RentYourCar.Models;

namespace RentYourCar.DAL
{    
    public class RentYourCarDBContext : DbContext
    {
        public RentYourCarDBContext() : base("CarDBContext")
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserCar> UserCars { get; set; }
        public DbSet<UserRental> UserRentals { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
