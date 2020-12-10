using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yggdrasil.Models
{
    public class OrderItem
    {
        public Ware Ware { get; set; }
        public int Amount { get; set; }

        public OrderItem()
        {

        }

        public OrderItem(Ware ware, int amount)
        {
            Ware = ware;
            Amount = amount;
        }

    }
    
}
