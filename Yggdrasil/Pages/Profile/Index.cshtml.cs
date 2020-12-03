using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Profile
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _repository;
        private readonly LoginService _loginService;

        public IndexModel(IUserRepository repository, LoginService loginService)
        {
            _repository = repository;
            _loginService = loginService;
        }

        [BindProperty]
        public User User { get; private set; }

        public IActionResult OnGet()
        {
            User = _loginService.GetLoggedInUser();

            if (User == null)
            {
                return RedirectToPage("/Users/Create");
            }
            return Page();
        }
    }
}