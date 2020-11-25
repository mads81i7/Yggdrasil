using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Models;

namespace Yggdrasil.Interfaces
{
    public interface IUserRepository
    {
        public string GetUserForeName(int id);
        List<User> GetAllUsers();
    }
}
