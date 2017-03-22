using System;
using System.Collections.Generic;
using System.Linq;

using VM.DisasterRecovery.Common.Models;
using VM.DisasterRecovery.Domain.Contracts;
using VM.DisasterRecovery.Persistence.Contracts;

namespace VM.DisasterRecovery.Services
{
    public abstract class Manager<TEntity, TRepository> : IManager<TEntity> 
        where TEntity : class, IUpdate<TEntity>, IUniqueIdentity
        where TRepository : IRepository<TEntity>
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected readonly TRepository Repository;

        protected Manager(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            UnitOfWork = unitOfWork;
            Repository = (TRepository)repository;
        }

        public virtual IEnumerable<TEntity> GellAll()
        {
            return Repository.GetAll();
        }

        public virtual TEntity Get(int id)
        {
            return Repository.Get(id);
        }

        public virtual OperationResult Create(TEntity entity)
        {
            Repository.Add(entity);
            return UnitOfWork.Commit();
        }

        public virtual OperationResult Delete(TEntity entity)
        {
            Repository.Remove(entity);
            return UnitOfWork.Commit();
        }

        public virtual OperationResult Edit(TEntity entity)
        {
            var original = Repository.Get(entity.Id);
            original.Update(entity);
            return UnitOfWork.Commit();
        }

        public void Dispose()
        {
            UnitOfWork?.Dispose();
        }
    }
}
