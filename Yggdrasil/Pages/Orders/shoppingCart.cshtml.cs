using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Services;

namespace Yggdrasil.Pages.Orders
{
    public class ShoppingCartModel : PageModel
    {
        public readonly ShoppingCartService ItemsInCart;
        public readonly IOfferRepository OfferRepository;
        public DiscountService discount;

        [BindProperty]
        public Offer Offer { get; set; }
        public int Code { get; set; }

        public bool View;
        public bool Wrong;

        public List<OrderItem> OItems { get; set; }
        public List<Offer> Offers { get; set; }

        public ShoppingCartModel(ShoppingCartService shoppingService, IOfferRepository offerRepo, DiscountService discountService)
        {
            ItemsInCart = shoppingService;
            OItems = new List<OrderItem>();
            OfferRepository = offerRepo;
            discount = discountService;
        }

        public IActionResult OnGet()
        {
            OItems = ItemsInCart.GetOrderedWares();
            return Page();
        }

        public IActionResult OnPostRemove(int id)
        {
            ItemsInCart.DeleteWare(id);
            OItems = ItemsInCart.GetOrderedWares();
            return Page();
        }

        public IActionResult OnPostRCode()
        {
            discount.RemoveOffer();
            OItems = ItemsInCart.GetOrderedWares();
            return Page();
        }

        public IActionResult OnPostDiscount()
        {
            List<Offer> offers = OfferRepository.AllOffers();

            OItems = ItemsInCart.GetOrderedWares();
            if (Offer.Code != 0)
            {
                foreach (var o in offers)
                {
                    if (o.Code == Offer.Code)
                    {
                        discount.UseOffer(o);
                        View = true;
                        Wrong = false;
                    }
                    else
                    {
                        View = false;
                        Wrong = true;
                    }

                }
            }

            return Page();
        }
    }
}
