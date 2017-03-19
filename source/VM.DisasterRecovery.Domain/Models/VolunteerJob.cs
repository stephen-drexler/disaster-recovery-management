using System.Collections.Generic;

namespace VM.DisasterRecovery.Domain.Models
{
    public class VolunteerJob
    {
        public int Id { get; set; }

        public int JobId { get; set; }

        public int DisasterId { get; set; }

        public int Positions { get; set; }

        public ICollection<Volunteer> Volunteers { get; set; }

        public VolunteerJob()
        {
            Volunteers = new List<Volunteer>();
        }
    }
}
