
using VM.DisasterRecovery.Domain.Contracts;
using VM.DisasterRecovery.Domain.Models;
using VM.DisasterRecovery.Persistence.Contracts;

namespace VM.DisasterRecovery.Persistence.Repositories
{
    public class DisasterRepository : Repository<Disaster>, IDisasterRepository
    {
        public DisasterRepository(IUnitOfWork unitOfWork) : base(unitOfWork.Context)
        {
        }
    }
}
