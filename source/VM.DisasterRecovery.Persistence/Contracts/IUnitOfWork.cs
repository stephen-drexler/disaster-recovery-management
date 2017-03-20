using System;
using VM.DisasterRecovery.Persistence.Context;

namespace VM.DisasterRecovery.Persistence.Contracts
{
    public abstract class IUnitOfWork : IDisposable
    {
        internal DisasterRecoveryContext Context { get; private set; }

        protected IUnitOfWork(DisasterRecoveryContext context)
        {
            Context = context;
        }

        public abstract void Commit();

        public abstract void Dispose();
    }
}
