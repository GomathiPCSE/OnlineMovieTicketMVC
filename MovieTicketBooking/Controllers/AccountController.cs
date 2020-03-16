using MovieTicketBooking.DAL;
using MovieTicketBooking.Entity;
using MovieTicketBooking.Models;
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
            }
            if(signUp.Role=="Theatre Manager")
            {
                int id = UserRepository.GetUserId(signUp.MailId);
                TempData["id"] = id;
                return RedirectToAction("SignUpNext");
            }
            else
            {
                ViewBag.message = "Registered successfully completed";
                return View("SignIn");
            }
        }
        public ActionResult SignUpNext()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUpNext(SignUpNextModel model)
        {
            model.UserId = (int)TempData["id"];
            var theatre = AutoMapper.Mapper.Map<SignUpNextModel, Theatre>(model);
            UserRepository.SignUpNext(theatre);
            ViewBag.message = "Registered successfully";
            return View();
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
                UserAccount userEntity = UserRepository.ValidateLogin(user);
                if (userEntity.Role == "User")
                {
                    ViewBag.message = "User Login Successful";
                }
                else if(userEntity.Role == "Admin")
                {
                    ViewBag.message = "Admin Login Successful";
                    return RedirectToAction("index", "Admin");
                }
                else if(userEntity.Role == "Theatre Manager")
                {
                    if (TheatreRepository.GetStatus(userEntity.UserId) == "Accept")
                    {
                        return RedirectToAction("DisplayTheatre", "Admin");
                    }
                }
                else
                    ViewBag.message = "Incorrect user name or password ";
            }
            return View();
        }
    }
}