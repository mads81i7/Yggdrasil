using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Models;

namespace Yggdrasil.Interfaces
{
    public interface ICourierRepository
    {
        List<Courier> GetAllCouriers();
        void AddCourier(Courier courier);
        public Courier GetCourier(int id);
    }
}
