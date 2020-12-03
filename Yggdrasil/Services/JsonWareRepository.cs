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

        private int WareId = 2;
        public void AddWare(Ware ware)
        {
            List<Ware> wares = AllWares().ToList();
            wares.Add(ware);
            ware.Id = WareId;
            WareId++;
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
