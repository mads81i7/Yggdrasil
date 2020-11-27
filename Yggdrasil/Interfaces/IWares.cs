using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Models;

namespace Yggdrasil.Interfaces
{
    public interface IWares
    {
        List<Ware> GetAllWares();
        void AddWare(Ware ware);
        Ware GetWare(int Id);
    }
}
