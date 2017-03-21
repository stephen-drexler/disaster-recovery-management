
using VM.DisasterRecovery.Domain.Contracts;

namespace VM.DisasterRecovery.Domain.Models
{
    public class Donation : IUniqueIdentity
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int SupplyId { get; set; }

        public Supply Supply { get; set; }

        public int DisasterId { get; set; }

        public Disaster Disaster { get; set; }

        public int Quantity { get; set; }
    }
}
