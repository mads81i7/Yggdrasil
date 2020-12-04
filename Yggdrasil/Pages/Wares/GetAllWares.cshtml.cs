using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        private LoginService log;
        public GetAllWaresModel(IWareCatalog cata, ShoppingCartService cartService, LoginService logService)
        {
            catalog = cata;
            ItemsInCart = cartService;
            log = logService;
            LoggedInUser = new User();
            IsAdmin = false;
        }
        public List<Ware> Wares { get; private set; }
        public List<Ware> CartList { get; private set; }
        public User LoggedInUser { get; set; }
        public bool IsAdmin { get; set; }   
        [BindProperty]
        public Ware ware { get; set; }

        public IActionResult OnGet()
        {
            Wares = catalog.AllWares();
            if (log.GetLoggedInUser() != null)
            {
                LoggedInUser = log.GetLoggedInUser();
                if (LoggedInUser.UserType == UserTypes.Admin)
                {
                    IsAdmin = true;
                }
            }
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
