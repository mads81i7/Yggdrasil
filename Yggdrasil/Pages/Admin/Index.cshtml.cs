using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepo;
        private readonly LoginService _loginService;
        public int AmountOfAdmins { get; set; }
        public int AmountOfCouriers { get; set; }
        public int AmountOfCustomers { get; set; }

        public IndexModel(IUserRepository repository, LoginService loginService)
        {
            _userRepo = repository;
            _loginService = loginService;
            AmountOfAdmins = 0;
            AmountOfCouriers = 0;
            AmountOfCustomers = 0;
        }

        public IList<User> Users { get; set; }

        public IActionResult OnGet()
        {
            if (_loginService.GetLoggedInUser() != null)
            {
                if (_loginService.GetLoggedInUser().UserType == UserTypes.Admin)
                {
                    Users = _userRepo.GetAllUsers();
                    return Page();
                }
            }

            return RedirectToPage("/Index");
        }
    }
}
