using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Linq.Expressions;
using VM.DisasterRecovery.Common.Models;
using VM.DisasterRecovery.Domain.Contracts;
using VM.DisasterRecovery.Persistence.Context;

namespace VM.DisasterRecovery.Persistence.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly DbSet<TEntity> DataSet;

        protected Repository(DisasterRecoveryContext context)
        {
            DataSet = context.Set<TEntity>();
        }

        public virtual TEntity Get(int id)
        {
            return DataSet?.Find(id) ?? new TEntity();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
           return DataSet?.ToList() ?? new List<TEntity>();
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
            if (null == entity)
                throw new ArgumentNullException($"{typeof(TEntity).FullName}");

            DataSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            if (null == entities)
                throw new ArgumentNullException($"{typeof(IEnumerable<TEntity>).FullName}");

            DataSet.AddRange(entities);
        }

        public virtual void Remove(TEntity entity)
        {
            if (null == entity)
                throw new ArgumentNullException($"{typeof(TEntity).FullName}");

            DataSet.Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            if (null == entities)
                throw new ArgumentNullException($"{typeof(IEnumerable<TEntity>).FullName}");

            DataSet.RemoveRange(entities);
        }
    }
}
