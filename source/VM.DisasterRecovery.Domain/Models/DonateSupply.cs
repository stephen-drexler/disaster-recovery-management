using System.Collections.Generic;

namespace VM.DisasterRecovery.Domain.Models
{
    public class DonateSupply
    {
        public int Id { get; set; }

        public int JobId { get; set; }

        public int DisasterId { get; set; }

        public int Quantity { get; set; }

        public ICollection<Donation> Donations { get; set; }

        public DonateSupply()
        {
            Donations = new List<Donation>();
        }
    }
}
