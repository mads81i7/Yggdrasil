using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Orders
{
    public class ShoppingCartModel : PageModel
    {
        public readonly ShoppingCartService ItemsInCart;

        public List<OrderItem> OItems { get; set; }

        public ShoppingCartModel(ShoppingCartService shoppingService)
        {
            ItemsInCart = shoppingService;
            OItems = new List<OrderItem>();
        }
        public IActionResult OnGet()
        {
            OItems = ItemsInCart.GetOrderedWares();
            return Page();
        }

        public IActionResult OnPostRemove(int id)
        {
            ItemsInCart.DeleteWare(id);
            OItems = ItemsInCart.GetOrderedWares();
            return Page();
        }
    }
}
