using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Models;

namespace Yggdrasil.Services
{
    public class LoginService
    {
        private User _loggedInUser;

        public void UserLogin(User user)
        {
            _loggedInUser = user;
        }

        public void UserLogout()
        {
            _loggedInUser = null;
        }

        public User GetLoggedInUser()
        {
            return _loggedInUser;
        }
    }
}
