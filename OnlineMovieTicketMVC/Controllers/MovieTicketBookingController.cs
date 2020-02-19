using MovieTicketBooking.DAL;
using MovieTicketBooking.Entity;
using System.Web.Mvc;

namespace OnlineMovieTicketMVC.Controllers
{
    public class MovieTicketBookingController : Controller
    {
        public ActionResult SignUp(UserClass user)
        {
            UserRepository.SignUp(user);
            return View();
        }
        public ActionResult SignIn()
        {
            return View();
        }
        // GET: MovieTicketBooking
        public ActionResult Index()
        {
            return View();
        }
    }
}