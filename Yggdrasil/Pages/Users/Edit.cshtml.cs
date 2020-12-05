using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly IUserRepository _repository;

        public EditModel(IUserRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public new User User { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = _repository.GetUser((int)id);

            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (_repository.GetUser((int) id).Password == User.PasswordCheck)
            {
                User.Password = _repository.GetUser((int)id).Password;
                User.PasswordCheck = null;
                User.UserType = _repository.GetUser((int)id).UserType;
                _repository.EditUser((int)id, User);
                return RedirectToPage("/Profile/Index");
            }

            return Page();
        }
    }
}
