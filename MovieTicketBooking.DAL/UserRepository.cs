using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using MovieTicketBooking.Entity;
namespace MovieTicketBooking.DAL
{
    public interface IUserRepository
    {
        int GetUserId(string mailId);
        UserAccount ValidateLogin(UserAccount user);
        void SignUp(UserAccount user);
        void SignUpNext(Theatre theatre);
        IEnumerable<UserAccount> DisplayUser();
        UserAccount GetUserById(int userId);
        void DeleteUser(UserAccount user);
    }
    public class UserRepository : IUserRepository
    {
        public int GetUserId(string mailId)      //Method for getting user id
        {
            using (UserContext userContext = new UserContext())     //create the connection using usercontext object
            {
                return userContext.Users.Where(m => m.MailId == mailId).FirstOrDefault().UserId;
            }
        }
        public UserAccount ValidateLogin(UserAccount user)   //Method for validate login
        {
            using (UserContext userContext = new UserContext())
            {
                UserAccount userAccount = userContext.Users.Where(u => u.MailId == user.MailId && u.Password == user.Password).FirstOrDefault();
                return userAccount;
            }
        }
        public void SignUp(UserAccount user)     //Method for Sign up
        {
            using (UserContext userContext = new UserContext())
            {
                userContext.Users.Add(user);
                userContext.SaveChanges();
            }
        }
        public void SignUpNext(Theatre theatre)     //Method for sign up next
        {
            using(UserContext userContext=new UserContext())
            {
                userContext.Theatres.Add(theatre);
                userContext.SaveChanges();
            }
        }
        public IEnumerable<UserAccount> DisplayUser()    //Method for display the user details
        {
            using (UserContext userContext = new UserContext())
            {
                List<UserAccount> userDetails = userContext.Users.ToList();
                return userDetails;
            }
        }
        public UserAccount GetUserById(int userId)       //Method for getting user id
        {
            using (UserContext userContext = new UserContext())
            {
                UserAccount user = userContext.Users.Where(model => model.UserId == userId).SingleOrDefault();
                return user;
            }
        }
        public void DeleteUser(UserAccount user)     //Method for deleting the user details
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
