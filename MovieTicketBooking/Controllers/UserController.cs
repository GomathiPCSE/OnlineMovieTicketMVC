using MovieTicketBooking.BL;
using MovieTicketBooking.Entity;
using MovieTicketBooking.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MovieTicketBooking.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        ITheatreBl theatreBl;
        IMovieBl movieB;
        public UserController()
        {
            theatreBl = new TheatreBl();
            movieBl = new MovieBl();
        }
        public ActionResult DisplayTheatre()
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
        public ActionResult ViewMovie(int id)
        {
            IEnumerable<Movie> movie = movieBl.GetMovie(id);
            return View(movie);
        }
        public ActionResult DisplayMovie()
        {
            IEnumerable<Movie> movie = movieBl.DisplayMovie();
            MultipleModel displayMovie = new MultipleModel();
            List<MovieModel> model=new List<MovieModel>();
            List<SignUpNextModel> displayTheatre = new List<SignUpNextModel>();
            foreach (var result in movie)
            {
                MovieModel movieModel = AutoMapper.Mapper.Map<Movie, MovieModel>(result);  //using auto mapper
                model.Add(movieModel);
                Theatre theatre = theatreBl.DisplayTheatre(result.TheatreId);
                SignUpNextModel theatreModel = AutoMapper.Mapper.Map<Theatre, SignUpNextModel>(theatre);
                displayTheatre.Add(theatreModel);
            }
            displayMovie.Movies= model;
            displayMovie.Theatres = displayTheatre;
            return View(displayMovie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookTicket(BookingTableModel booking)
        {
            booking.UserId = (int)Session["UserId"];
            booking.Show = (int)TempData["Show"];
            return RedirectToAction("ViewTheatre", "Theatre");
        }
        [HttpGet]
        public ActionResult BookTicket(int show, int movieId)
        {
            TempData["Show"] = show;
            TempData["movieId"] = movieId;
            return View();
        }



    }
}