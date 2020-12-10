using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Yggdrasil.Models
{
    public class Order
    {
        public int ID { get; set; }
        public List<int> OrderedWareIDs { get; set; }
        public DateTime DateTimeWish { get; set; }
        public string AltAddress { get; set; }
        public string Comment { get; set; }
        public bool Done { get; set; } = false;
        [BindProperty, Range(1,5)]
        public int Rating { get; set; }
        public int CustomerID { get; set; }
        public int CourierID { get; set; }
    }
}
