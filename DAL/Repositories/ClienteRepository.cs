
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DAL.Repositories;
using BOL.Entity;
using BOL.Interfaces.Repositories;

namespace DAL.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Cliente> FilterAllByName(string nome)
        {
            return _dbSet.Where(c => c.Nome.Contains(nome)).ToList();
        }


        public override void Add(Cliente cliente)
        {
            cliente.DataCadastro = DateTime.Now;

            base.Add(cliente);
        }


        public bool FindIfCpfIsUse(string cpf)
        {
            if (_dbSet.FirstOrDefault() == null)
            {
                return false;
            }

            return true;
        }

        public void Dispose()
        {
            return;
        }
    }
}
