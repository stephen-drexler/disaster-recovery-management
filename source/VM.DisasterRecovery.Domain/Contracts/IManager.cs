
using VM.DisasterRecovery.Common.Models;

namespace VM.DisasterRecovery.Domain.Contracts
{
    public interface IManager<in TEntity> where TEntity : class, IUpdate<TEntity>
    {
        OperationResult Create(TEntity entity);

        OperationResult Edit(TEntity entity);

        OperationResult Delete(TEntity entity);
    }
}
