using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BOL.Entity;
using BOL.Interfaces.Repositories;

namespace DAL.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {

        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

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

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public virtual TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }
    }
}
