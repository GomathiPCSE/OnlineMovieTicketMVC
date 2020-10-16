using MovieTicketBooking.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace MovieTicketBooking.DAL
{
    public interface ITheatreRepository
    {
        IEnumerable<Theatre> DisplayTheatre();
        Theatre DisplayTheatre(int theatreId);
        void AddTheatre(Theatre theatre);
        Theatre GetTheatreById(int theatreId);
        void AcceptRequest(Theatre theatre);
        void DeleteTheatre(Theatre theatre);
        string GetStatus(int userId);
        Theatre GetData(int id);
        void UpdateTheatre(Theatre theatre);
    }
    public class TheatreRepository : ITheatreRepository
    {
        public IEnumerable<Theatre> DisplayTheatre()     //Method for display the theatre details
        {
            using (UserContext userContext = new UserContext())     //creating a connection
            {
                List<Theatre> theatreDetails = userContext.Theatres.ToList();
                return theatreDetails;
            }
        }
        public void AddTheatre(Theatre theatre)      //Method for adding the theatre details
        {
            using (UserContext theatreContext = new UserContext())
            {
                theatreContext.Theatres.Add(theatre);  //Add the theatre details to database
                theatreContext.SaveChanges();               //commit the save changes
            }
        }
        public Theatre GetTheatreById(int theatreId)     //Method for get theatre id
        {
            using (UserContext theatreContext = new UserContext())
            {
                Theatre theatre = theatreContext.Theatres.Where(model => model.TheatreId == theatreId).SingleOrDefault();
                return theatre;
            }
        }

        public void AcceptRequest(Theatre theatre)   //Method for accept theatre request
        {
            theatre.Status = "Accept";
            using (UserContext userContext = new UserContext())
            {
                userContext.Entry(theatre).State = EntityState.Modified;
                userContext.SaveChanges();      //Commit changes
            }
        }
        public void DeleteTheatre(Theatre theatre)   //Method for delete theatre details
        {
            using (UserContext userContext = new UserContext())
            {
                Theatre theatreEntity = userContext.Theatres.Where(model => model.TheatreId == theatre.TheatreId).SingleOrDefault();
                userContext.Theatres.Attach(theatreEntity);
                userContext.Theatres.Remove(theatreEntity);
                userContext.SaveChanges();
            }
        }
        public string GetStatus(int userId)      //method for getting the theatre status
        {
            using (UserContext userContext = new UserContext())
            {
                Theatre theatre = userContext.Theatres.Where(model => model.UserId == userId).SingleOrDefault();
                return theatre.Status;
            }
        }
        public Theatre GetData(int id)
        {
            using (UserContext theatreContext = new UserContext())
            {
                Theatre theatre = theatreContext.Theatres.Where(model => model.UserId == id).SingleOrDefault();
                return theatre;
            }
        }
        public void UpdateTheatre(Theatre theatre)
        {
            using (UserContext context = new UserContext())
            {
                context.Entry(theatre).State = EntityState.Modified;          //Updating theatre details in database
                context.SaveChanges();
            }
        }
        public Theatre DisplayTheatre(int theatreId)
        {
            using (UserContext userContext = new UserContext())
            {
                Theatre theatre = userContext.Theatres.Where(model => model.TheatreId == theatreId).SingleOrDefault();
                return theatre;
            }
        }
    }
}
