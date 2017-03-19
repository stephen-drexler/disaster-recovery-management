using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VM.DisasterRecovery.Domain.Models;

namespace VM.DisasterRecovery.Persistence
{
    public class DisasterRecoveryContext : DbContext
    {
        public DbSet<Contribution> Contributions { get; set; }

        public DbSet<Disaster> Disasters { get; set; }

        public DbSet<DonateSupply> DonateSupplies { get; set; }

        public DbSet<Donation> Donations { get; set; }

        public DbSet<Job> Jobs { get; set; }

        public DbSet<Supply> Supplies { get; set; }

        public DbSet<Volunteer> Volunteers { get; set; }

        public DbSet<VolunteerJob> VolunteerJobs { get; set; }

        public DisasterRecoveryContext(DbContextOptions<DisasterRecoveryContext> options) 
            : base(options) { }

        public DisasterRecoveryContext() { }

    }
}
