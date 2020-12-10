using System.Collections.Generic;
using Yggdrasil.Models;

namespace Yggdrasil.Interfaces
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();
        public void AddUser(User user);
        public void RemoveUser(int id);
        public void EditUser(int id, User user);
        public User GetUser(int id);
        public double GetRatingForUser(User user);
    }
}
