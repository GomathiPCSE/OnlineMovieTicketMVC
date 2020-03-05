using MovieTicketBooking.DAL;
using MovieTicketBooking.Entity;
using MovieTicketBooking.Models;
using System.Collections.Generic;
using System.Web.Mvc;
namespace MovieTicketBooking.Controllers
{
    [Authorize(Roles ="Admin")]
    public class TheatreController : Controller
    {
        // GET: Theatre
        public ActionResult DisplayTheatre()
        {
            IEnumerable<Theatre> theatre = TheatreRepository.DisplayTheatre();
            return View(theatre);
        }
        [HttpGet]
        public ActionResult AddTheatre()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTheatre(TheatreModel model)
        {
            if (ModelState.IsValid)
            {
                var theatre = AutoMapper.Mapper.Map<TheatreModel, Theatre>(model);
                TheatreRepository.AddTheatre(theatre);
                return RedirectToAction("DisplayTheatre");
            }
            return View();
        }
        [HttpGet]
        public ActionResult EditTheatre(int id)
        {
            Theatre theatre = TheatreRepository.GetTheatreById(id);
            return View(theatre);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTheatre(TheatreModel model)
        {
            if (ModelState.IsValid)
            {
                var theatre = AutoMapper.Mapper.Map<TheatreModel, Theatre>(model);
                TheatreRepository.UpdateTheatre(theatre);
                return RedirectToAction("DisplayTheatre");
            }
            return View();
        }
        [HttpGet]
        public ActionResult DeleteTheatre(int id)
        {
            Theatre theatre = TheatreRepository.GetTheatreById(id);
            TheatreRepository.DeleteTheatre(theatre);
            return RedirectToAction("DisplayTheatre");
            //return View(theatre);
        }
        //[HttpPost]
        //public ActionResult DeleteTheatre(TheatreModel model)
        //{
        //    Theatre theatre = new Theatre();
        //    theatre.TheatreId = model.TheatreId;
        //    TheatreRepository.DeleteTheatre(theatre);
        //    return RedirectToAction("DisplayTheatre");
        //}
    }
}