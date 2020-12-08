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
    public class AcceptRequestModel : PageModel
    {
        private IOrderRepository _orderRepository;
        public List<Order> AcceptedOrders { get; set; } = new List<Order>();

        [BindProperty(SupportsGet = true)]
        public Order Order { get; set; }

        public AcceptRequestModel(IOrderRepository repository, LoginService login)
        {
            _orderRepository = repository;

            foreach (Order order in repository.AllOrders())
            {
                if (order.CourierID == login.GetLoggedInUser().ID)
                    AcceptedOrders.Add(order);
            }
        }

        public void OnGet(int id)
        {
            Order = _orderRepository.GetOrder(id);
            Order.Done = true;
            AcceptedOrders.Add(Order);
        }
    }
}
