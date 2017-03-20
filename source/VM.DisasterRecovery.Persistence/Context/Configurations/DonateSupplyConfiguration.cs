
using System.Data.Entity.ModelConfiguration;
using VM.DisasterRecovery.Domain.Models;

namespace VM.DisasterRecovery.Persistence.Context.Configurations
{
    public class DonateSupplyConfiguration : EntityTypeConfiguration<DonateSupply>
    {
        private DonateSupplyConfiguration()
        {
            HasKey(d => new { d.DisasterId, d.SupplyId });

            Property(d => d.Quantity)
                .IsRequired();
        }

        public static DonateSupplyConfiguration Create()
        {
            return new DonateSupplyConfiguration();
        }
    }
}
