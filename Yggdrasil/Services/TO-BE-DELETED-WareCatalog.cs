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
            wares.Add(new Ware() {Name = "Mælk", Description = "Det her er mælk", Price = 10});
            wares.Add(new Ware() { Name = "Smør", Description = "Det her er smør", Price = 5});
            wares.Add(new Ware() { Name = "Brød", Description = "Det her er brød", Price = 12 });
            wares.Add(new Ware() { Name = "Torsk", Description = "Det her er torsk", Price = 30 });
        }

        public List<Ware> GetAllWares()
        {
            return wares;
        }

        public void AddWare(Ware ware)
        {
            wares.Add(ware);
        }

        public Ware GetWare(string name)
        {
            foreach (Ware w in wares)
            {
                if (w.Name == name)
                {
                    return w;
                }
            }
            return null;
        }
    }
}
