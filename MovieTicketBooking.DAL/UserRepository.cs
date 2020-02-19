using System;
using System.Collections.Generic;
using MovieTicketBooking.Entity;

namespace MovieTicketBooking.DAL
{  
    public class UserRepository
    {
        public static List<UserClass> userDb = new List<UserClass>();
        public static void SignUp(UserClass user)
        {
            userDb.Add(user);
        }
    }
}
