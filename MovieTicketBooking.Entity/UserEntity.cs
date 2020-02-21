using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.Entity
{
    public enum Role
    {
        User,
        TheatreManager
    }
    public class UserEntity
    {
        [Required]
        [MaxLength(30)]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+(([',.-][a-zA-Z])?[a-zA-Z]*)*$",ErrorMessage ="Enter valid name")]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public long MobileNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string MailId { get; set; }

        [Required]
        [ MaxLength(20)]
        public string Password { get; set; }

        [Required]
        [ MaxLength(20)]
        public string ConfirmPassword { get; set; }

        public string Gender { get; set; }

        [Required]
        public Role UserRole { get; set; }
        
    }
}
