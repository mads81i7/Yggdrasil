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
        public Dictionary<int, Order> acceptedOrders { get; set; }
        private IOrderRepository repo;
        //private LoginService loginService;

        [BindProperty(SupportsGet = true)]
        private Order Order { get; set; }

        //public User User { get; set; }

        public AcceptRequestModel(IOrderRepository repository, LoginService log)
        {
            repo = repository;
            //loginService = log;
            //User = loginService.GetLoggedInUser();
            //acceptedOrders = User.UserOrders;
        }
        public void OnGet(int id)
        {
            Order = repo.GetOrder(id);
            acceptedOrders.Add(Order.Id, Order);
            Order.Done = true;
        }
    }
}
