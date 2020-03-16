using MovieTicketBooking.DAL;
using MovieTicketBooking.Entity;
using MovieTicketBooking.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MovieTicketBooking.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DisplayTheatre()
        {
            IEnumerable<Theatre> theatre = TheatreRepository.DisplayTheatre();
            List<SignUpNextModel> displayTheatre = new List<SignUpNextModel>();
            foreach (var result in theatre)
            {
                SignUpNextModel signUpNextModel = AutoMapper.Mapper.Map<Theatre, SignUpNextModel>(result);
                displayTheatre.Add(signUpNextModel);
            }
            return View(displayTheatre);
        }
        public ActionResult DisplayUser()
        {
            IEnumerable<UserAccount> user = UserRepository.DisplayUser();
            List<SignUpModel> displayUser = new List<SignUpModel>();
            foreach (var result in user)
            {
                SignUpModel signUpModel = AutoMapper.Mapper.Map<UserAccount, SignUpModel>(result);
                displayUser.Add(signUpModel);
            }
            return View(displayUser);
        }
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            UserAccount user = UserRepository.GetUserById(id);
            UserRepository.DeleteUser(user);
            return RedirectToAction("DisplayUser");
        }
        [HttpGet]
        public ActionResult AcceptTheatre(int id)
        {
            Theatre theatre = TheatreRepository.GetTheatreById(id);
            UserRepository.AcceptRequest(theatre);
            return RedirectToAction("DisplayTheatre");
        }
        [HttpGet]
        public ActionResult DeleteTheatre(int id)
        {
            Theatre theatre = TheatreRepository.GetTheatreById(id);
            TheatreRepository.DeleteTheatre(theatre);
            return RedirectToAction("DisplayTheatre");
        }
    }
}