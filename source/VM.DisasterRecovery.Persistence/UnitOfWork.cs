
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Runtime.InteropServices;
using VM.DisasterRecovery.Common.Models;
using VM.DisasterRecovery.Persistence.Context;
using VM.DisasterRecovery.Persistence.Contracts;

namespace VM.DisasterRecovery.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private static string CommitChangesSuccess => Properties.Persistence.Default.UnitOfWorkCommitChangesSuccess;

        private static string CommitChangesValidationError => Properties.Persistence.Default.UnitOfWorkCommitChangesValidationError;

        private static string CommitChangesConcurrencyError => Properties.Persistence.Default.UnitOfWorkCommitChangesConcurrencyError;

        private static string CommitChangesFailed => Properties.Persistence.Default.UnitOfWorkCommitChangesFailed;

        public UnitOfWork() : this(DisasterRecoveryContext.Initialize()) { }

        public UnitOfWork(DisasterRecoveryContext context) : base(context) { }

        public override OperationResult Commit()
        {
            OperationResult result;

            if (null == Context)
                return OperationResult.Initialize(false, CommitChangesFailed, new NullReferenceException("DisasterRecoveryContext"));
          
            try
            {
                Context.SaveChanges();
                result = OperationResult.Initialize(true, CommitChangesSuccess);
            }
            catch (DbEntityValidationException exception)
            {
                //TODO: Add Logging - Debug
                result = this.HandleDatabaseUpdateException(CommitChangesValidationError, exception);
            }
            catch (DbUpdateConcurrencyException exception)
            {
                //TODO: Add Logging - Warn
                result = this.HandleDatabaseUpdateException(CommitChangesConcurrencyError, exception);
            }
            catch (DbUpdateException exception)
            {
                //TODO: Add Logging - Error
                result = this.HandleDatabaseUpdateException(CommitChangesFailed, exception);
            }
            
            return result;
        }

        public override void Dispose()
        {
            Context?.Dispose();
        }

        private OperationResult HandleDatabaseUpdateException(string message, Exception exception) 
        {
            base.ResetDisasterRecoveryContext();
            return OperationResult.Initialize(false, message, exception);
        }
    }
}
