
using VM.DisasterRecovery.Common.Models;
using VM.DisasterRecovery.Domain.Models;

namespace VM.DisasterRecovery.Domain.Contracts
{
    public interface IDisasterManager : IManager<Disaster>
    {
        OperationResult Publish(Disaster disaster);
        OperationResult UnPublish(Disaster disaster);
    }
}
