using MovieTicketBooking.BL;
using MovieTicketBooking.Entity;
using MovieTicketBooking.Models;
using System.Collections.Generic;
using System.Web.Mvc;
namespace MovieTicketBooking.Controllers
{
    //[Authorize(Roles = "Theatre Manager")]
    public class TheatreController : Controller
    {
        ITheatreBl theatreBl;
        public TheatreController()
        {
            theatreBl = new TheatreBl();
        }
        public ActionResult ViewTheatre()
        {
            int id = (int)Session["UserId"];
            Theatre theatreEntity = theatreBl.GetData(id);
            SignUpNextModel theatre = AutoMapper.Mapper.Map<Theatre, SignUpNextModel>(theatreEntity);
            ViewData["Theatre"] = theatre;
            return View(theatre);
        }   
        [HttpGet]
        public ActionResult UpdateTheatre(int id)
        {
            Theatre theatre = theatreBl.GetTheatreById(id);
            SignUpNextModel theatreModel = AutoMapper.Mapper.Map<Theatre, SignUpNextModel>(theatre);
            return View(theatreModel);
        }
        [HttpPost]
        public ActionResult UpdateTheatre(SignUpNextModel theatre)
        {
            if (ModelState.IsValid)
            {
                Theatre theatreEntity = AutoMapper.Mapper.Map<SignUpNextModel, Theatre>(theatre);
                theatreBl.UpdateTheatre(theatreEntity);
                return RedirectToAction("ViewTheatre");
            }
            return View();
        }
    }
}