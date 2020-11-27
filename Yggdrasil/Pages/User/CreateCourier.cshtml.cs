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
    public class CreateCourierModel : PageModel
    {
        private ICourierRepository _courierRepository;
        [BindProperty]
        public Courier Courier { get; set; }
        public List<Courier> Couriers { get; set; }
        public CreateCourierModel(ICourierRepository repository)
        {
            _courierRepository = repository;
        }

        public void OnGet()
        {
            Couriers = _courierRepository.GetAllCouriers();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _courierRepository.AddCourier(Courier);
            Couriers = _courierRepository.GetAllCouriers();
            return RedirectToPage("CourierIndex");
        }
    }
}
