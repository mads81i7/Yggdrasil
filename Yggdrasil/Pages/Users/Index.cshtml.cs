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
        public readonly IUserRepository UserRepo;
        private readonly LoginService _loginService;

        public IndexModel(IUserRepository repository, LoginService loginService)
        {
            UserRepo = repository;
            _loginService = loginService;
        }

        public IList<User> Users { get; set; }

        public IActionResult OnGet()
        {
            if (_loginService.GetLoggedInUser() != null)
            {
                if (_loginService.GetLoggedInUser().UserType == UserTypes.Admin)
                {
                    Users = UserRepo.GetAllUsers();
                    return Page();
                }
            }

            return RedirectToPage("/Index");
        }
    }
}
