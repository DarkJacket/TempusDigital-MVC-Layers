using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BOL.DTO;
using BOL.Entity;

namespace BLL.Helper
{
    public static class ClienteBriefExtension
    {
        public static ClienteBriefDTO ToClienteBrief(this Cliente cliente)
        {
            return new ClienteBriefDTO(cliente.Id, cliente.Nome, cliente.RendaFamiliar);
        }

        public static List<ClienteBriefDTO> ToListClienteBrief(this IEnumerable<Cliente> cliente)
        {
            return cliente.Select(c => c.ToClienteBrief()).ToList();
        }

        public static Cliente ToClienteEntity(this ClienteDTO cliente)
        {
            return new Cliente(cliente.Nome, cliente.CPF, cliente.DataNascimento.ToDateTime(), cliente.RendaFamiliar);
        }

        public static List<Cliente> ToListClienteEntity(this IEnumerable<ClienteDTO> cliente)
        {
            return cliente.Select(c => c.ToClienteEntity()).ToList();
        }



    }
}
