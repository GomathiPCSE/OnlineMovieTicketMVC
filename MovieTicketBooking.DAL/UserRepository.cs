using System.Linq;
using MovieTicketBooking.Entity;
namespace MovieTicketBooking.DAL
{
    public class UserRepository
    {
        public static string ValidateLogin(UserAccount user)
        {
            using (UserContext userContext = new UserContext())
            {
                UserAccount userAccount = userContext.UserEntity.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
                return userAccount.Role;
            }
        }
        public static void SignUp(UserAccount user)
        {
            using (UserContext userContext = new UserContext())
            {
                userContext.UserEntity.Add(user);
                userContext.SaveChanges();
            }
        }
    }
}
