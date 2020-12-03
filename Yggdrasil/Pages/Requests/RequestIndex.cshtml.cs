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
    public class RequestIndexModel : PageModel
    {
        private IOrderRepository repo;
        public Dictionary<int, Order> Orders { get; set; }

        public RequestIndexModel(IOrderRepository repository)
        {
            repo = repository;
        }

        public void OnGet()
        {
            Orders = repo.AllOrders();
        }
    }
}
