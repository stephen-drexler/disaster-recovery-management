using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.DisasterRecovery.Domain.Contracts
{
    public interface IUpdate<in TEntity> where TEntity : class
    {
        void Update(TEntity entity);
    }
}
