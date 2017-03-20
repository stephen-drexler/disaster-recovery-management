
using System.Data.Entity.ModelConfiguration;
using VM.DisasterRecovery.Domain.Models;

namespace VM.DisasterRecovery.Persistence.Context.Configurations
{
    public class VolunteerConfiguration : EntityTypeConfiguration<Volunteer>
    {
        private VolunteerConfiguration()
        {
            Property(v => v.UserId)
               .IsRequired();

            Property(v => v.JobId)
               .IsRequired();

            Property(v => v.DisasterId)
               .IsRequired();
        }

        public static VolunteerConfiguration Initialize()
        {
            return new VolunteerConfiguration();
        }
    }
}
