using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Catalogs;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.Wares
{
    public class CreateWareModel : PageModel
    {
        private IWareCatalog catalog;
        [BindProperty]
        public Ware Ware { get; set; }

        public List<Ware> Wares { get; set; }   

        public CreateWareModel(IWareCatalog cata)
        {
            catalog = cata;
        }
        public void OnGet()
        {
            Wares = catalog.AllWares();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            catalog.AddWare(Ware);
            Wares = catalog.AllWares();
            return RedirectToPage("GetAllWares");
        }
    }
}
