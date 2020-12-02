using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.Requests
{
    public class AcceptRequestModel : PageModel
    {
        public Dictionary<int, Order> acceptedOrders { get; set; }
        private IOrderRepository repo;

        [BindProperty(SupportsGet = true)]
        private Order Order { get; set; }

        public AcceptRequestModel(IOrderRepository repository)
        {
            repo = repository;
            acceptedOrders = new Dictionary<int, Order>();
        }
        public void OnGet(int id)
        {
            Order = repo.GetOrder(id);
            acceptedOrders.Add(Order.Id, Order);
            Order.Done = true;
        }
    }
}
