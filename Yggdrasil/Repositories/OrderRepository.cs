using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private Dictionary<int, Order> orders { get; }

        public OrderRepository()
        {
            orders = new Dictionary<int, Order>();
            
        }

        public Dictionary<int, Order> AllOrders()
        {
            return orders;
        }

        public Dictionary<int, Order> FilterOrders()
        {
            throw new NotImplementedException();
        }

        public void AddOrder(Order or)
        {
            List<int> ordersIds = new List<int>();

            foreach (var ord in orders)
            {
                ordersIds.Add(ord.Value.Id);
            }

            if (ordersIds.Count != 0)
            {
                int start = ordersIds.Max();
                or.Id = start + 1;
            }
            else
            {
                or.Id = 1;
            }
            orders.Add(or.Id, or);
        }

        public Order GetOrder(int id)
        {
            foreach (var ord in orders)
            {
                if (ord.Key == id)
                    return ord.Value;
            }
            return new Order();
        }

        public void EditOrder(Order order)
        {
            if (order != null)
                foreach (var o in orders.Values)
                {
                    if (o.Id == order.Id)
                    {
                        o.Address = order.Address;
                        o.TimeWindow = order.TimeWindow;
                        o.TotalPrice = order.TotalPrice;
                        o.Comment = order.Comment;
                    }
                }
        }

        public void DeleteOrder(Order order)
        {
            if (order != null)
                foreach (var o in orders.Values)
                {
                    if (o.Id == order.Id)
                    {
                        orders.Remove(o.Id);
                    }
                }
        }
    }
}
