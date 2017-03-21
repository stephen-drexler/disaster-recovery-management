
using VM.DisasterRecovery.Domain.Contracts;

namespace VM.DisasterRecovery.Domain.Models
{
    public class Contribution : IUniqueIdentity
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int DisasterId { get; set; }

        public Disaster Disaster { get; set; }

        public decimal Amount { get; set; }
    }
}
