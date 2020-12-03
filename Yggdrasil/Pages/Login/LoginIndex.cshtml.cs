using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Login
{
    public class LoginIndexModel : PageModel
    {
        private readonly IUserRepository _repository;
        private readonly LoginService _loginService;

        public LoginIndexModel(IUserRepository repository, LoginService loginService)
        {
            _repository = repository;
            _loginService = loginService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        public IActionResult OnPost()
        {
            foreach (User user in _repository.GetAllUsers())
            {
                if (user.EmailAddress == User.EmailAddress)
                {
                    if (user.Password == User.Password)
                    {
                        _loginService.UserLogin(User);
                        return RedirectToPage("/Index");
                    }

                    return RedirectToPage("SignUp");
                }
            }

            return Page();
        }
    }
}
