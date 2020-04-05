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
    }
    public class MovieRepository : IMovieRepository
    {
        public void AddMovie(List<Movie> movie)
        {
            //using (UserContext userContext = new UserContext())
            //{
            //    SqlParameter movieName = new SqlParameter("@MovieName", movie.MovieName);
            //    SqlParameter movieHour = new SqlParameter("@MovieHour", movie.MovieHour);
            //    SqlParameter movieType = new SqlParameter("@MovieType", movie.MovieType);
            //    SqlParameter movieDescription = new SqlParameter("@MovieDescription", movie.MovieDescription);
            //    SqlParameter theatreId = new SqlParameter("@TheatreId", movie.TheatreId);
            //    int result= userContext.Database.ExecuteSqlCommand("Movie_Insert @MovieName,@MovieHour,@MovieType,@MovieDescription,@TheatreId", movieName, movieHour, movieType, movieDescription,theatreId);
            //    userContext.SaveChanges();
            //}
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
                SqlParameter movieHour = new SqlParameter("@MovieHour", movie.MovieHour);
                SqlParameter movieType = new SqlParameter("@MovieType", movie.MovieType);
                SqlParameter movieDescription = new SqlParameter("@MovieDescription", movie.MovieDescription);
                SqlParameter theatreId = new SqlParameter("@TheatreId", movie.TheatreId);
                userContext.Database.ExecuteSqlCommand("Movie_Update @MovieId,@MovieName,@MovieHour,@MovieType,@MovieDescription,@TheatreId", movieId, movieName, movieHour, movieType, movieDescription,theatreId);
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
                return context.Movies.Include("Theatres").Where(id => id.TheatreId == theatreId).ToList();
            }
        }
    }
}
