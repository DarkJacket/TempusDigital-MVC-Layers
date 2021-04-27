using BOL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BOL.Interfaces.Services
{
    public interface IClienteService
    {

        IEnumerable<ClienteBriefDTO> GetAllCliente();
        IEnumerable<ClienteBriefDTO> GetClienteBriefWhereNameIsEqualOrReturnAll(string nome);
        void AddCliente(ClienteDTO cliente);
        public IndexDTO GetIndexDTO();





    }
}
