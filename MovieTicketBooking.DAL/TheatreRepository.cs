using MovieTicketBooking.Entity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace MovieTicketBooking.DAL
{
    public class TheatreRepository
    {
        public static IEnumerable<Theatre> DisplayTheatre()
        {
            UserContext userContext = new UserContext();
            List<Theatre> theatreDetails = userContext.TheatreEntity.ToList();
            return theatreDetails;
        }
        public static void AddTheatre(Theatre theatre)
        {
            using (UserContext theatreContext = new UserContext())
            {
                theatreContext.TheatreEntity.Add(theatre);
                theatreContext.SaveChanges();
            }
        }
        public static Theatre GetTheatreById(int theatreId)
        {
            using (UserContext theatreContext = new UserContext())
            {
                Theatre theatre = theatreContext.TheatreEntity.Where(model => model.TheatreId == theatreId).SingleOrDefault();
                return theatre;
            }
        }
        public static void UpdateTheatre(Theatre theatre)
        {
            using (UserContext userContext = new UserContext())
            { 
                userContext.Entry(theatre).State = EntityState.Modified;
                userContext.SaveChanges();
            }
        }
        public static void DeleteTheatre(Theatre theatre)
        {
            using (UserContext userContext = new UserContext())
            {
                Theatre theatreEntity = userContext.TheatreEntity.Where(model => model.TheatreId == theatre.TheatreId).SingleOrDefault();
                userContext.TheatreEntity.Attach(theatreEntity);
                userContext.TheatreEntity.Remove(theatreEntity);
                userContext.SaveChanges();
            }
        }
    }
}
