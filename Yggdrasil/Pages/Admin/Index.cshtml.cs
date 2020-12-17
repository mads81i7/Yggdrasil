using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public readonly IUserRepository UserRepo;
        private readonly LoginService _loginService;
        private IWareCatalog _wareRepo;
        private IOrderRepository _orderRepo;
        public readonly IOfferRepository _offerRepo;

        public List<Ware> Wares { get; set; }
        public List<Order> Orders { get; set; }
        public List<Offer> Offers { get; set; }

        public int AmountOfAdmins { get; set; }
        public int AmountOfCouriers { get; set; }
        public int AmountOfCustomers { get; set; }

        public IndexModel(IUserRepository repository, LoginService loginService, IWareCatalog wareRepo, IOrderRepository orderRepo, IOfferRepository offerRepo)
        {
            UserRepo = repository;
            _loginService = loginService;
            _wareRepo = wareRepo;
            _orderRepo = orderRepo;
            _offerRepo = offerRepo;
            AmountOfAdmins = 0;
            AmountOfCouriers = 0;
            AmountOfCustomers = 0;
        }

        public IList<User> Users { get; set; }

        public IActionResult OnGet()
        {
            Wares = _wareRepo.AllWares();
            Orders = _orderRepo.AllOrders();
            Offers = _offerRepo.AllOffers();

            if (_loginService.GetLoggedInUser() != null)
            {
                if (_loginService.GetLoggedInUser().UserType == UserTypes.Admin)
                {
                    Users = UserRepo.GetAllUsers();
                    return Page();
                }
            }

            return RedirectToPage("/Index");
        }
    }
}
