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
    public class AllWaresModel : PageModel
    {
        private IWares catalog;
        private ShoppingCartService ItemsInCart;
        public AllWaresModel(IWares repo, ShoppingCartService cartService)
        {
            catalog = repo;
            ItemsInCart = cartService;
        }

        public List<Ware> Wares { get; set; }
        public List<Ware> CartList { get; set; }    
        [BindProperty]
        public Ware ware { get; set; }  

        public IActionResult OnGet()
        {
            Wares = catalog.GetAllWares();
            return Page();
        }

        public IActionResult OnPostAdd(int Id)
        {
            if (ModelState.IsValid)
            {
                ware = catalog.GetWare(Id);
                ItemsInCart.AddWare(ware);
                CartList = ItemsInCart.GetOrderedWares();
                Wares = catalog.GetAllWares();
            }
            return Page();
        }
    }
}
