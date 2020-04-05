using MovieTicketBooking.BL;
using MovieTicketBooking.DAL;
using MovieTicketBooking.Entity;
using MovieTicketBooking.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MovieTicketBooking.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        IUserBl userBl;
        ITheatreBl theatreBl;
        public AdminController()
        {
            userBl = new UserBl();
            theatreBl = new TheatreBl();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayTheatre()    //Action method for display the theatre details
        {
            IEnumerable<Theatre> theatre = theatreBl.DisplayTheatre();  
            List<SignUpNextModel> displayTheatre = new List<SignUpNextModel>();
            foreach (var result in theatre)
            {
                SignUpNextModel signUpNextModel = AutoMapper.Mapper.Map<Theatre, SignUpNextModel>(result);  //using Auto mapper
                displayTheatre.Add(signUpNextModel);
            }
            return View(displayTheatre);
        }
        public ActionResult DisplayUser()   //Action method for display the user details
        {
            IEnumerable<UserAccount> user = userBl.DisplayUser();
            List<SignUpModel> displayUser = new List<SignUpModel>();
            foreach (var result in user)
            {
                SignUpModel signUpModel = AutoMapper.Mapper.Map<UserAccount, SignUpModel>(result);  //using auto mapper
                displayUser.Add(signUpModel);
            }
            return View(displayUser);
        }
        [HttpGet]
        public ActionResult DeleteUser(int id)  //Action method for delete the user account
        {
            UserAccount user = userBl.GetUserById(id);
            userBl.DeleteUser(user);
            return RedirectToAction("DisplayUser");
        }
        [HttpGet]
        public ActionResult AcceptTheatre(int id)   //Action method for accept the theatre request
        {
            Theatre theatre = theatreBl.GetTheatreById(id);
            theatreBl.AcceptRequest(theatre);
            return RedirectToAction("DisplayTheatre");
        }
        [HttpGet]
        public ActionResult DeleteTheatre(int id)   //Action method for reject the theatre request
        {
            Theatre theatre = theatreBl.GetTheatreById(id);
            theatreBl.DeleteTheatre(theatre);
            return RedirectToAction("DisplayTheatre");
        }
    }
}