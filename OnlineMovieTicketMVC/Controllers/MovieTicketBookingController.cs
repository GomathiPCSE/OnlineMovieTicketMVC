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
        public ActionResult test()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserEntity user)
        {
            UserRepository.SignUp(user);
            return View();
        }
        [ActionName("Login")]
        public ActionResult SignIn()
        {
            return View("SignIn");
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}