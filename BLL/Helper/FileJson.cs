using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using Nancy.Json;
using BOL.DTO;

namespace BLL.Helper
{
    public static class FileJson
    {

        public static ClienteDTO[] FileJsonToClienteDb()
        {
            var text = File.ReadAllText("Clientes.json");

            var json = new JavaScriptSerializer();
            ClienteDTO[] clientes = json.Deserialize<ClienteDTO[]>(text);

            return clientes;
        }
    }
}
