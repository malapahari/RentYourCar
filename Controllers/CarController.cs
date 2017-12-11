using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using RentYourCar.DAL;
using System.Linq;
using System.Data.Entity;
using RentYourCar.Models;
using System.Net;

namespace RentYourCar.Controllers
{
    public class CarController : Controller
    {        

        RentYourCarDBContext db = new RentYourCarDBContext();

        public ActionResult ListYourCar()
        {
            if (Session["user"] != null)
            {
                return View("ListYourCar");
            }else{
                return RedirectToAction("Index","User");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ListYourCar(Car car)
        {
            if (Session["user"] != null)
            {

                Models.User user = (Models.User)Session["user"];

                car  = db.Cars.Add(car);
                db.SaveChanges();

                //save it as user car.

                UserCar userCar = new UserCar();
                userCar.CarId = car.CarId;
                userCar.UserId = user.UserId;
                userCar.Status = "Active";

                db.UserCars.Add(userCar);
                db.SaveChanges();

                return RedirectToAction("MyCars", "Car");
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }


        public ActionResult Rent(int? carId)
        {
            if (carId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            if (Session["user"] != null)
            {
                Car car = db.Cars.Find(carId);
                UserRental ur = new UserRental();
                ur.Car = car;

                return View("UserRental", ur);
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserRental(UserRental userRental)
        {
            if (Session["user"] != null)
            {
                Models.User user = (Models.User)Session["user"];
                userRental.RenterUserId = user.UserId;

                //calculate total price

                var totalDays = userRental.RentalEndDate.Subtract(userRental.RentalStartDate).TotalDays;
                Car car = db.Cars.Find(userRental.CarId);

                var totalPrice = decimal.Multiply(car.PricePerDay, (decimal)totalDays);

                userRental.RentalPrice = totalPrice;

                db.UserRentals.Add(userRental);
                db.SaveChanges();

                return RedirectToAction("MyCarRentals", "Car");
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }

        public ActionResult MyCars()
        {
            if (Session["user"] != null)
            {

                User user = (User)Session["user"];

                var cars = db.UserCars                             
                             .Where(i => i.UserId == user.UserId)
                             .Include(x => x.Car)
                             .ToList();
                
                return View("MyCars",cars);
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }


        public ActionResult ListAllCars()
        {
            if (Session["user"] != null)
            {

                User user = (User)Session["user"];

                var cars = db.Cars.ToList();

                return View("ListAllCars", cars);
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }


        public ActionResult MyCarRentals()
        {
            if (Session["user"] != null)
            {

                User user = (User)Session["user"];

                var cars = db.UserRentals
                             .Where(i => i.RenterUserId == user.UserId)
                             .Include(x => x.Car)
                             .ToList(); 

                return View("MyCarRentals", cars);
            }
            else
            {
                return RedirectToAction("Index", "User");
            }
        }

    }
}
