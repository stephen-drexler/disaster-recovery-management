﻿
using VM.DisasterRecovery.Domain.Contracts;
using VM.DisasterRecovery.Domain.Models;
using VM.DisasterRecovery.Persistence.Contracts;

namespace VM.DisasterRecovery.Persistence.Repositories
{
    public class SupplyRepository : Repository<Supply>, ISupplyRepository
    {
        public SupplyRepository(IUnitOfWork unitOfWork) : base(unitOfWork.Context) { }
    }
}