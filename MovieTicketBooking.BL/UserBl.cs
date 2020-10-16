using MovieTicketBooking.DAL;
using MovieTicketBooking.Entity;
using System.Collections.Generic;

namespace MovieTicketBooking.BL
{
    public interface IUserBl
    {
        void SignUp(UserAccount user);
        int GetUserId(string mailId);
        void SignUpNext(Theatre theatre);
        UserAccount ValidateLogin(UserAccount user);
        IEnumerable<UserAccount> DisplayUser();
        UserAccount GetUserById(int id);
        void DeleteUser(UserAccount user);
    }
    public class UserBl : IUserBl
    {
        IUserRepository userRepository;
        ITheatreBl theatreBl;
        public UserBl()
        {
            userRepository = new UserRepository();
            theatreBl = new TheatreBl();
        }
        public void SignUp(UserAccount user)
        {
            userRepository.SignUp(user);
        }
        public int GetUserId(string mailId)
        {
            int id=userRepository.GetUserId(mailId);
            return id;
        }
        public void SignUpNext(Theatre theatre)
        {
            userRepository.SignUpNext(theatre);
        }
        public UserAccount ValidateLogin(UserAccount user)
        {
            UserAccount userEntity= userRepository.ValidateLogin(user);
            if(userEntity!=null&&userEntity.Role=="Theatre Manager")
            {
                if (theatreBl.GetStatus(userEntity.UserId) == "Accept")
                {
                    return userEntity;
                }
                else 
                    return null;
            }
            else
            return userEntity;
        }
        public IEnumerable<UserAccount> DisplayUser()
        {
            IEnumerable<UserAccount> user= userRepository.DisplayUser();
            return user;
        }
        public UserAccount GetUserById(int id)
        {
            UserAccount user= userRepository.GetUserById(id);
            return user;
        }
        public void DeleteUser(UserAccount user)
        {
            userRepository.DeleteUser(user);
        }
    }
}
