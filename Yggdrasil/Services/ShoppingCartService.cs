using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Yggdrasil.Models;

namespace Yggdrasil.Services
{
    public class ShoppingCartService
    {
        private List<OrderItem> _waresInCart;

        public ShoppingCartService()
        {
            _waresInCart = new List<OrderItem>();
        }

        //public void AddWare(Ware ware)
        //{
        //    _waresInCart.Add(ware);
        //}

        public void AddWare(Ware ware)
        {
            OrderItem oItem = FindOrderItem(ware.Id);
            if (oItem == null)
            {
                OrderItem orderItem = new OrderItem(ware, 1);
                _waresInCart.Add(orderItem);
            }
            else
            {
                UpdateOrderItem(ware.Id);
            }
        }

        private void UpdateOrderItem(int id)
        {
            foreach (var oI in _waresInCart)
            {
                if (oI.Ware.Id == id)
                    oI.Amount++;
            }
        }

        public OrderItem FindOrderItem(int id)
        {
            foreach (var oI in _waresInCart)
            {
                if (oI.Ware.Id == id)
                {
                    return oI;
                }
            }

            return null;
        }

        public void DeleteWare(int id)
        {
            foreach (OrderItem w in _waresInCart)
            {
                if (w.Ware.Id == id)
                {
                    if (w.Amount <= 1)
                    {
                        _waresInCart.Remove(w);
                    }
                    if(w.Amount > 1)
                    {
                        w.Amount--;
                    }
                    break;
                }
            }
        }

        public double CalculateTotalPrice()
        {
            double totalPrice = 0;
            foreach (OrderItem w in _waresInCart)
            {
                totalPrice = totalPrice + w.Ware.Price * w.Amount;
            }

            return totalPrice;
        }

        public List<OrderItem> GetOrderedWares()
        {
            return _waresInCart;
        }

        public int GetFullCount()
        {
            int fullCount = 0;
            foreach (var c in _waresInCart)
            {
                fullCount = fullCount + c.Amount;
            }

            return fullCount;
        }

        //private int Amount { get; set; }
        //public int CalculateAmount(int id)
        //{
        //    Amount = 0;
        //    foreach (var w in _waresInCart)
        //    {
        //        if (w.Id == id)
        //            Amount++;
        //    }

        //    return Amount;
        //}
        //private List<Ware> _itemsWritten = new List<Ware>();
        //public bool AlreadyWritten(Ware ware)
        //{
        //    _itemsWritten.Add(ware);
        //    if (_itemsWritten.Contains(ware))
        //    {
        //        return true;
        //    }
        //    if(!_itemsWritten.Contains(ware))
        //    {
        //        return false;
        //    }

        //}
    }
}
