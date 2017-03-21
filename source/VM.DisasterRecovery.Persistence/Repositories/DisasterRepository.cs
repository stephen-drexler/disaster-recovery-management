
using VM.DisasterRecovery.Domain.Contracts;
using VM.DisasterRecovery.Domain.Models;
using VM.DisasterRecovery.Persistence.Contracts;

namespace VM.DisasterRecovery.Persistence.Repositories
{
    public class DisasterRepository : Repository<Disaster>, IDisasterRepository
    {
        private DisasterRepository(IUnitOfWork unitOfWork) : base(unitOfWork.Context)
        {
        }

        public static DisasterRepository Initialize(IUnitOfWork unitOfWork)
        {
            return new DisasterRepository(unitOfWork);
        }
    }
}
