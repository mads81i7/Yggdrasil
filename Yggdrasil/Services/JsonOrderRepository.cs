using System.Collections.Generic;
using System.Linq;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Services
{
    public class JsonOrderRepository : IOrderRepository
    {
        private readonly IUserRepository _userRepository;

        string JsonFileName = @"Data\JsonOrderRepository.json";

        public JsonOrderRepository(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<Order> AllOrders()
        {
            return JsonFileReader.ReadJsonOrder(JsonFileName);
        }

        public List<Order> FilterOrders(string criteria)
        {
            List<Order> orders = AllOrders();
            if (string.IsNullOrEmpty(criteria))
                return orders;
            List<Order> emptyList = new List<Order>();
            string lCriteria = criteria.ToLower();
            foreach (Order order in (AllOrders()))
            {
                string lName = _userRepository.GetUser(order.CustomerID).FullName.ToLower();
                string lCity = _userRepository.GetUser(order.CustomerID).City.ToLower();
                string lAddress = _userRepository.GetUser(order.CustomerID).AddressLine1.ToLower();
                string lPostalCode = _userRepository.GetUser(order.CustomerID).PostalCode.ToString();

                if (lName.Contains(lCriteria) || lCity.Contains(lCriteria) || lAddress.Contains(lCriteria) || lPostalCode.Contains(lCriteria))
                    emptyList.Add(order);
            }

            return emptyList;
        }

        public void AddOrder(Order order)
        {
            List<int> ids = new List<int>();
            List<Order> orders = AllOrders();
            foreach (Order orderAlt in orders)
            {
                ids.Add(orderAlt.Id);
            }

            if (ids.Count > 0)
                order.Id = ids.Max() + 1;
            else
                order.Id = 0;
            orders.Add(order);
            JsonFileWriter.WriteToJsonOrder(orders, JsonFileName);
        }

        public Order GetOrder(int id)
        {
            foreach (Order order in AllOrders())
            {
                if (order.Id == id)
                    return order;
            }
            return new Order();
        }

        public void EditOrder(int id, Order order)
        {
            List<Order> orders = AllOrders().ToList();
            orders[id] = order;

            JsonFileWriter.WriteToJsonOrder(orders, JsonFileName);
        }

        public void DeleteOrder(Order order)
        {
            List<Order> orders = AllOrders().ToList();

            orders.Remove(order);
            JsonFileWriter.WriteToJsonOrder(orders, JsonFileName);
        }


        public double GetRatingForUser(User user)
        {
            int cummulativeRatings = 0;
            int noOfRatings = 0;

            foreach (Order order in AllOrders())
            {
                if (order.CourierID == user.ID)
                {
                    cummulativeRatings += order.Rating;
                    noOfRatings++;
                }
            }

            if (noOfRatings > 0)
                return (double)cummulativeRatings / (double)noOfRatings;

            return 0.0;
        }
    }
}
