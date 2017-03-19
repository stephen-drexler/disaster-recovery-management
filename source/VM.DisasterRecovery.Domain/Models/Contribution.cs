namespace VM.DisasterRecovery.Domain.Models
{
    public class Contribution
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int DisasterId { get; set; }

        public decimal Amount { get; set; }
    }
}