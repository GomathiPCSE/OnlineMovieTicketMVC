using MovieTicketBooking.BL;
using MovieTicketBooking.Entity;
using MovieTicketBooking.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MovieTicketBooking.Controllers
{
    [Authorize(Roles = "Theatre Manager")]
    public class MovieController : Controller
    {
        IMovieBl movieBl;
        public MovieController()
        {
            movieBl = new MovieBl();
        }
        public ActionResult ViewMovie(int id)
        {
            IEnumerable<Movie> movie = movieBl.GetMovie(id);
            return View(movie);
        }
        [HttpGet]
        public ViewResult AddMovie(int id, int screen)
        {
            TempData["Id"] = id;
            TempData["Screen"] = screen;
            return View();
        }
        [HttpPost]
        public ActionResult AddMovie(MovieViewModels movie)
        {
            if (ModelState.IsValid)
            {
                List<MovieModel> movieDetails = movie.MovieModels;
                List<Movie> movieList = new List<Movie>();
                foreach (MovieModel item in movieDetails)
                {
                    Movie movieDetail = AutoMapper.Mapper.Map<MovieModel, Movie>(item);
                    movieList.Add(movieDetail);
                }
                movieBl.AddMovie(movieList);
                return RedirectToAction("ViewTheatre", "Theatre");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            Movie movie = movieBl.GetMovieById(id);
            MovieModel movieModel = AutoMapper.Mapper.Map<Movie, MovieModel>(movie);
            return View(movieModel);
        }
        [HttpPost]
        public ActionResult Update(MovieModel movieModel)
        {
            Movie movie = AutoMapper.Mapper.Map<MovieModel, Movie>(movieModel);
            movieBl.UpdateMovie(movie);
            return RedirectToAction("ViewMovie", new { id = movie.TheatreId });
        }
        public ActionResult Delete(int id)
        {
            Movie movie = movieBl.GetMovieById(id);
            movieBl.DeleteMovie(movie);
            return RedirectToAction("ViewTheatre");
        }
    }
}