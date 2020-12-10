using System.Collections.Generic;
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
        public List<OrderItem> Wares { get; set; }

        public CheckOutModel(IOrderRepository repo, ShoppingCartService itemsInCart, LoginService log)
        {
            _cartService = itemsInCart;
            _orderRepository = repo;
            _login = log;
        }

        public IActionResult OnGet()
        {
            if (_login.GetLoggedInUser() == null)
                return RedirectToPage("/Users/Login");

            return Page();
        }

        public IActionResult OnPost()
        {
            Order.OrderedWares = _cartService.GetOrderedWares();
            Order.TotalPrice = _cartService.CalculateTotalPrice();
            Order.CustomerID = _login.GetLoggedInUser().ID;
            _orderRepository.AddOrder(Order);
            _cartService.GetOrderedWares().Clear();
            return RedirectToPage("/Requests/RequestIndex");
        }
    }
}
