
using VM.DisasterRecovery.Domain.Contracts;
using VM.DisasterRecovery.Domain.Models;
using VM.DisasterRecovery.Persistence.Contracts;

namespace VM.DisasterRecovery.Persistence.Repositories
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(IUnitOfWork unitOfWork) : base(unitOfWork.Context)
        {
        }
    }
}
