using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Users
{
    public class OrdersModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;

        public IList<Order> Orders;
        public new User User;

        [BindProperty]
        public int Rating { get; set; }

        public OrdersModel(IOrderRepository orderRepository, LoginService loginService)
        {
            _orderRepository = orderRepository;

            Orders = _orderRepository.AllOrders();
            User = loginService.GetLoggedInUser();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            Orders[id].Done = true;
            Orders[id].Rating = Rating;

            _orderRepository.EditOrder(id, Orders[id]);
            Rating = 0;

            return Page();
        }
    }
}
