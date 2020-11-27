using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Catalogs;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.Wares
{
    public class CreateWareModel : PageModel
    {
        private WareCatalog catalog;
        [BindProperty]
        public Ware Ware { get; set; }

        public CreateWareModel()
        {
            catalog = WareCatalog.Instance;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            catalog.AddWare(Ware);

            return RedirectToPage("GetAllWares");
        }
    }
}
