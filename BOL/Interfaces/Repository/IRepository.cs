
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BOL.Entity;

namespace BOL.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public IEnumerable<TEntity> GetAll();
        public TEntity GetById(int id);
        public void Add(TEntity entity);
        public void AddRange(IEnumerable<TEntity> entity);
        public void Delete(TEntity entity);
    }
}
