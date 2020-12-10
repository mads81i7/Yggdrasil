using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.Users
{
    public class DetailsModel : PageModel
    {
        public readonly IUserRepository _repository;

        public DetailsModel(IUserRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public new User User { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
                return NotFound();

            User = _repository.GetUser((int)id);

            if (User == null)
                return NotFound();

            return Page();
        }
    }
}
