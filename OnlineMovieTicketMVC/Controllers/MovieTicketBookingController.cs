using MovieTicketBooking.DAL;
using MovieTicketBooking.Entity;
using System.Web.Mvc;
namespace OnlineMovieTicketMVC.Controllers
{
    public class MovieTicketBookingController : Controller
    {
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserEntity user)
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