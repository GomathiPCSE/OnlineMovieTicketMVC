using MovieTicketBooking.DAL;
using MovieTicketBooking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketBooking.BL
{
    public interface ITheatreBl
    {
        IEnumerable<Theatre> DisplayTheatre();
        Theatre GetTheatreById(int id);
        void AcceptRequest(Theatre theatre);
        void DeleteTheatre(Theatre theatre);
        Theatre GetData(int id);
        string GetStatus(int userId);
        void UpdateTheatre(Theatre theatre);
    }
    public class TheatreBl : ITheatreBl
    {
        ITheatreRepository theatreRepository;
        public TheatreBl()
        {
            theatreRepository = new TheatreRepository();

        }
        public IEnumerable<Theatre> DisplayTheatre()
        {
            IEnumerable<Theatre> theatreDetails = theatreRepository.DisplayTheatre();
            return theatreDetails;
        }
        public Theatre GetTheatreById(int id)
        {
            Theatre theatre = theatreRepository.GetTheatreById(id);
            return theatre;
        }
        public void AcceptRequest(Theatre theatre)
        {
            theatreRepository.AcceptRequest(theatre);
        }
        public void DeleteTheatre(Theatre theatre)
        {
            theatreRepository.AcceptRequest(theatre);
        }
        public Theatre GetData(int id)
        {
            Theatre theatre = theatreRepository.GetData(id);
            return theatre;
        }
        public string GetStatus(int userId)
        {
            string status = theatreRepository.GetStatus(userId);
            return status;
        }
        public void UpdateTheatre(Theatre theatre)
        {
            theatreRepository.UpdateTheatre(theatre);
        }
    }
}
