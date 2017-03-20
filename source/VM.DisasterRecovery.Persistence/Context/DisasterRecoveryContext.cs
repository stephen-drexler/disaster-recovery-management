
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using VM.DisasterRecovery.Domain.Models;
using VM.DisasterRecovery.Persistence.Context.Configurations;

namespace VM.DisasterRecovery.Persistence.Context
{
    public class DisasterRecoveryContext : IdentityDbContext<ApplicationUser>
    {
        private static string ConnectionStringName => Properties.Persistence.Default.ConnectionStringName;

        public DbSet<Contribution> Contributions { get; set; }

        public DbSet<Disaster> Disasters { get; set; }

        public DbSet<DonateSupply> DonateSupplies { get; set; }

        public DbSet<Donation> Donations { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Supply> Supplies { get; set; }

        public DbSet<Volunteer> Volunteers { get; set; }

        public DbSet<VolunteerJob> VolunteerJobs { get; set; }

        public DisasterRecoveryContext() : this(ConnectionStringName) { }

        public DisasterRecoveryContext(string connectionStringName)
            : base(connectionStringName, throwIfV1Schema: false) { }

        public static DisasterRecoveryContext Create()
        {
            return new DisasterRecoveryContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(ContributionConfiguration.Create());
            modelBuilder.Configurations.Add(DisasterConfiguration.Create());
            modelBuilder.Configurations.Add(DonateSupplyConfiguration.Create());
            modelBuilder.Configurations.Add(DonationConfiguration.Create());
            modelBuilder.Configurations.Add(JobConfiguration.Create());
            modelBuilder.Configurations.Add(SupplyConfiguration.Create());
            modelBuilder.Configurations.Add(VolunteerConfiguration.Create());
            modelBuilder.Configurations.Add(VolunteerJobConfiguration.Create());
          
            base.OnModelCreating(modelBuilder);
        }
    }
}
