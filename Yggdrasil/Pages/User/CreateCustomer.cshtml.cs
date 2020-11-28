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
    public class CreateCustomerModel : PageModel
    {
        private ICustomerRepository _customerRepository;
        [BindProperty]
        public Customer Customer { get; set; }
        public List<Customer> Customers { get; set; }
        public CreateCustomerModel(ICustomerRepository repository)
        {
            _customerRepository = repository;
        }

        public void OnGet()
        {
            Customers = _customerRepository.GetAllCustomers();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _customerRepository.AddCustomer(Customer);
            Customers = _customerRepository.GetAllCustomers();
            return RedirectToPage("CustomerIndex");
        }
    }
}
