using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.Users
{
    public class DeliveriesModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;

        public DeliveriesModel(IUserRepository userRepository, IOrderRepository orderRepository)
        {
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }

        public IList<Order> Orders { get; set; }
        public new User User { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            User = _userRepository.GetUser((int)id);
            Orders = _orderRepository.AllOrders();

            if (User == null)
                return NotFound();

            return Page();
        }
    }
}
