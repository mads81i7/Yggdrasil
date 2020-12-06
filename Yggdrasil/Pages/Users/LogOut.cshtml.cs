using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Users
{
    public class LogoutModel : PageModel
    {
        private readonly LoginService _logInService;

        public LogoutModel(LoginService logInService)
        {
            _logInService = logInService;
        }

        public IActionResult OnGet()
        {
            _logInService.UserLogout();

            return RedirectToPage("/Index");
        }
    }
}
