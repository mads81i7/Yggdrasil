using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Models;

namespace Yggdrasil.Interfaces
{
    public interface IOfferRepository
    {
        public List<Offer> AllOffers();
        public void AddOffer(Offer offer);
        public void RemoveOffer(Offer offer);

        //public Ware UseOffer(int code);

    }
}
