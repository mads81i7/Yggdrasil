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
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public List<Ware> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return WaresFilter;
            }

            return FilteredWares(searchTerm);
        }

        private List<Ware> FilteredWares(string searchTerm)
        {
            string lowerTerm = searchTerm.ToLower();
            //WaresFilter.Where(e => e.Name.ToLower().Contains(searchTerm))
            if (!string.IsNullOrWhiteSpace(lowerTerm))
            {
                foreach (Ware w in catalog.AllWares())
                {
                    if (w.Name.ToLower().Contains(lowerTerm) && !WaresFilter.Contains(w))
                    {
                        WaresFilter.Add(w);
                    }
                }
            }

            return WaresFilter;
        }

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
                            Search(SearchTerm);
                        }
                    }
                    break;
                case Models.WareType.Fresh:
                    WaresFilter.Clear();
                    foreach (Ware w in catalog.AllWares())
                    {
                        if (!WaresFilter.Contains(w))
                        {
                            if (w.Type == Models.WareType.Fresh)
                            {
                                Search(SearchTerm);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                case Models.WareType.Canned:
                    WaresFilter.Clear();
                    foreach (Ware w in catalog.AllWares())
                    {
                        if (w.Type == Models.WareType.Canned)
                        {
                            Search(SearchTerm);
                            if (!WaresFilter.Contains(w))
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
                            Search(SearchTerm);
                            if (!WaresFilter.Contains(w))
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
                            Search(SearchTerm);
                            if (!WaresFilter.Contains(w))
                                WaresFilter.Add(w);
                        }
                    }
                    break;
                case Models.WareType.All:
                    WaresFilter.Clear();
                    if (SearchTerm == null)
                        WaresFilter = catalog.AllWares();
                    else
                    {
                        foreach (Ware w in catalog.AllWares())
                            if (!string.IsNullOrWhiteSpace(SearchTerm) && !WaresFilter.Contains(w))
                            {
                                WaresFilter.Add(w);
                            }
                    }

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
                Wares = catalog.AllWares();
            }
            return Page();
        }
    }
}
