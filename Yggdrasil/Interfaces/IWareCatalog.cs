using System.Collections.Generic;
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
