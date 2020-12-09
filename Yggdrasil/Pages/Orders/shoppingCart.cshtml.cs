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
    public class shoppingCartModel : PageModel
    {
        public ShoppingCartService itemsInCart;
        private IWareCatalog repo;
        [BindProperty]
        public Ware ware { get; set; }
        [BindProperty]
        public OrderItem oItem { get; set; }

        public List<Ware> Wares { get; set; }


        public shoppingCartModel(ShoppingCartService shoppingService, IWareCatalog wareRepo)
        {
            itemsInCart = shoppingService;
            repo = wareRepo;
            Wares = new List<Ware>();
        }
        public void OnGet()
        {
            Wares = itemsInCart.GetOrderedWares();
        }

        public IActionResult OnPostRemove(int Id)
        {
            itemsInCart.DeleteWare(Id);
            Wares = itemsInCart.GetOrderedWares();
            return Page();
        }

        

    }
}
