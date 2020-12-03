//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Yggdrasil.Interfaces;
//using Yggdrasil.Models;

//namespace Yggdrasil.Services
//{
//    public class OrderRepository : IOrderRepository
//    {
//        private List<Order> orders { get; }

//        public OrderRepository()
//        {
//            orders = new List<Order>();
            
//        }

//        public List<Order> AllOrders()
//        {
//            return orders;
//        }

//        public List<Order> FilterOrders()
//        {
//            throw new NotImplementedException();
//        }

//        public void AddOrder(Order or)
//        {
//            List<int> ordersIds = new List<int>();

//            foreach (var ord in orders)
//            {
//                ordersIds.Add(ord.Id);
//            }

//            if (ordersIds.Count != 0)
//            {
//                int start = ordersIds.Max();
//                or.Id = start + 1;
//            }
//            else
//            {
//                or.Id = 1;
//            }
//            orders.Add(or);
//        }

//        public Order GetOrder(int id)
//        {
//            foreach (var ord in orders)
//            {
//                if (ord.Id == id)
//                    return ord;
//            }
//            return new Order();
//        }

//        public void EditOrder(Order order)
//        {
//            if (order != null)
//                foreach (var o in orders)
//                {
//                    if (o.Id == order.Id)
//                    {
//                        o.Address = order.Address;
//                        o.DateTimeFrom = order.DateTimeFrom;
//                        o.DateTimeTo = order.DateTimeTo;
//                        o.TotalPrice = order.TotalPrice;
//                        o.Comment = order.Comment;
//                    }
//                }
//        }

//        public void DeleteOrder(Order order)
//        {
//            if (order != null)
//                foreach (var o in orders)
//                {
//                    if (o.Id == order.Id)
//                    {
//                        orders.Remove(o);
//                    }
//                }
//        }
//    }
//}
