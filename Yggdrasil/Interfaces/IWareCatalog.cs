using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Models;

namespace Yggdrasil.Interfaces
{
    public interface IWareCatalog
    {
        public List<Ware> AllWares();
        public void AddWare(Ware ware);
        public Ware GetWare(int id);
    }
}
