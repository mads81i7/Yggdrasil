using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.Users
{
    public class ChangePasswordModel : PageModel
    {
        private readonly IUserRepository _repository;
        private string _newPassword;
        public string AccessDenied = "";

        public ChangePasswordModel(IUserRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public new User User { get; set; }

        public IActionResult OnPost(int? id)
        {
            if (_repository.GetUser((int) id).Password == User.PasswordCheck)
            {
                _newPassword = User.Password;
                User = _repository.GetUser((int) id);
                User.Password = _newPassword;

                _repository.EditUser((int) id, User);
                return RedirectToPage("./Index");
            }

            AccessDenied = "Forkert kodeord";
            return Page();
        }
    }
}