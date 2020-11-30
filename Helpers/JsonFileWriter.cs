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
        public static void WriteToJsonUser(List<User> users, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
    }
}
