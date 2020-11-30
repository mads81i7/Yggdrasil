using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yggdrasil.Models
{
    public class Customer : User
    {

        private List<Order> _orderHistory;
        
        public Customer()
        {
            _orderHistory = new List<Order>();
        }
    }
}
