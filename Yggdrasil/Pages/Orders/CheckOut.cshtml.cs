using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Orders
{
    public class CheckOutModel : PageModel
    {
        [BindProperty]
        public Order Order { get; set; }

        private readonly ShoppingCartService _cartService;
        private readonly IOrderRepository _orderRepository;
        private readonly LoginService _login;

        public CheckOutModel(IOrderRepository orderRepository, ShoppingCartService cartService, LoginService login)
        {
            _cartService = cartService;
            _orderRepository = orderRepository;
            _login = login;
        }

        public IActionResult OnGet()
        {
            if (_login.GetLoggedInUser() == null)
                return RedirectToPage("/Users/Login");

            return Page();
        }

        public IActionResult OnPost()
        {
            Order.OrderedWareIDs = _cartService.GetOrderedWares();
            Order.CustomerID = _login.GetLoggedInUser().ID;
            _orderRepository.AddOrder(Order);
            _cartService.GetOrderedWares().Clear();
            return RedirectToPage("/Requests/RequestIndex");
        }
    }
}
