
using System.Data.Entity.ModelConfiguration;
using VM.DisasterRecovery.Domain.Models;

namespace VM.DisasterRecovery.Persistence.Context.Configurations
{
    public class JobConfiguration : EntityTypeConfiguration<Job>
    {
        private JobConfiguration()
        {
            Property(s => s.Title)
               .IsRequired()
               .HasMaxLength(255);

            Property(s => s.Description)
               .HasMaxLength(5000);
        }

        public static JobConfiguration Initialize()
        {
            return new JobConfiguration();
        }

    }
}
