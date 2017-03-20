
using System.Data.Entity.ModelConfiguration;
using VM.DisasterRecovery.Domain.Models;

namespace VM.DisasterRecovery.Persistence.Context.Configurations
{
    public class DonationConfiguration : EntityTypeConfiguration<Donation>
    {
        private DonationConfiguration()
        {
            Property(d => d.UserId)
              .IsRequired();

            Property(d => d.SupplyId)
             .IsRequired();

            Property(d => d.DisasterId)
             .IsRequired();

            Property(d => d.Quantity)
             .IsRequired();
        }

        public static DonationConfiguration Initialize()
        {
            return new DonationConfiguration();
        }
    }
}
