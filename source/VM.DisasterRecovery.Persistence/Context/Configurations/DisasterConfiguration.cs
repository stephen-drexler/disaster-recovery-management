
using System.Data.Entity.ModelConfiguration;
using VM.DisasterRecovery.Domain.Models;

namespace VM.DisasterRecovery.Persistence.Context.Configurations
{
    public class DisasterConfiguration : EntityTypeConfiguration<Disaster>
    {
        private DisasterConfiguration()
        {
            Property(d => d.Title)
               .IsRequired()
               .HasMaxLength(255);

            Property(d => d.Summary)
                .IsRequired()
                .HasMaxLength(5000);

            Property(d => d.Content)
               .IsRequired();

            Property(d => d.EstimatedExpense)
              .IsRequired();

            Property(d => d.SmallImageUrl)
                .HasMaxLength(2000);

            Property(d => d.LargeImageUrl)
                .HasMaxLength(2000);

            Property(d => d.AlternateImageText)
                .HasMaxLength(255);

            HasMany(d => d.Contributions)
               .WithRequired(c => c.Disaster)
               .WillCascadeOnDelete(false);

            HasMany(d => d.Donations)
              .WithRequired(c => c.Disaster)
              .WillCascadeOnDelete(false);

            HasMany(d => d.Jobs)
              .WithRequired()             
              .WillCascadeOnDelete(false);

            HasMany(d => d.Supplies)
              .WithRequired()
              .WillCascadeOnDelete(false);

            HasMany(d => d.Volunteers)
             .WithRequired()
             .WillCascadeOnDelete(false);
        }

        public static DisasterConfiguration Create()
        {
            return new DisasterConfiguration();
        }
    }
}
