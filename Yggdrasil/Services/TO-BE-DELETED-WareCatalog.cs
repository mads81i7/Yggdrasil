using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Services
{
    public class TO_BE_DELETED_WareCatalog:IWares
    {
        private List<Ware> wares { get; }

        public TO_BE_DELETED_WareCatalog()
        {
            wares = new List<Ware>();
            wares.Add(new Ware() {Id = 1, Name = "Mælk", Description = "Det her er mælk", Price = 10});
            wares.Add(new Ware() {Id = 2,Name = "Smør", Description = "Det her er smør", Price = 5});
            wares.Add(new Ware() { Id = 3, Name = "Brød", Description = "Det her er brød", Price = 12 });
            wares.Add(new Ware() { Id = 4, Name = "Torsk", Description = "Det her er torsk", Price = 30 });
        }

        public List<Ware> GetAllWares()
        {
            return wares;
        }

        public void AddWare(Ware ware)
        {
            wares.Add(ware);
        }

        public Ware GetWare(int id)
        {
            foreach (Ware w in wares)
            {
                if (w.Id == id)
                {
                    return w;
                }
            }
            return null;
        }
    }
}
