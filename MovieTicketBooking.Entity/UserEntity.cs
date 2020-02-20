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
        [DataType(DataType.Text)]
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
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
        [Required]
        public string Gender { get; set; }
        public Role UserRole { get; set; }
        
    }
}
