using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.Orders
{
    public class OrderCompleteModel : PageModel
    {
        private IOrderRepository repo;
        public Order Order { get; set; }

        public OrderCompleteModel(IOrderRepository repository)
        {
            repo = repository;
        }
        public void OnGet(int id)
        {
            Order = repo.GetOrder(id);
        }
    }
}
