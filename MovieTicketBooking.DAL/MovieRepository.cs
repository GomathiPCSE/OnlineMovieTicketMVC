using MovieTicketBooking.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace MovieTicketBooking.DAL
{
    public interface IMovieRepository
    {
        void AddMovie(List<Movie> movie);
        Movie GetMovieById(int movieId);
        void UpdateMovie(Movie movie);
        void DeleteMovie(Movie movie);
        IEnumerable<Movie> GetMovie(int id);
        IEnumerable<Movie> DisplayMovie();
    }
    public class MovieRepository : IMovieRepository
    {
        public void AddMovie(List<Movie> movie)
        {
            using (UserContext context = new UserContext())
            {
                context.Movies.AddRange(movie);
                context.SaveChanges();
            }
        }
        public Movie GetMovieById(int movieId)
        {
            using(UserContext userContext=new UserContext())
            {
                Movie movie = new Movie();
                movie = userContext.Movies.Find(movieId);
                return movie;
            }
        }
        public void UpdateMovie(Movie movie)
        {
            using(UserContext userContext=new UserContext())
            {
                SqlParameter movieId = new SqlParameter("@MovieId", movie.MovieId);
                SqlParameter movieName = new SqlParameter("@MovieName", movie.MovieName);
                SqlParameter movieType = new SqlParameter("@MovieType", movie.MovieType);
                SqlParameter language = new SqlParameter("@Language", movie.Language);
                SqlParameter certificate = new SqlParameter("@Certificate", movie.Certificate);
                SqlParameter movieHour = new SqlParameter("@MovieHour", movie.MovieHour);
                SqlParameter releaseDate = new SqlParameter("@ReleaseDate", movie.ReleaseDate);
                SqlParameter movieDescription = new SqlParameter("@MovieDescription", movie.MovieDescription);
                //SqlParameter imgFile = new SqlParameter("@ImagePath", movie.ImagePath);
                SqlParameter theatreId = new SqlParameter("@TheatreId", movie.TheatreId);
                userContext.Database.ExecuteSqlCommand("Movie_Update @MovieId,@MovieName,@MovieType,@Language,@Certificate,@MovieHour,@ReleaseDate,@MovieDescription,@TheatreId", movieId, movieName, movieType,language,certificate, movieHour, releaseDate, movieDescription,theatreId);
                userContext.SaveChanges();
            }
        }
        public void DeleteMovie(Movie movie)
        {
            using(UserContext userContext=new UserContext())
            {
                SqlParameter movieId = new SqlParameter("@MovieId", movie.MovieId);
                var data = userContext.Database.ExecuteSqlCommand("Movie_Delete @MovieId", movieId);
                userContext.SaveChanges();
            }
        }
        public IEnumerable<Movie> GetMovie(int theatreId)
        {
            using (UserContext context = new UserContext())
            {
                return context.Movies.Include("TheatreDetails").Where(id => id.TheatreId == theatreId).ToList();
            }
        }
        public IEnumerable<Movie> DisplayMovie()
        {
            using (UserContext userContext = new UserContext())
            {
                List<Movie> movieDetails = userContext.Movies.ToList();
                return movieDetails;
            }
        }
    }
}
