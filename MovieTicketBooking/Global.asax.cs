using MovieTicketBooking.App_Start;
using MovieTicketBooking.Models;
using System.Web.Mvc;
using System.Web.Routing;
namespace MovieTicketBooking
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
            MapConfig.RegisterMap();
        }
    }
}
