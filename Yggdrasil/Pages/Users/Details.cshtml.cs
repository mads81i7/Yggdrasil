using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Users
{
    public class DetailsModel : PageModel
    {
        private readonly IUserRepository _repository;
        public readonly IOrderRepository _repo;

        public DetailsModel(IUserRepository repository, IOrderRepository repo)
        {
            _repository = repository;
            _repo = repo;
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
