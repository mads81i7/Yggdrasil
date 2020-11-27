using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yggdrasil.Models
{
    public enum WareType {Dairy, Canned, Fresh, Dry, Drink}
    public class Ware
    {
        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string description { get; set; }
        public WareType Type { get; set; }
        public bool IsVegan { get; set; }
        public bool IsOrganic { get; set; }
    }
}
