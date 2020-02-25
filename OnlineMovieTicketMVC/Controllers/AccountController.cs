using MovieTicketBooking.DAL;
using MovieTicketBooking.Entity;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
namespace OnlineMovieTicketMVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult SignUp()
        {
            IEnumerable<UserEntity> UserList = UserRepository.GetDetails();
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