using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using Nancy.Json;
using BOL.Entity;
using BOL.DTO;

namespace BLL.Helper
{
    public static class FileJson
    {

        public static ClienteIODTO[] FileJsonToClienteDb()
        {
            var text = File.ReadAllText("Clientes.json");

            var json = new JavaScriptSerializer();
            ClienteIODTO[] clientes = json.Deserialize<ClienteIODTO[]>(text);

            return clientes;
        }
    }
}
