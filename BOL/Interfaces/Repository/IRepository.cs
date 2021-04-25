
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using BOL.Entity;

namespace BOL.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        public IQueryable<TEntity> GetAll();
        public TEntity GetById(object id);
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        public void Add(TEntity entity);
        public void AddRange(IEnumerable<TEntity> entity);
        public void Delete(TEntity entity);
    }
}
