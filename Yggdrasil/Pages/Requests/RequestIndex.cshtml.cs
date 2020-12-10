using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Requests
{
    public class RequestIndexModel : PageModel
    {
        private readonly IOrderRepository _orderRepository;
        private readonly LoginService _loginService;
        public List<Order> Orders;

        [BindProperty(SupportsGet = true)]
        public string Criteria { get; set; }

        public RequestIndexModel(IOrderRepository orderRepository, LoginService loginService)
        {
            _orderRepository = orderRepository;
            _loginService = loginService;
            Orders = _orderRepository.AllOrders();
        }

        public void OnGet()
        {
            Orders = _orderRepository.FilterOrders(Criteria);
        }

        public IActionResult OnPostAccept(int id)
        {
            Orders[id].CourierID = _loginService.GetLoggedInUser().ID;
            _orderRepository.EditOrder(id, Orders[id]);

            return Page();
        }
    }
}
