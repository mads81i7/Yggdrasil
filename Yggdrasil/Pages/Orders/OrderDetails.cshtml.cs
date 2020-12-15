using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Orders
{
    public class OrderDetailsModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly LoginService _loginService;

        public new User User { get; set; }
        public Order Order { get; set; }

        public OrderDetailsModel(IOrderRepository repository, IUserRepository userRepository, LoginService loginService)
        {
            _orderRepository = repository;
            _userRepository = userRepository;
            _loginService = loginService;
        }

        public void OnGet(int id)
        {
            Order = _orderRepository.GetOrder(id);
            User = _userRepository.GetUser(Order.CustomerID);
        }

        public IActionResult OnPostAccept(int id)
        {
            Order = _orderRepository.GetOrder(id);
            User = _userRepository.GetUser(Order.CustomerID);

            Order.CourierID = _loginService.GetLoggedInUser().ID;
            _orderRepository.EditOrder(Order.Id, Order);

            return RedirectToPage("/Users/Deliveries");
        }
    }
}
