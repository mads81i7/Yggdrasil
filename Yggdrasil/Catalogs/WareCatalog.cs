using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Models;
using Yggdrasil.Pages.Wares;

namespace Yggdrasil.Catalogs
{
    public class WareCatalog
    {
        private  List<Ware> wares { get; }
        private static WareCatalog _instance;

        public WareCatalog()
        {
            wares = new List<Ware>();
            wares.Add(new Ware() {Id = 0, Name = "Pizza", Description = "Test", IsOrganic = true, IsVegan = false, Price = 20, Type = WareType.Fresh,ImageName = ""});
            wares.Add(new Ware() {Id = 1, Name = "Baked Beans", IsVegan = true, Price = 15, Type = WareType.Canned, Description = "A tin of beans", IsOrganic = false, ImageName = ""});

        }

        public static WareCatalog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WareCatalog();
                }

                return _instance;
            }
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
    }
}
