using MovieTicketBooking.BL;
using MovieTicketBooking.Entity;
using MovieTicketBooking.Models;
using System.Collections.Generic;
using System.Web.Mvc;
namespace MovieTicketBooking.Controllers
{
    public class TheatreManagerController : Controller
    {
    //    ITheatreBl theatreBl;
    //    IMovieBl movieBl;
    //    public TheatreManagerController()
    //    {
    //        theatreBl = new TheatreBl();
    //        movieBl = new MovieBl();
    //    }
    //    // GET: TheatreManager
    //    [Authorize(Roles ="Theatre Manager")]
    //    public ActionResult ViewTheatre()
    //    {
    //        int id = (int)Session["UserId"];
    //        Theatre theatreEntity = theatreBl.GetData(id);
    //        SignUpNextModel theatre = AutoMapper.Mapper.Map<Theatre, SignUpNextModel>(theatreEntity);
    //        ViewData["Theatre"] = theatre;
    //        return View("theatre");
    //    }
    //    //public ActionResult AddData()
    //    //{
    //    //    int id = (int)Session["UserId"];
    //    //    Theatre theatreEntity = theatreBl.GetData(id);
    //    //    var theatre = AutoMapper.Mapper.Map<Theatre, SignUpNextModel>(theatreEntity);
    //    //    ViewData["Theatre"] = theatre;
    //    //    TempData["TheatreId"] = theatre.TheatreId;
    //    //    return View();
    //    //}
    //    public ActionResult MovieIndex()
    //    {
    //        int id = (int)TempData["TheatreId"];
    //        Movie movie = movieBl.DisplayMovie(id);
    //        if (movie != null)
    //        {
    //            var item = AutoMapper.Mapper.Map<Movie, MovieModel>(movie);
    //            ViewData["Movie"] = item;
    //        }
    //        TempData["TheatreId"] = id;
    //        return View();
    //    }
    //    public ActionResult AddMovie()
    //    {
    //        return View();
    //    }
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult AddMovie(MovieModel movie)
    //    {
    //        if (ModelState.IsValid)                         //validation checking
    //        {
    //            movie.TheatreId = (int)TempData["TheatreId"];
    //            var movieEntity = AutoMapper.Mapper.Map<MovieModel, Movie>(movie); //using Auto Mapper
    //            //movieBl.AddMovie(movieEntity);
    //        }
    //        return RedirectToAction("MovieIndex","TheatreManager");
    //    }
    //    [HttpGet]
    //    public ActionResult UpdateMovie(int id)
    //    {
    //        Movie movie = movieBl.GetMovieById(id);
    //        MovieModel movieModel = AutoMapper.Mapper.Map<Movie, MovieModel>(movie);
    //        return View(movieModel);
    //    }
    //    [HttpPost]
    //    public ActionResult UpdateMovie(MovieModel movie)
    //    {
    //        Movie movieEntity = new Movie();
    //        if (ModelState.IsValid)
    //        {
    //            movieEntity = AutoMapper.Mapper.Map<MovieModel, Movie>(movie);
    //            movieBl.UpdateMovie(movieEntity);
    //            return RedirectToAction("MovieIndex");
    //        }
    //        return View();
    //    }
    //    //public ActionResult DisplayMovie()
    //    //{
    //    //    int id = (int)TempData["TheatreId"];
    //    //    Movie movie = MovieBl.DisplayMovie(id);
    //    //    var item = AutoMapper.Mapper.Map<Movie, MovieModel>(movie);
    //    //    ViewData["Movie"] = item;
    //    //    return View();
    //    //}
    //    public ActionResult DeleteMovie(int id)
    //    {
    //        Movie movie = movieBl.GetMovieById(id);
    //        movieBl.DeleteMovie(movie);
    //        return RedirectToAction("MovieIndex");
    //    }
    }
}