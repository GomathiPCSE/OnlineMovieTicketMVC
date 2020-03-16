using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using MovieTicketBooking.Entity;
namespace MovieTicketBooking.DAL
{
    public class UserRepository
    {
        public static int GetUserId(string mailId)
        {
            using (UserContext userContext = new UserContext())
            {
                return userContext.UserEntity.Where(m => m.MailId == mailId).FirstOrDefault().UserId;
            }
        }
        public static UserAccount ValidateLogin(UserAccount user)
        {
            using (UserContext userContext = new UserContext())
            {
                UserAccount userAccount = userContext.UserEntity.Where(u => u.MailId == user.MailId && u.Password == user.Password).FirstOrDefault();
                return userAccount;
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
        public static void SignUpNext(Theatre theatre)
        {
            using(UserContext userContext=new UserContext())
            {
                userContext.TheatreEntity.Add(theatre);
                userContext.SaveChanges();
            }
        }
        public static IEnumerable<UserAccount> DisplayUser()
        {
            using (UserContext userContext = new UserContext())
            {
                List<UserAccount> userDetails = userContext.UserEntity.ToList();
                return userDetails;
            }
        }
        public static UserAccount GetUserById(int userId)
        {
            using (UserContext userContext = new UserContext())
            {
                UserAccount user = userContext.UserEntity.Where(model => model.UserId == userId).SingleOrDefault();
                return user;
            }
        }
        public static void AcceptRequest(Theatre theatre)
        {
            theatre.Status = "Accept";
            using(UserContext userContext=new UserContext())
            {
                userContext.Entry(theatre).State = EntityState.Modified;
                userContext.SaveChanges();
            }
        }
        public static void DeleteUser(UserAccount user)
        {
            using (UserContext userContext = new UserContext())
            {
                SqlParameter UserId = new SqlParameter("@UserId", user.UserId);
                var data = userContext.Database.ExecuteSqlCommand("UserAccount_Delete @UserId", UserId);
                userContext.SaveChanges();
            }
        }
    }
}
