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

        public List<Order> FilterOrders()
        {
            throw new NotImplementedException();
        }

        protected int Id = 10;
        public void AddOrder(Order or)
        {
            List<Order> orders = AllOrders().ToList();
            orders.Add(or);
            or.Id = Id;
            Id++;
            JsonFileWriter.WriteToJsonOrder(orders, JsonFileName);
        }

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public void EditOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
