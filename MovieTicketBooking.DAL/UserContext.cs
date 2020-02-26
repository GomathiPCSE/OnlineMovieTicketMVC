using System.Data.Entity;
namespace MovieTicketBooking.Entity
{
    public class UserContext : DbContext
    {
        public UserContext() : base("UserContext")
        {

        }
        public DbSet<UserEntity> UserEntity { get; set; }
    }
}
