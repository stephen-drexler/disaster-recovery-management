
using System;
using System.Collections;
using System.Collections.Generic;
using VM.DisasterRecovery.Common.Models;

namespace VM.DisasterRecovery.Domain.Contracts
{
    public interface IManager<TEntity> : IDisposable
        where TEntity : class, IUpdate<TEntity>
    {
        IEnumerable<TEntity> GellAll();

        TEntity Get(int id);

        OperationResult Create(TEntity entity);

        OperationResult Edit(TEntity entity);

        OperationResult Delete(TEntity entity);
    }
}
