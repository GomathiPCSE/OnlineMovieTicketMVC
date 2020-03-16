using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.Models
{
    public class SignInModel
    {
        [Required]
        [DisplayName("User Name")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string MailId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}