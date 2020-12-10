using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Pages.Orders
{
    public class OrderDetailsModel : PageModel
    {
        public Order Order { get; set; }
        public IOrderRepository Repo { get; set; }
        public IUserRepository UserRepo { get; set; }
        public User User1 { get; set; }  

        public OrderDetailsModel(IOrderRepository repository, IUserRepository userRepository)
        {
            Repo = repository;
            UserRepo = userRepository;
        }
        public void OnGet(int id)
        {
            Order = Repo.GetOrder(id);
            User1 = UserRepo.GetUser(Order.CustomerID);
        }
    }
}
