using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Services
{
    public class FakeUserRepository : IUserRepository
    {
        private List<User> users { get; }

        public FakeUserRepository()
        {
            users = new List<User>();
            users.Add(new User() { Id = 0, ForeName = "Hanne", SurName = "Andersen", AddressLine1 = "Malmögade 72", City = "Helsingør", PostalCode = 3000, PhoneNo = "+4500332288", EMail = "hannevandkande@danmark.dk"});
        }

        public string GetUserForeName(int id)
        {
            foreach (User user in users)
            {
                if (user.Id == id)
                    return user.ForeName;
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            return users;
        }
    }
}
