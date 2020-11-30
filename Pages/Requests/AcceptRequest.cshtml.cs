using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.Requests
{
    public class AcceptRequestModel : PageModel
    {
        public Dictionary<int, Order> acceptedOrders { get; set; }
        [BindProperty(SupportsGet = true)]
        private Order Order { get; set; }
        public void OnGet()
        {
            acceptedOrders.Add(Order.Id, Order);
            Order.Done = true;
        }
    }
}
