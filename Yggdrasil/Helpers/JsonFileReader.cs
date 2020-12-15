using Yggdrasil.Models;
using System.Collections.Generic;
using System.IO;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Yggdrasil
{
    public class JsonFileReader
    {
        public static List<User> ReadJsonUser(string jsonFileName)
        {
            string jsonString = File.ReadAllText(jsonFileName);
            return JsonSerializer.Deserialize<List<User>>(jsonString);
        }
        public static List<Ware> ReadJsonWare(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonSerializer.Deserialize<List<Ware>>(jsonString);
        }
        public static List<Order> ReadJsonOrder(string JsonFileName)
        {
            string jsonString = File.ReadAllText(JsonFileName);
            return JsonSerializer.Deserialize<List<Order>>(jsonString);
        }
    }
}
