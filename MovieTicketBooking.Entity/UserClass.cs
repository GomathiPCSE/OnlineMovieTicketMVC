namespace MovieTicketBooking.Entity
{
    public enum Role
    {
        User,
        TheatreManager
    }
    public class UserClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long MobileNumber { get; set; }
        public string MailId { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
        public Role UserRole { get; set; }
        
    }
}
