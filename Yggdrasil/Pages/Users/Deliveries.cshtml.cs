using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Users
{
    public class DeliveriesModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        public DeliveriesModel(IOrderRepository orderRepository, LoginService loginService)
        {
            _orderRepository = orderRepository;

            User = loginService.GetLoggedInUser();
            Orders = _orderRepository.AllOrders();
        }

        public IList<Order> Orders { get; set; }
        public new User User { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
