using System.Collections.Generic;
using System.Linq;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Services
{
    public class JsonUserRepository : IUserRepository
    {
        string JsonFileName = @"Data\JsonUserRepository.json";
        private readonly IOrderRepository _orderRepository;

        public JsonUserRepository(IOrderRepository repository)
        {
            _orderRepository = repository;
        }

        public List<User> GetAllUsers()
        {
            return JsonFileReader.ReadJsonUser(JsonFileName);
        }

        public void AddUser(User user)
        {
            List<User> users = GetAllUsers();
            List<int> userIDs = new List<int>();

            foreach (User userAlt in users)
                userIDs.Add(userAlt.ID);

            if (userIDs.Count != 0)
            {
                int i = userIDs.Max();
                user.ID = i + 1;
            }
            else
                user.ID = 1;

            users.Add(user);
            JsonFileWriter.WriteToJsonUser(users, JsonFileName);
        }

        public void RemoveUser(int id)
        {
            List<User> users = GetAllUsers();
            users[id - 1] = new User();
            users[id - 1].ID = id;

            JsonFileWriter.WriteToJsonUser(users, JsonFileName);
        }

        public void EditUser(int id, User user)
        {
            List<User> users = GetAllUsers().ToList();
            users[id-1] = user;

            JsonFileWriter.WriteToJsonUser(users, JsonFileName);
        }

        public User GetUser(int id)
        {
            foreach (User user in GetAllUsers())
            {
                if (user.ID == id)
                    return user;
            }
            return new User();
        }

        public double GetRatingForUser(User user)
        {
            int cummulativeRatings = 0;
            int noOfRatings = 0;

            foreach (Order order in _orderRepository.AllOrders())
            {
                if (order.CourierID == user.ID)
                {
                    cummulativeRatings += order.Rating;
                    noOfRatings++;
                }
            }

            if (noOfRatings > 0)
                return (double) cummulativeRatings / (double) noOfRatings;

            return 0.0;
        }
    }
}