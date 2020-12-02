using Yggdrasil.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using JsonSerializer = System.Text.Json.JsonSerializer;

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

        public static List<Ware> ReadJsonWare(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonSerializer.Deserialize<List<Ware>>(jsonString);
        }
    }
}
