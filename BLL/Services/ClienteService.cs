using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AddCliente(ClienteDTO cliente)
        {
            
            
            var client = new Cliente(cliente.Nome, cliente.CPF, cliente.DataNascimento.ToDateTime(), cliente.RendaFamiliar);

            client.DataCadastro = DateTime.Now;

            _clienteRepo.Add(client);
            
        }

        public IndexDTO GetIndexDTO()
        {

            var classABC = GetNumbersOfClientesByClasse();

            var numberClientes = classABC.Sum(c => c);

            return new IndexDTO(classABC[0], classABC[1], classABC[2], GetNumbersOfClientesBiggerThanEighteenWithRendaFamiliarBiggerThenMedia(), numberClientes, GetNumbersOfClientesBiggerThanEighteen());
        }

        private int GetNumbersOfClientesBiggerThanEighteen()
        {
            return GetClientesBiggerThanEighteen().Count();
        }

        private int GetNumbersOfClientesBiggerThanEighteenWithRendaFamiliarBiggerThenMedia()
        {


            var clientes = _clienteRepo.GetAll();

            var media = clientes.Sum(c => c.RendaFamiliar) / clientes.Count();

            var value = GetClientesBiggerThanEighteen()
                .Where(c => (DateTime.Now - c.DataNascimento).TotalDays / 365 > 18.00 && c.RendaFamiliar > media)
                .Count();


            return value;
        }

        private IEnumerable<Cliente> GetClientesBiggerThanEighteen()
        {
            return _clienteRepo.GetAll().ToList().Where(c => (DateTime.Now - c.DataNascimento).TotalDays / 365 > 18.00);
        }

        private int[] GetNumbersOfClientesByClasse()
        {
            var clientes = _clienteRepo.GetAll();

            var classA = clientes.Where(c => c.RendaFamiliar >= 2500).Count();
            var classB = clientes.Where(c => c.RendaFamiliar < 2500 && c.RendaFamiliar >= 1000).Count();
            var classC = clientes.Where(c => c.RendaFamiliar < 1000).Count();
            return new int[3] { classA, classB, classC };
        }

    }
}
