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
    public class DeleteModel : PageModel
    {
        private readonly IUserRepository _repository;

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

            _repository.RemoveUser((int)id);

            return RedirectToPage("./Index");
        }
    }
}
