﻿using MovieTicketBooking.Entity;
using MovieTicketBooking.DAL;
using System.Collections.Generic;
namespace MovieTicketBooking.BL
{
    public interface IMovieBl
    {
        void AddMovie(List<Movie> movie);
        Movie GetMovieById(int id);
        void DeleteMovie(Movie movie);
        void UpdateMovie(Movie movie);
        IEnumerable<Movie> GetMovie(int id);
        IEnumerable<Movie> DisplayMovie();
    }
    public class MovieBl : IMovieBl
    {
        IMovieRepository movieRepository;
        public MovieBl()
        {
            movieRepository = new MovieRepository();
        }
        public void AddMovie(List<Movie> movie)
        {
            movieRepository.AddMovie(movie);
        }
        public Movie GetMovieById(int id)
        {
            Movie movie= movieRepository.GetMovieById(id);
            return movie;
        }
        public void DeleteMovie(Movie movie)
        {
            movieRepository.DeleteMovie(movie);
        }
        public void UpdateMovie(Movie movie)
        {
            movieRepository.UpdateMovie(movie);
        }
        public IEnumerable<Movie> GetMovie(int id)
        {
            IEnumerable<Movie> movie = movieRepository.GetMovie(id);
            return movie;
        }
        public IEnumerable<Movie> DisplayMovie()
        {
            IEnumerable<Movie> movie = movieRepository.DisplayMovie();
            List<Movie> displayMovie = new List<Movie>();
            foreach (var result in movie)
            //{
            //    if (displayMovie.Equals(result))
            //    { }
            //    else
                displayMovie.Add(result);
            //}
            return displayMovie;
        }
    }
}
