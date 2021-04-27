using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BOL.Entity;
using BOL.Interfaces.Repositories;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {

        public readonly DbContext _context;
        public readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {

            _dbSet.Add(entity);
            _context.SaveChanges();

        }

        public virtual void AddRange(IEnumerable<TEntity> entity)
        {
            _dbSet.AddRange(entity);
            _context.SaveChanges();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }
    }
}
