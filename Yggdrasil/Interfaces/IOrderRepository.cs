using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Models;

namespace Yggdrasil.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> AllOrders();
        //List<Order> FilterOrders(string criteria);
        void AddOrder(Order or);
        Order GetOrder(int id);
        void EditOrder(int id, Order order);
        void DeleteOrder(Order order);
    }
}
