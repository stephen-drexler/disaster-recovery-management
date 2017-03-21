
using VM.DisasterRecovery.Domain.Contracts;
using VM.DisasterRecovery.Domain.Models;
using VM.DisasterRecovery.Persistence.Contracts;
using VM.DisasterRecovery.Persistence.Repositories;

namespace VM.DisasterRecovery.Services
{
    public class SupplyManager : Manager<Supply, SupplyRepository>, ISuppyManager
    {
        public SupplyManager(IUnitOfWork unitOfWork) 
            : this(unitOfWork, SupplyRepository.Initialize(unitOfWork)) { }

        public SupplyManager(IUnitOfWork unitOfWork, ISupplyRepository supplyRepository) 
            : base(unitOfWork, supplyRepository) { }
    }
}
