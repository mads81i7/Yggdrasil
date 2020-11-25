using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Yggdrasil.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ForeName { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int PostalCode { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string EMail { get; set; }
    }
}
