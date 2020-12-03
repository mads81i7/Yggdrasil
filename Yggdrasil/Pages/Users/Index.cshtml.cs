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
    public class IndexModel : PageModel
    {
        private readonly IUserRepository _userRepo;

        public IndexModel(IUserRepository repository)
        {
            _userRepo = repository;
        }

        public IList<User> Users { get; set; }

        public IActionResult OnGet()
        {
            Users = _userRepo.GetAllUsers();
            return Page();
        }
    }
}
