using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.Users
{
    public class DeleteModel : PageModel
    {
        private readonly IUserRepository _repository;
        public string AccessDenied = "";

        public DeleteModel(IUserRepository repository)
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

        public ActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (_repository.GetUser((int)id).Password == User.PasswordCheck)
            {
                _repository.RemoveUser((int) id);
                return RedirectToPage("/Index");
            }

            AccessDenied = "Forkert kodeord";
            return Page();
        }
    }
}
