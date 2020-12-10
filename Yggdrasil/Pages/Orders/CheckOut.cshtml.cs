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

        public CheckOutModel(IOrderRepository orderRepository, ShoppingCartService cartService, LoginService login)
        private ShoppingCartService CartService { get; set; }
        private IOrderRepository Repository { get; set; }
        public LoginService Login { get; set; }
        public User User1 { get; set; } 

        public CheckOutModel(IOrderRepository repo, ShoppingCartService itemsInCart, LoginService log)
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
            List<int> orderedWareIDs = new List<int>();
            foreach (Ware ware in _cartService.GetOrderedWares())
            {
                orderedWareIDs.Add(ware.Id);
            }
            Order.OrderedWareIDs = orderedWareIDs;
            Order.CustomerID = _login.GetLoggedInUser().ID;
            _orderRepository.AddOrder(Order);
            _cartService.GetOrderedWares().Clear();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Order.OrderedWares = CartService.GetOrderedWares();
            Order.TotalPrice = CartService.CalculateTotalPrice();
            Order.User = Login.GetLoggedInUser();
            Repository.AddOrder(Order);
            CartService.GetOrderedWares().Clear();
            return RedirectToPage("/Requests/RequestIndex");
        }
    }
}
