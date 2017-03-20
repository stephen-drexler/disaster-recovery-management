
using System.Data.Entity.ModelConfiguration;
using VM.DisasterRecovery.Domain.Models;

namespace VM.DisasterRecovery.Persistence.Context.Configurations
{
    public class VolunteerJobConfiguration : EntityTypeConfiguration<VolunteerJob>
    {
        private VolunteerJobConfiguration()
        {
            HasKey(v => new { v.DisasterId, v.JobId });

            Property(v => v.Positions)
                .IsRequired();
        }

        public static VolunteerJobConfiguration Create()
        {
            return new VolunteerJobConfiguration();
        }
    }
}
