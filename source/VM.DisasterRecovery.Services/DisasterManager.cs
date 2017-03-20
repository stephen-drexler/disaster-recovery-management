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
    public class DisasterManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDisasterRepository _disasterRepository;

        public DisasterManager(IUnitOfWork unitOfWork) 
            : this(unitOfWork, DisasterRepository.Initialize(unitOfWork)) { }

        public DisasterManager(IUnitOfWork unitOfWork, IDisasterRepository disasterRepository)
        {
            _unitOfWork = unitOfWork;
            _disasterRepository = disasterRepository;
        }

        public OperationResult Create(Disaster disaster)
        {
            throw new NotImplementedException();
            if (null == disaster)
                return OperationResult.Initialize();

            return OperationResult.Initialize();
        }
    }
}
