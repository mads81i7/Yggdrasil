using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Services
{
    public class DiscountService
    {
        
        private Offer OfferUsed;

        public Offer UsedOffer()
        {
            return OfferUsed;
        }

        public void UseOffer(Offer offer)
        {
            OfferUsed = offer;
        }

        public void RemoveOffer()
        {
            OfferUsed = null;
        }

    }
}
