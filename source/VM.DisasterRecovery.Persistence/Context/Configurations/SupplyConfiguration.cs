
using System.Data.Entity.ModelConfiguration;
using VM.DisasterRecovery.Domain.Models;

namespace VM.DisasterRecovery.Persistence.Context.Configurations
{
    public class SupplyConfiguration : EntityTypeConfiguration<Supply>
    {
        private SupplyConfiguration()
        {
            Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(255);
        }

        public static SupplyConfiguration Create()
        {
            return new SupplyConfiguration();
        }

    }
}
