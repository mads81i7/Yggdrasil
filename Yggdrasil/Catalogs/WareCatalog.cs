using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Models;

namespace Yggdrasil.Catalogs
{
    public class WareCatalog
    {
        private List<Ware> wares { get; }

        public WareCatalog()
        {
            wares = new List<Ware>();

        }
    }
}
