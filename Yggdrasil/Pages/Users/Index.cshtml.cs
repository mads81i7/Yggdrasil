using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IndexModel(IUserRepository repository, LoginService loginService)
        {
            _userRepo = repository;
            _loginService = loginService;
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
