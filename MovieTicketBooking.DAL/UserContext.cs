using System.Data.Entity;
namespace MovieTicketBooking.Entity
{
    public class UserContext : DbContext
    {
        public UserContext() : base("UserContext")
        {

        }
        public DbSet<UserAccount> UserEntity { get; set; }
        public DbSet<AdminAccount> AdminEntity { get; set; }
        public DbSet<Theatre> TheatreEntity { get; set; }
    }
}
