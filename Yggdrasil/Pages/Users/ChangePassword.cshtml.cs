using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.Users
{
    public class ChangePasswordModel : PageModel
    {
        private readonly IUserRepository _repository;

        public ChangePasswordModel(IUserRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public new User User { get; set; }

        public IActionResult OnPost(int? id)
        {
            _repository.AddUser(User);

            if (_repository.GetUser((int) id).Password == User.PasswordCheck)
            {
                _repository.GetUser((int) id).Password = User.Password;
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}