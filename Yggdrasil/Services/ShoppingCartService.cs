using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Models;

namespace Yggdrasil.Services
{
    public class ShoppingCartService
    {
        private List<Ware> _waresInCart;

        public ShoppingCartService()
        {
            _waresInCart = new List<Ware>();
        }

        public void AddWare(Ware ware)
        {
            _waresInCart.Add(ware);
        }
        public void DeleteWare(Ware ware)
        {
            _waresInCart.Remove(ware);
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
    }
}
