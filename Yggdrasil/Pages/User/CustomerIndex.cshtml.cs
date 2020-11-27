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
    public class CustomerIndexModel : PageModel
    {
        public ICustomerRepository CustomerRepo { get; }

        public CustomerIndexModel(ICustomerRepository repository)
        {
            CustomerRepo = repository;
        }

        public List<Models.Customer> Customers { get; private set; }

        public IActionResult OnGet()
        {
            Customers = CustomerRepo.GetAllCustomers();
            return Page();
        }
    }
}
