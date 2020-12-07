using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly LoginService _loginService;

        [BindProperty]
        public new User User { get; set; } = new User();

        public IndexModel(ILogger<IndexModel> logger, LoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;
        }

        public void OnGet()
        {
            if (_loginService.GetLoggedInUser() != null)
                User = _loginService.GetLoggedInUser();
            else
                User.EmailAddress = "";
        }
    }
}
