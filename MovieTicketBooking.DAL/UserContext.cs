using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
