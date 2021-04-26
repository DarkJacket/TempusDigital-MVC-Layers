using System;
using System.Collections.Generic;
using System.Text;

using BLL.Helper;
using BOL.DTO;
using BOL.Entity;
using BOL.Interfaces.Repositories;
using BOL.Interfaces.Services;

namespace BLL.Services
{
    public class ClienteService : IClienteService
    {
        public ClienteService(IClienteRepository clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        private readonly IClienteRepository _clienteRepo;

        public IEnumerable<ClienteBriefDTO> GetAllCliente()
        {
            return _clienteRepo.GetAll().ToListClienteBrief();
        }

        public IEnumerable<ClienteBriefDTO> GetClienteBriefWhereNameIsEqualOrReturnAll(string nome)
        {
            if (String.IsNullOrWhiteSpace(nome))
                return _clienteRepo
                    .GetAll()
                    .ToListClienteBrief();

            return _clienteRepo
                .Where(c => c.Nome.Contains(nome))
                .ToListClienteBrief();
        }

        public bool AddCliente(ClienteDTO cliente)
        {
            try
            {
                var client = new Cliente(cliente.Nome, cliente.CPF, cliente.DataNascimento.ToDateTime(), cliente.RendaFamiliar);

                _clienteRepo.Add(client);

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

    }
}
