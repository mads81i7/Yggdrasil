using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.User
{
    public class CourierIndexModel : PageModel
    {
        public ICourierRepository UserRepo { get; }

        public CourierIndexModel(ICourierRepository repository)
        {
            UserRepo = repository;
        }

        public List<Models.Courier> Couriers { get; private set; }

        public IActionResult OnGet()
        {
            Couriers = UserRepo.GetAllCouriers();
            return Page();
        }
    }
}
