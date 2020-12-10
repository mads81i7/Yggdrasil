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
        private IWareCatalog repo;
        
        public Ware ware { get; set; }
        
        public List<OrderItem> OItems { get; set; }

        public ShoppingCartModel(ShoppingCartService shoppingService, IWareCatalog wareRepo)
        {
            ItemsInCart = shoppingService;
            repo = wareRepo;
            OItems = new List<OrderItem>();
        }
        public IActionResult OnGet(/*int? id*/)
        {
            //if (id == null)
            //    return Page();
            //Ware ware = repo.GetWare((int)id);
            //itemsInCart.AddWare(ware);
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
