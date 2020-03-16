using System.Data.Entity;
namespace MovieTicketBooking.Entity
{
    public class UserContext : DbContext
    {
        public UserContext() : base("UserContext")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>()
                .MapToStoredProcedures();
        }
        public DbSet<UserAccount> UserEntity { get; set; }
        public DbSet<Theatre> TheatreEntity { get; set; }
    }
}
