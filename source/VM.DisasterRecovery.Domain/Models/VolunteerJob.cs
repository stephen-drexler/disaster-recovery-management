
namespace VM.DisasterRecovery.Domain.Models
{
    public class VolunteerJob
    {
        public int JobId { get; set; }

        public Job Job { get; set; }

        public int DisasterId { get; set; }

        public int Positions { get; set; }
    }
}
