using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Services
{
    public class JsonCourierRepository : ICourierRepository
    {
        string JsonFileName = @"Data\JsonCourierRepository.json";

        public List<Courier> GetAllCouriers()
        {
            return JsonFileReader.ReadJsonCourier(JsonFileName);
        }

        public void AddCourier(Courier courier)
        {
            List<Courier> couriers = GetAllCouriers().ToList();
            List<int> courierIDs = new List<int>();

            foreach (Courier courierAlt in couriers)
                courierIDs.Add(courierAlt.ID);

            if (courierIDs.Count != 0)
            {
                int i = courierIDs.Max();
                courier.ID = i + 1;
            } else
                courier.ID = 1;

            couriers.Add(courier);
            JsonFileWriter.WriteToJsonCourier(couriers, JsonFileName);
        }

        public Courier GetCourier(int id)
        {
            foreach (Courier courier in GetAllCouriers())
            {
                if (courier.ID == id)
                    return courier;
            }
            return new Courier();
        }
    }
}
