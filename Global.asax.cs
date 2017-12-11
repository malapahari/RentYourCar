using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using System.Data.Entity;
using RentYourCar.DAL;

namespace RentYourCar
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer<RentYourCarDBContext>(new CreateDatabaseIfNotExists<RentYourCarDBContext>());
        }
    }
}
