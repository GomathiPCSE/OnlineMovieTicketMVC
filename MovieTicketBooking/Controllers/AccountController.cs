using MovieTicketBooking.DAL;
using MovieTicketBooking.BL;
using MovieTicketBooking.Entity;
using MovieTicketBooking.Models;
using System.Web.Mvc;
using System.Web.Security;
using System;
using System.Web;

namespace MovieTicketBooking.Controllers
{
    public class AccountController : Controller
    {
        IUserBl userBl;
        public AccountController()
        {
            userBl = new UserBl();
        }
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SignUpModel signUp)      //Action methos for sign up
        {
            if (ModelState.IsValid)                         //validation checking
            {
                var user = AutoMapper.Mapper.Map<SignUpModel, UserAccount>(signUp); //using Auto Mapper
                userBl.SignUp(user);
                if (signUp.Role == "Theatre Manager")
                {
                    int id = userBl.GetUserId(signUp.MailId);
                    TempData["id"] = id;
                    return RedirectToAction("SignUpNext");      //Redirect to signup next page
                }
                else
                {
                    ViewBag.message = "Registered successfully completed";
                    return View("SignIn");
                }
            }
            return View();
        }
        public ActionResult SignUpNext()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles="Theatre Manager")]
        public ActionResult SignUpNext(SignUpNextModel model)          //Action method for sign up next 
        {
            if (ModelState.IsValid)
            {
                model.UserId = (int)TempData["id"];
                var theatre = AutoMapper.Mapper.Map<SignUpNextModel, Theatre>(model);   //Auto mapper
                userBl.SignUpNext(theatre);
                ViewBag.message = "Registered successfully";
            }
            return View();
        }
        [HttpGet]
        public ActionResult SignIn()    //HttpGet for sign in
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInModel signIn)  //Action method for sign in 
        {
            if (ModelState.IsValid)             //verify validation
            {
                var user = AutoMapper.Mapper.Map<SignInModel, UserAccount>(signIn); //Auto mapper
                UserAccount userEntity = userBl.ValidateLogin(user);
                if(userEntity!=null)
                {
                    Session["UserId"] = userEntity.UserId;
                    FormsAuthentication.SetAuthCookie(userEntity.MailId, false);
                    var authTicket = new FormsAuthenticationTicket(1,userEntity.MailId, DateTime.Now, DateTime.Now.AddMinutes(20), false, userEntity.Role);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    return RedirectToAction("Index", "Home");
                }
                //if (userEntity.Role == "User")
                //{   
                //    ViewBag.message = "User Login Successful";
                //}
                //else if(userEntity.Role == "Admin")
                //{
                //    ViewBag.message = "Admin Login Successful";
                //    return RedirectToAction("index", "Admin");
                //}
                //else if(userEntity.Role == "Theatre Manager")
                //{
                //    if (TheatreRepository.GetStatus(userEntity.UserId) == "Accept")
                //    {
                //        TempData["id"] = userEntity.UserId;
                //        return RedirectToAction("AddData","TheatreManager");
                //    }
                //    else
                //    {
                //        ViewBag.message = "The request is not accepted";
                //    }
                //}
                else
                    ViewBag.message = "Incorrect user name or password ";
            }
            return View();
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}