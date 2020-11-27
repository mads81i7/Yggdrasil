using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Yggdrasil.Models;

namespace Yggdrasil
{
    public class JsonFileWriter
    {
        public static void WriteToJsonCustomer(List<Customer> customers, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(customers, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }

        public static void WriteToJsonCourier(List<Courier> couriers, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(couriers, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
    }
}
