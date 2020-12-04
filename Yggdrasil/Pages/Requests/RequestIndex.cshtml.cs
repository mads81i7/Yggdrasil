using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Requests
{
    public class RequestIndexModel : PageModel
    {
        private IOrderRepository repo;
        public List<Order> Orders { get; set; }
        public User User1 { get; set; }

        public RequestIndexModel(IOrderRepository repository, LoginService log)
        {
            repo = repository;
        }

        public void OnGet()
        {
            Orders = repo.AllOrders();
        }
    }
}
