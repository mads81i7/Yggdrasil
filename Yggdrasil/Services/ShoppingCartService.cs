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
        private List<Ware> _waresInCart;

        
        [BindProperty]
        private Ware Ware { get; set; }

        public ShoppingCartService()
        {
            _waresInCart = new List<Ware>();
            Ware = new Ware();
        }

        //public void AddWare(Ware ware)
        //{
        //    _waresInCart.Add(ware);
        //}

        public void AddWare(Ware ware)
        {
            OrderItem aOrderItem = new OrderItem();
            aOrderItem.Ware = ware;
            aOrderItem.Amount = FindNumberOfSame(ware);
            _waresInCart.Add(aOrderItem.Ware);
        }
        public int FindNumberOfSame(Ware ware)
        {
            int i = 0;
            if (_waresInCart.Contains(ware))
            {
                i++;
            }

            return i;
        }

        public void DeleteWare(int id)
        {
            foreach (Ware w in _waresInCart)
            {
                if (w.Id == id)
                {
                    _waresInCart.Remove(w);
                    break;
                }
            }
        }

        public double CalculateTotalPrice()
        {
            double totalPrice = 0;
            foreach (Ware w in _waresInCart)
            {
                totalPrice = totalPrice + w.Price;
            }

            return totalPrice;
        }

        public List<Ware> GetOrderedWares()
        {
            return _waresInCart;
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
