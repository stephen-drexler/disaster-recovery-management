
using System.Data.Entity.ModelConfiguration;
using VM.DisasterRecovery.Domain.Models;

namespace VM.DisasterRecovery.Persistence.Context.Configurations
{
    public class ContributionConfiguration : EntityTypeConfiguration<Contribution>
    {
        private ContributionConfiguration()
        {
            Property(c => c.UserId)
                .IsRequired();

            Property(c => c.DisasterId)
                .IsRequired();

            Property(c => c.Amount)
            .IsRequired();
        }

        public static ContributionConfiguration Initialize()
        {
            return new ContributionConfiguration();
        }
    }
}
