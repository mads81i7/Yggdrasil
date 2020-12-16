using System.Collections.Generic;
using System.IO;
using Yggdrasil.Models;

namespace Yggdrasil
{
    public class JsonFileWriter
    {
        public static void WriteToJsonUser(List<User> users, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
        public static void WriteToJsonWare(List<Ware> wares, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(wares, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
        public static void WriteToJsonOrder(List<Order> orders, string jsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(orders, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFileName, output);
        }
        public static void WriteToJsonOffer(List<Offer> offers, string jsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(offers, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(jsonFileName, output);
        }
    }
}
