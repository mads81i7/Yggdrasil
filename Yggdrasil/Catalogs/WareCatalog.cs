using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;
using Yggdrasil.Pages.Wares;

namespace Yggdrasil.Catalogs
{
    public class WareCatalog: IWareCatalog
    {
        private  List<Ware> wares { get; }

        public WareCatalog()
        {
            wares = new List<Ware>();
            wares.Add(new Ware() {Id = 0, Name = "Pizza", Description = "Test", IsOrganic = true, IsVegan = false, Price = 20, Type = WareType.Fresh,ImageName = ""});
            wares.Add(new Ware() {Id = 1, Name = "Baked Beans", IsVegan = true, Price = 15, Type = WareType.Canned, Description = "A tin of beans", IsOrganic = false, ImageName = ""});

        }
        public List<Ware> AllWares()
        {
            return wares;
        }

        private int WareId = 2;
        public void AddWare(Ware ware)
        {

            wares.Add(ware);
            ware.Id = WareId;
            WareId++;
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
