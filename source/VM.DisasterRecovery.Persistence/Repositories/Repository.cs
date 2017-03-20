using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using VM.DisasterRecovery.Domain.Contracts;
using VM.DisasterRecovery.Persistence.Context;

namespace VM.DisasterRecovery.Persistence.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbSet<TEntity> DataSet;

        protected Repository(DisasterRecoveryContext context)
        {
            DataSet = context.Set<TEntity>();
        }

        public virtual TEntity Get(int id)
        {
            return DataSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DataSet.ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DataSet.Where(predicate);
        }

        public virtual TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return DataSet.SingleOrDefault(predicate);
        }

        public virtual void Add(TEntity entity)
        {
            DataSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            DataSet.AddRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            DataSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            DataSet.RemoveRange(entities);
        }
    }
}
