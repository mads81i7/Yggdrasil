using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Services
{
    public class JsonOrderRepository : IOrderRepository
    {
        string JsonFileName = @"Data\JsonOrderRepository.json";

        public List<Order> AllOrders()
        {
            return JsonFileReader.ReadJsonOrder(JsonFileName);
        }

        public List<Order> FilterOrders(string criteria)
        {
            List<Order> orders = AllOrders();
            if (criteria == "" || criteria == null)
                return orders;
            List<Order> emptyList = new List<Order>();
            string lCriteria = criteria.ToLower();
            foreach (Order o in (AllOrders()))
            {
                string lName = o.User.FullName.ToLower(); 
                string lCity = o.User.City.ToLower();
                string lAddress = o.Address.ToLower();
                string lPostalCode = "" + o.User.PostalCode;

                if (lName.Contains(lCriteria) || lCity.Contains(lCriteria) || lAddress.Contains(lCriteria) || lPostalCode.Contains(lCriteria))
                    emptyList.Add(o);
            }

            return emptyList;
        }

        public void AddOrder(Order or)
        {
            List<int> ids = new List<int>();
            List<Order> orders = AllOrders().ToList();
            foreach (Order o in orders)
            {
                ids.Add(o.Id);
            }
            or.Id = ids.Max() + 1;
            orders.Add(or);
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

        public void EditOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Order order)
        {
            List<Order> orders = AllOrders().ToList();

            orders.Remove(order);
            JsonFileWriter.WriteToJsonOrder(orders, JsonFileName);
        }
    }
}
