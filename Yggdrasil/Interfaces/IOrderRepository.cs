using System.Collections.Generic;
using Yggdrasil.Models;

namespace Yggdrasil.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> AllOrders();
        List<Order> FilterOrders(string criteria);
        void AddOrder(Order or);
        Order GetOrder(int id);
        void EditOrder(int id, Order order);
        void DeleteOrder(Order order);
        public double GetRatingForUser(User user);
    }
}
