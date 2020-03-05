using System.ComponentModel.DataAnnotations;
namespace MovieTicketBooking.Models
{
    public class TheatreModel
    {
        public int TheatreId { get; set; }
        [Required]
        public string TheatreName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int NoOfScreen { get; set; }
    }
}