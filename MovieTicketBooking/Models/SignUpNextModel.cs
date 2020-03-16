using System.ComponentModel.DataAnnotations;
namespace MovieTicketBooking.Models
{
    public class SignUpNextModel
    {
        public int UserId { get; set; }
        public int TheatreId { get; set; }
        [Required]

        public string TheatreName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int NoOfScreen { get; set; }
        [Required]
        public string Status { get; set; }
    }
}