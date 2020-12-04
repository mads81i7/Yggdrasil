using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yggdrasil.Interfaces;
using Yggdrasil.Models;

namespace Yggdrasil.Services
{
    public class JsonWareRepository: IWareCatalog
    {
        string JsonFileName = @"Data\JsonWareRepository.json";

        public List<Ware> AllWares()
        {
            return JsonFileReader.ReadJsonWare(JsonFileName);
        }

        public void AddWare(Ware ware)
        {
            List<int> ids = new List<int>();
            List<Ware> wares = AllWares().ToList();
            foreach (Ware w in wares)
            {
                ids.Add(w.Id);
            }
            ware.Id = ids.Max() + 1;
            wares.Add(ware);
            JsonFileWriter.WriteToJsonWare(wares, JsonFileName);
        }

        public Ware GetWare(int id)
        {
            foreach (Ware w in AllWares())
            {
                if (w.Id == id)
                {
                    return w;
                }
            }
            return null;
        }
    }
}
