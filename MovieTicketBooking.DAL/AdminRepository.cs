using MovieTicketBooking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieTicketBooking.DAL
{
    public class AdminRepository
    {
        public static bool ValidateLogin(AdminAccount admin)
        {
            UserContext userContext = new UserContext();
            List<AdminAccount> userList = userContext.AdminEntity.ToList();
            foreach (var item in userList)
            {
                if (admin.UserName == item.UserName && admin.Password == item.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
