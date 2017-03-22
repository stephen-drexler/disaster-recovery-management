using System.Collections.Generic;
using VM.DisasterRecovery.Common.Models;
using VM.DisasterRecovery.Domain.Contracts;
using VM.DisasterRecovery.Domain.Models;
using VM.DisasterRecovery.Persistence.Contracts;
using VM.DisasterRecovery.Persistence.Repositories;
using VM.DisasterRecovery.Services.Managers.Abstract;

namespace VM.DisasterRecovery.Services.Managers
{
    public class DisasterManager : Manager<Disaster, DisasterRepository>, IDisasterManager
    {
        public DisasterManager(IUnitOfWork unitOfWork) 
            : this(unitOfWork, DisasterRepository.Initialize(unitOfWork)) { }

        public DisasterManager(IUnitOfWork unitOfWork, IDisasterRepository disasterRepository)
            : base(unitOfWork, disasterRepository){ }

        public static DisasterManager Initialize(IUnitOfWork unitOfWork)
        {
            return new DisasterManager(unitOfWork);
        }

        public OperationResult Publish(Disaster disaster)
        {
            disaster.Publish();
            return UnitOfWork.Commit();
        }

        public OperationResult UnPublish(Disaster disaster)
        {
            disaster.UnPublish();
            return UnitOfWork.Commit();
        }

        public override OperationResult Delete(Disaster disaster)
        {
            disaster.Delete();
            return base.UnitOfWork.Commit(); ;
        }
    }
}
