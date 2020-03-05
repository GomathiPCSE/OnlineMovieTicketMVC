using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.Models
{
    public class SignInModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}