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
        [DataType(DataType.MultilineText)]
        //[RegularExpression("[A-Z][a-z][a-z][a-zA-Z]*", ErrorMessage = "Invalid Address")]
        public string Address { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Enter the Numeric value")]
        public int NoOfScreen { get; set; }
        public string Status { get; set; }
    }
}