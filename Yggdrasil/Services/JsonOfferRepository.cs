using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Services
{
    public class JsonOfferRepository : IOfferRepository
    {
        
        private string JsonFileName = @"Data\JsonOfferRepository.json";

        public List<Offer> AllOffers()
        {
            return JsonFileReader.ReadJsonOffer(JsonFileName);
        }

        public Offer GetOffer(int code)
        {
            foreach (Offer offer in AllOffers())
            {
                if (offer.Code == code)
                    return offer;
            }
            return new Offer();
        }

        public void AddOffer(Offer offer)
        {
            List<Offer> offers = AllOffers();

            offers.Add(offer);
            JsonFileWriter.WriteToJsonOffer(offers, JsonFileName);
        }

        public void RemoveOffer(Offer offer)
        {
            List<Offer> offers = AllOffers().ToList();
            offers.Remove(offer);
        }

        //public Ware UseOffer(int code)
        //{
        //    Ware ware = new Ware();

        //    foreach (var o in AllOffers())
        //    {
        //        if (o.Code == code)
        //        {
        //            ware.Price = ware.Price * -o.Discount;
        //            return ware;
        //        }
                
        //    }

        //    return null;

        //}
    }
}
