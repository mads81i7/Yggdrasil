using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Orders
{
    public class CheckOutModel : PageModel
    {
        [BindProperty]
        public Order Order { get; set; }
        //[BindProperty]
        //public Offer Offer { get; set; }
        public int Code { get; set; }

        private DiscountService discount;
        private readonly ShoppingCartService _cartService;
        private readonly IOrderRepository _orderRepository;
        private readonly LoginService _login;
        //public readonly IOfferRepository OfferRepository;
        public List<OrderItem> Wares { get; set; }

        public CheckOutModel(IOrderRepository repo, ShoppingCartService itemsInCart, LoginService log/*, IOfferRepository offerRepo*/, DiscountService discountService)
        {
            _cartService = itemsInCart;
            _orderRepository = repo;
            _login = log;
            //OfferRepository = offerRepo;
            discount = discountService;
        }

        public IActionResult OnGet()
        {
            if (_login.GetLoggedInUser() == null)
                return RedirectToPage("/Users/Login");

            return Page();
        }
        //public void OnPostDiscount()
        //{
        //    List<Offer> offers = OfferRepository.AllOffers();

        //    if (Offer.Code != 0)
        //    {
        //        foreach (var o in offers)
        //        {
        //            if (o.Code == Offer.Code)
        //                Code = o.Code;

        //        }
        //    }

        //}

        public IActionResult OnPostCheckout()
        {
            Order.OrderedWares = _cartService.GetOrderedWares();

            if (discount.UsedOffer() != null)
            {
                Order.TotalPrice = _cartService.CalculateTotalPrice(discount.UsedOffer().Code);
            }
            else
            {
                Order.TotalPrice = _cartService.CalculateTotalPrice(null);
            }
            
            Order.CustomerID = _login.GetLoggedInUser().ID;
            _orderRepository.AddOrder(Order);
            _cartService.GetOrderedWares().Clear();
            return RedirectToPage("OrderComplete", Order);
        }
    }
}
