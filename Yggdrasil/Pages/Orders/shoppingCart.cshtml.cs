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
        public ShoppingCartService itemsInCart { get; }
        private IWareCatalog repo;
        
        public Ware ware { get; set; }
        
        public List<OrderItem> OItems { get; set; }


        public shoppingCartModel(ShoppingCartService shoppingService, IWareCatalog wareRepo)
        {
            itemsInCart = shoppingService;
            repo = wareRepo;
            OItems = new List<OrderItem>();
        }
        public IActionResult OnGet(/*int? id*/)
        {
            //if (id == null)
            //    return Page();
            //Ware ware = repo.GetWare((int)id);
            //itemsInCart.AddWare(ware);
            OItems = itemsInCart.GetOrderedWares();
            return Page();
        }

        public IActionResult OnPostRemove(int id)
        {
            itemsInCart.DeleteWare(id);
            OItems = itemsInCart.GetOrderedWares();
            return Page();
        }

        

    }
}
