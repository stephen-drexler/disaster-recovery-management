
using VM.DisasterRecovery.Domain.Contracts;
using VM.DisasterRecovery.Domain.Models;
using VM.DisasterRecovery.Persistence.Contracts;
using VM.DisasterRecovery.Persistence.Repositories;

namespace VM.DisasterRecovery.Services
{
    public class JobManager : Manager<Job, JobRepository>, IJobManager
    {
        public JobManager(IUnitOfWork unitOfWork) 
            : this(unitOfWork, JobRepository.Initialize(unitOfWork)) { }

        public JobManager(IUnitOfWork unitOfWork, IJobRepository jobRepository) :
             base(unitOfWork, jobRepository) { }
    }
}
