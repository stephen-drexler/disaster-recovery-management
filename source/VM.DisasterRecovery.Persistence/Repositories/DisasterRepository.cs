
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using VM.DisasterRecovery.Domain.Contracts;
using VM.DisasterRecovery.Domain.Models;
using VM.DisasterRecovery.Persistence.Contracts;
using VM.DisasterRecovery.Persistence.Repositories.Abstract;

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

        public override Disaster Get(int id)
        {
            return DataSet?.SingleOrDefault(d => d.Id == id && !d.Deleted);
        }

        public override IEnumerable<Disaster> GetAll()
        {
            return DataSet?.Where(d => !d.Deleted).ToList() ?? new List<Disaster>();
        }
    }
}
