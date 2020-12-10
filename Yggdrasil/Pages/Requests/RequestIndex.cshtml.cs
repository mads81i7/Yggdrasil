using System.Collections.Generic;
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
        public bool EmptyRequestList;

        public RequestIndexModel(IOrderRepository orderRepository, LoginService loginService)
        {
            _orderRepository = orderRepository;
            _loginService = loginService;
            Orders = _orderRepository.AllOrders();

            EmptyRequestList = true;
        }

        public IActionResult OnPostAccept(int id)
        {
            Orders[id].CourierID = _loginService.GetLoggedInUser().ID;
            _orderRepository.EditOrder(id, Orders[id]);

            return Page();
        }
    }
}
