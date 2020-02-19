using System.Collections.Generic;
using MovieTicketBooking.Entity;
namespace MovieTicketBooking.DAL
{  
    public class UserRepository
    {
        public static List<UserEntity> userDb = new List<UserEntity>();
        public static void SignUp(UserEntity user)
        {
            userDb.Add(user);
        }
    }
}
