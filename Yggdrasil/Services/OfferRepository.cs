using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Models;

namespace Yggdrasil.Services
{
    public class OfferRepository
    {
        public List<Offer> _Offers { get; set; }

        public List<Offer> AllOffers()
        {
            return _Offers;
        }

        public void AddOffer(Offer offer)
        {
            _Offers.Add(offer);
        }

        public void RemoveOffer()
        {

        }
    }
}
