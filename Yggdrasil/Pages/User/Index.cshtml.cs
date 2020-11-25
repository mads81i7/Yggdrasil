using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.User
{
    public class IndexModel : PageModel
    {
        public IUserRepository UserRepo { get; }

        public IndexModel(IUserRepository repository)
        {
            UserRepo = repository;
        }

        public List<Models.User> Users { get; private set; }

        public IActionResult OnGet()
        {
            Users = UserRepo.GetAllUsers();
            return Page();
        }
    }
}
