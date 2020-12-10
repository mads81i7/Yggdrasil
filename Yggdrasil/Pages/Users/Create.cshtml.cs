using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.Users
{
    public class CreateModel : PageModel
    {
        public DateTime EarliestDate = new DateTime(1900, 1, 1);
        public DateTime LatestDate = new DateTime(2002, 12, 12);

        public string BirthDateMessage = "";

        private readonly IUserRepository _repository;

        public CreateModel(IUserRepository repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public new User User { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            if ((User.BirthDate.CompareTo(EarliestDate) >= 0) && (User.BirthDate.CompareTo(LatestDate) <= 0))
            {
                User.Password2 = null;
                _repository.AddUser(User);
                return RedirectToPage("/Index");
            }

            BirthDateMessage = "Fødselsdatoen er ugyldig";
            return Page();
        }
    }
}
