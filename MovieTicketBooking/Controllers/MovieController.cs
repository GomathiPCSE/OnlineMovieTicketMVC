using MovieTicketBooking.BL;
using MovieTicketBooking.Entity;
using MovieTicketBooking.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace MovieTicketBooking.Controllers
{
    //[Authorize(Roles = "Theatre Manager")]
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
        public ActionResult AddMovie(int id, int screen)    
        {
            TempData["Id"] = id;
            TempData["Screen"] = screen;
            return View();
        }
        [HttpPost]
        public ActionResult AddMovie(MovieViewModels movie)
        {
            //if (ModelState.IsValid)
            //{
                List<MovieModel> movieDetails = movie.MovieModels;
                List<Movie> movieList = new List<Movie>();
                foreach (MovieModel item in movieDetails)
                {
                    string fileName = Path.GetFileNameWithoutExtension(item.ImageFile.FileName);
                    string extension = Path.GetExtension(item.ImageFile.FileName);
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    item.ImagePath = "~/Image/"+fileName;
                    Movie movieDetail = AutoMapper.Mapper.Map<MovieModel, Movie>(item);
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    item.ImageFile.SaveAs(fileName);
                    movieList.Add(movieDetail);
                }
                movieBl.AddMovie(movieList);
                return RedirectToAction("ViewTheatre", "Theatre");
            //}
            return View();
        }
        public ActionResult EditMovie(int id)
        {
            Movie movie = movieBl.GetMovieById(id);
            MovieModel movieModel = AutoMapper.Mapper.Map<Movie, MovieModel>(movie);
            return View(movieModel);
        }
        [HttpPost]
        public ActionResult EditMovie(MovieModel movieModel)
        {
            Movie movie = AutoMapper.Mapper.Map<MovieModel, Movie>(movieModel);
            movieBl.UpdateMovie(movie);
            return RedirectToAction("ViewMovie", new { id = movie.TheatreId });
        }
        public ActionResult DeleteMovie(int id)
        {
            Movie movie = movieBl.GetMovieById(id);
            movieBl.DeleteMovie(movie);
            return RedirectToAction("ViewTheatre");
        }
    }
}