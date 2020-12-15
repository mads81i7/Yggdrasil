using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            WaresFilter = catalog.AllWares();
        }
        public List<Ware> Wares { get; private set; }
        public List<OrderItem> CartList { get; private set; }
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
            WaresFilter = Wares;

            return Page();

        }

        public IActionResult WareType()
        {
            return Page();
        }


        public List<Ware> WaresFilter { get; set; }


        public IActionResult OnPostSearch()
        {
            switch (ware.Type)
            {
                case Models.WareType.Drink:
                    WaresFilter.Clear();
                    foreach (Ware w in catalog.AllWares())
                    {
                        if (w.Type == Models.WareType.Drink)
                        {
                            WaresFilter.Add(w);
                        }
                    }
                    break;
                case Models.WareType.Fresh:
                    WaresFilter.Clear();
                    foreach (Ware w in catalog.AllWares())
                    {
                        if (w.Type == Models.WareType.Fresh)
                        {
                            WaresFilter.Add(w);
                        }
                    }
                    break;
                case Models.WareType.Canned:
                    WaresFilter.Clear();
                    foreach (Ware w in catalog.AllWares())
                    {
                        if (w.Type == Models.WareType.Canned)
                        {
                            WaresFilter.Add(w);
                        }
                    }
                    break;
                case Models.WareType.Dairy:
                    WaresFilter.Clear();
                    foreach (Ware w in catalog.AllWares())
                    {
                        if (w.Type == Models.WareType.Dairy)
                        {
                            WaresFilter.Add(w);
                        }
                    }
                    break;
                case Models.WareType.Dry:
                    WaresFilter.Clear();
                    foreach (Ware w in catalog.AllWares())
                    {
                        if (w.Type == Models.WareType.Dry)
                        {
                            WaresFilter.Add(w);
                        }
                    }
                    break;
                default:
                    WaresFilter = catalog.AllWares();
                    break;
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
