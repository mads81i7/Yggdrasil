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

        [BindProperty]
        public Ware ware { get; set; }
        [BindProperty]
        public OrderItem oItem { get; set; }
        public List<Ware> Wares { get; set; }

        public ShoppingCartModel(ShoppingCartService shoppingService, IWareCatalog wareRepo)
        {
            ItemsInCart = shoppingService;
            repo = wareRepo;
            Wares = new List<Ware>();
        }
        public void OnGet(int Id)
        {
            //itemsInCart.AddWare(repo.GetWare(Id));
            Wares = ItemsInCart.GetOrderedWares();
        }

        public IActionResult OnPostRemove(int Id)
        {
            ItemsInCart.DeleteWare(Id);
            Wares = ItemsInCart.GetOrderedWares();
            return Page();
        }
    }
}
