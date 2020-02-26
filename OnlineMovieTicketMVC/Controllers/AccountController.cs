using MovieTicketBooking.DAL;
using MovieTicketBooking.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;
namespace OnlineMovieTicketMVC.Controllers
{
    [HandleError]
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
            if (ModelState.IsValid)
            {
                UserRepository.SignUp(user);
                ViewBag.message = "Registered successfully"; 
            }
            return View();
        }
        public ActionResult SignIn()
        {
            return View("SignIn");
        }
        public ActionResult Index()
        {
            //throw new Exception("This is unhandled exception");
            return View();
        }
    }
}