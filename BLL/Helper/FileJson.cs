using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

using Nancy.Json;
using BOL.Entity;

namespace BLL.Helper
{
    public static class FileJson
    {

        public static Cliente[] FileJsonToClienteDb()
        {
            var text = File.ReadAllText("Clientes.json");

            var json = new JavaScriptSerializer();
            Cliente[] clientes = json.Deserialize<Cliente[]>(text);

            return clientes;
        }
    }
}
