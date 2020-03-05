using System;
using System.Web.Mvc;
namespace MovieTicketBooking.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
               return View();
        }
    }
}