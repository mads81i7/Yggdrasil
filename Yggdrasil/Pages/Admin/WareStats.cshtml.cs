using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Admin
{
    public class WareStatsModel : PageModel
    {
        private IWareCatalog wareRepo;
        private IOrderRepository orderRepo;
        public List<Ware> Wares { get; set; }
        public List<Order> Orders { get; set; } 

        public WareStatsModel(IWareCatalog wareRepository, IOrderRepository orderRepository)
        {
            wareRepo = wareRepository;
            orderRepo = orderRepository;
        }
        public void OnGet()
        {
            Wares = wareRepo.AllWares();
            Orders = orderRepo.AllOrders();
        }
    }
}
