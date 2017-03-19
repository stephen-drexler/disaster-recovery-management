namespace VM.DisasterRecovery.Domain.Models
{
    public class Donation
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int DisasterId { get; set; }

        public int DonateSupplyId { get; set; }

        public int Quantity { get; set; }
    }
}
