using VM.DisasterRecovery.Domain.Contracts;
using VM.DisasterRecovery.Domain.Models;
using VM.DisasterRecovery.Persistence.Contracts;
using VM.DisasterRecovery.Persistence.Repositories;
using VM.DisasterRecovery.Services.Managers.Abstract;

namespace VM.DisasterRecovery.Services.Managers
{
    public class SupplyManager : Manager<Supply, SupplyRepository>, ISuppyManager
    {
        public SupplyManager(IUnitOfWork unitOfWork) 
            : this(unitOfWork, SupplyRepository.Initialize(unitOfWork)) { }

        public SupplyManager(IUnitOfWork unitOfWork, ISupplyRepository supplyRepository) 
            : base(unitOfWork, supplyRepository) { }

        public static SupplyManager Initialize(IUnitOfWork unitOfWork)
        {
            return new SupplyManager(unitOfWork);
        }
    }
}
