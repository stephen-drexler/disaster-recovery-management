namespace VM.DisasterRecovery.Domain.Models
{
    public class Volunteer
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int VolunteerJobId { get; set; }

        public int DisasterId { get; set; }
    }
}
