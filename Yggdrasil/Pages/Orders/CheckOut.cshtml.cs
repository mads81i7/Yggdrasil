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

        public ShoppingCartService CartService { get; set; }
        public IOrderRepository Repository { get; set; }

        public CheckOutModel(IOrderRepository repo, ShoppingCartService itemsInCart)
        {
            CartService = itemsInCart;
            Repository = repo;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Order.OrderedWares = CartService.GetOrderedWares();
            Order.TotalPrice = CartService.CalculateTotalPrice();
            Repository.AddOrder(Order);
            return RedirectToPage("/Requests/RequestIndex");
        }
    }
}
