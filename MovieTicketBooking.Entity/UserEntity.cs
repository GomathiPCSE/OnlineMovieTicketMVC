using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieTicketBooking.Entity
{
    public enum UserRole
    {
        User,
        TheatreManager
    }
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long MobileNumber { get; set; }
        public string MailId { get; set; }
        public string Password { get; set; }
        public UserRole role { get; set; }
    }
}
