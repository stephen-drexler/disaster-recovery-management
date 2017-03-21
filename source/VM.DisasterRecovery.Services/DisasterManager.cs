using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VM.DisasterRecovery.Common.Models;
using VM.DisasterRecovery.Domain.Contracts;
using VM.DisasterRecovery.Domain.Models;
using VM.DisasterRecovery.Persistence.Contracts;
using VM.DisasterRecovery.Persistence.Repositories;

namespace VM.DisasterRecovery.Services
{
    public class DisasterManager : Manager<Disaster, DisasterRepository>, IDisasterManager
    {
        public DisasterManager(IUnitOfWork unitOfWork) 
            : this(unitOfWork, DisasterRepository.Initialize(unitOfWork)) { }

        public DisasterManager(IUnitOfWork unitOfWork, IDisasterRepository disasterRepository)
            : base(unitOfWork, disasterRepository){ }

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
