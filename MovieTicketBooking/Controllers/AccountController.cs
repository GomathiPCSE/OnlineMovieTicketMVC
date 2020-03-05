using MovieTicketBooking.DAL;
using MovieTicketBooking.Entity;
using MovieTicketBooking.Models;
using System.Collections.Generic;
using System.Web.Mvc;
namespace MovieTicketBooking.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpModel signUp)
        {
            if (ModelState.IsValid)
            {
                var user = AutoMapper.Mapper.Map<SignUpModel, UserAccount>(signUp);
                UserRepository.SignUp(user);
                ViewBag.message = "Registered successfully";
                return View("SignIn");
            }
            return View("SignUp");
        }
        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInModel signIn)
        {
            if (ModelState.IsValid)
            {
                var user = AutoMapper.Mapper.Map<SignInModel, UserAccount>(signIn);
                string role = UserRepository.ValidateLogin(user);
                if (role == "User")
                {
                    ViewBag.message = "User Login Successful";
                }
                else if(role=="Admin")
                {
                    ViewBag.message = "Admin Login Successful";
                    return RedirectToAction("DisplayTheatre", "Theatre");
                }
                else
                    ViewBag.message = "Incorrect user name or password ";
            }
            return View();
        }
    }
}