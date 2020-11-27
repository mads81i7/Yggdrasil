using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Models;

namespace Yggdrasil.Interfaces
{
    public interface IOrderRepository
    {
        Dictionary<int, Order> AllOrders();
        Dictionary<int, Order> FilterOrders();
        void AddOrder(Order or);
        Order GetOrder(int id);
        void EditOrder(Order order);
        void DeleteOrder(Order order);
    }
}
