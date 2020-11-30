using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Models;

namespace Yggdrasil.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();
        public void AddUser(User user);
        public void RemoveUser(User user);
        public void EditUser(int id, User user);
        public User GetUser(int id);
    }
}
