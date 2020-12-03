using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yggdrasil.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Ware> OrderedWares { get; set; }
        public DateTime DateTimeFrom { get; set; }
        public DateTime DateTimeTo { get; set; }
        public string Address { get; set; }
        public double TotalPrice { get; set; }
        public string Comment { get; set; }
        public bool Done { get; set; }
        public User User { get; set; }

        public Order()
        {
            Done = false;
        }
}
}
