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
        public static List<User> ReadJsonUser(string jsonFileName)
        {
            string jsonString = File.ReadAllText(jsonFileName);

            return JsonSerializer.Deserialize<List<User>>(jsonString);
        }
    }
}
