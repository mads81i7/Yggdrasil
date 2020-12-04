using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Users
{
    public class LogOutModel : PageModel
    {
        private readonly LoginService _logInService;

        public LogOutModel(LoginService logInService)
        {
            _logInService = logInService;
        }

        public IActionResult OnGet()
        {
            _logInService.UserLogOut();

            return RedirectToPage("/Index");
        }
    }
}
