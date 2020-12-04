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
    public class AcceptRequestModel : PageModel
    {
        public List<Order> AcceptedOrders { get; set; }
        private IOrderRepository repo;

        [BindProperty(SupportsGet = true)]
        private Order Order { get; set; }

        public User User { get; set; }

        public AcceptRequestModel(IOrderRepository repository, LoginService log)
        {
            repo = repository;
            User = log.GetLoggedInUser();
            AcceptedOrders = User.UserOrders;
        }
        public void OnGet(int id)
        {
            Order = repo.GetOrder(id);
            Order.Done = true;
            AcceptedOrders.Add(Order);
        }
    }
}
