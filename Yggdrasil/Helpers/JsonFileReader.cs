using Yggdrasil.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Yggdrasil
{
    public class JsonFileReader
    {
        public static List<Customer> ReadJsonCustomer(string jsonFileName)
        {
            string jsonString = File.ReadAllText(jsonFileName);

            return JsonSerializer.Deserialize<List<Customer>>(jsonString);
        }

        public static List<Courier> ReadJsonCourier(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);

            return JsonSerializer.Deserialize<List<Courier>>(jsonString);
        }
    }
}
