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
            modelBuilder.Entity<Movie>()
                .MapToStoredProcedures();
        }
        public DbSet<UserAccount> Users { get; set; }
        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<BookingTable> BookingTables { get; set; }
    }
}
