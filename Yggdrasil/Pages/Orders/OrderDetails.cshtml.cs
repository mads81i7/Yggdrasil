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
    public class OrderDetailsModel : PageModel
    {
        public Order Order { get; set; }
        public IOrderRepository Repo { get; set; }  

        public OrderDetailsModel(IOrderRepository repository)
        {
            Repo = repository;
        }
        public void OnGet(int id)
        {
            Order = Repo.GetOrder(id);
        }
    }
}
