
using VM.DisasterRecovery.Persistence.Context;
using VM.DisasterRecovery.Persistence.Contracts;

namespace VM.DisasterRecovery.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork() : this(DisasterRecoveryContext.Create()) { }

        public UnitOfWork(DisasterRecoveryContext context) : base(context) { }

        public override void Commit()
        {
            Context.SaveChanges();
        }

        public override void Dispose()
        {
            Context?.Dispose();
        }
    }
}
