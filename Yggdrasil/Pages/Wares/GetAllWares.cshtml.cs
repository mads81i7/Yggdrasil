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
    public class GetAllWaresModel : PageModel
    {
        private WareCatalog catalog;
        public GetAllWaresModel()
        {
            catalog = new WareCatalog();
        }
        public List<Ware> Wares { get; private set; }
        public IActionResult OnGet()
        {
            Wares = catalog.AllWares();
            return Page();
        }
    }
}
