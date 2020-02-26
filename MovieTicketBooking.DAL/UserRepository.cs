using System.Collections.Generic;
using System.Linq;
using MovieTicketBooking.Entity;
namespace MovieTicketBooking.DAL
{  
    public class UserRepository
    {
        public static List<UserEntity> GetDetails()
        {
            UserContext userContext = new UserContext();
            return userContext.UserEntity.ToList();
        }
        public static void SignUp(UserEntity user)
        {
            UserContext userContext = new UserContext();
            userContext.UserEntity.Add(user);
            userContext.SaveChanges();
        }
    }
}
