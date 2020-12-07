using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.Users
{
    public class EditModel : PageModel
    {
        private readonly IUserRepository _repository;
        public string AccessDenied = "";

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

            AccessDenied = "Forkert kodeord";
            return Page();
        }
    }
}
