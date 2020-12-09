using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public List<OrderItem> Wares { get; set; }   

        private ShoppingCartService CartService { get; set; }
        private IOrderRepository Repository { get; set; }
        public LoginService Login { get; set; }
        public User User1 { get; set; } 

        public CheckOutModel(IOrderRepository repo, ShoppingCartService itemsInCart, LoginService log)
        {
            CartService = itemsInCart;
            Repository = repo;
            Login = log;
            User1 = Login.GetLoggedInUser();
        }
        public IActionResult OnGet()
        {
            if (User1 == null)
            {
                return RedirectToPage("/Users/Login");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
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
