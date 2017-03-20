
namespace VM.DisasterRecovery.Domain.Models
{
    public class DonateSupply
    {
        public int SupplyId { get; set; }

        public Supply Supply { get; set; }

        public int DisasterId { get; set; }

        public Disaster Disaster { get; set; }

        public int Quantity { get; set; }
    }
}
