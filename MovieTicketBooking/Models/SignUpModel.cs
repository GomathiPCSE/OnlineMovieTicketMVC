using System.ComponentModel.DataAnnotations;
namespace MovieTicketBooking.Models
{
    public class SignUpModel
    {
        public int UserId { get; set; }
        [Required]
        [RegularExpression("[A-Z][a-z][a-z][a-zA-Z]*", ErrorMessage = "Invalid First Name")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression("[A-Z][a-zA-Z]*", ErrorMessage = "Invalid First Name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([6-9]{1})\)?[-.]?([0-9]{9})$", ErrorMessage = "Invalid Mobile Number")]
        public long MobileNumber { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string MailId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"((?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})", ErrorMessage = "Invalid Password")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm password must be same")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Role { get; set; }
    }
}