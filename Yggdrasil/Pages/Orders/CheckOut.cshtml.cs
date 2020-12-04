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

        public List<Ware> Wares { get; set; }   

        public ShoppingCartService CartService { get; set; }
        public IOrderRepository Repository { get; set; }
        public LoginService LogIn { get; set; }
        public User User1 { get; set; } 

        public CheckOutModel(IOrderRepository repo, ShoppingCartService itemsInCart, LoginService log)
        {
            CartService = itemsInCart;
            Repository = repo;
            LogIn = log;
            User1 = LogIn.GetLoggedInUser();
        }
        public IActionResult OnGet()
        {
            if (User1 == null)
            {
                return RedirectToPage("/Login/LoginIndex");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            Order.OrderedWares = CartService.GetOrderedWares();
            Order.TotalPrice = CartService.CalculateTotalPrice();
            Order.User = LogIn.GetLoggedInUser();
            Repository.AddOrder(Order);
            CartService.GetOrderedWares().Clear();
            return RedirectToPage("/Requests/RequestIndex");
        }
    }
}
