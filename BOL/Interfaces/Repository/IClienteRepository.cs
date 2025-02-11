﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BOL.Entity;


namespace BOL.Interfaces.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>, IDisposable
    {
        bool FindIfCpfIsUse(string cpf);
    }
}
