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
        public List<Ware> Wares { get; set; }


        public AllWaresModel(IWares repo)
        {
            catalog = repo;
        }
        public void OnGet()
        {
            Wares = catalog.GetAllWares();
        }
    }
}
