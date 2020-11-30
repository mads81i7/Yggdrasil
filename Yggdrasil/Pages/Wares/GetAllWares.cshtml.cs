using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Catalogs;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Wares
{
    public class GetAllWaresModel : PageModel
    {
        private IWareCatalog catalog;
        private ShoppingCartService ItemsInCart;
        public GetAllWaresModel(IWareCatalog cata, ShoppingCartService cartService)
        {
            catalog = cata;
            ItemsInCart = cartService;
        }
        public List<Ware> Wares { get; private set; }
        public List<Ware> CartList { get; private set; }
        [BindProperty]
        public Ware ware { get; set; }
        public IActionResult OnGet()
        {
            Wares = catalog.AllWares();
            return Page();
        }

        public IActionResult OnPostAdd(int Id)
        {
            if (ModelState.IsValid)
            {
                ware = catalog.GetWare(Id);
                ItemsInCart.AddWare(ware);
                CartList = ItemsInCart.GetOrderedWares();
                Wares = catalog.AllWares();
            }
            return Page();
        }
    }
}
