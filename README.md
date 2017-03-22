## Disaster Recovery Management

With the barrage of recent major disasters, including floods, earthquakes, tsunamis, tornados, and forest fires, the need for communication and organization of relief efforts becomes more apparent. Disaster Recovery Management is designed to help organize resources and volunteers to provide aid to neighbors near and far, who have been recently displaced by A major catastrophe.

---

### Solution

Disaster Recovery Management will consist of a 5 tier architecture to maintain separation of concerns and insure future extendibility.
 
- Common
- Domain
- Persistence 
- Services
- Web 

---

### Common

#### Models 
- OperationResult

---

### Domain

#### ApplicationUser (Microsoft.AspNet.Identity.EntityFramework.IdentityUser)
- Id (string)
- . . .
- UserName (string)
- Occupation (string)

#### Contribution
- Id (int)
- UserId (string)
- DisasterId (int)
- Amount (decimal)

#### Disaster
- Id (int)
- Title (string)
- Summary (string)
- Content (string)
- Location (string)
- SmallImageUrl (string)
- LargeImageUrl (string)
- AltImageText (string)
- EstimatedExpense (decimal)  
- Contributions (ICollection&lt;Contribution&gt;)
- Jobs (ICollection&lt;VolunteerJob&gt;)
- Volunteers (ICollection&lt;Volunteer&gt;)
- Supplies (ICollection&lt;DonateSupply&gt;)
- Donations (ICollection&lt;Donation&gt;)
- Published (bool)
- Deleted (bool)

#### DonateSupply
- SupplyId (int)
- Supply (Supply)
- DisasterId (string)
- Disaster (Disaster)
- Quantity (int)

#### Donation
- Id (int)
- UserId (string)
- User (ApplicationUser)
- SupplyId (int)
- Supply (Supply)
- DisasterId (string)
- Disaster (Disaster)
- Quantity (int)

#### Job
- Id (int)
- Title (string)
- Description (string)

#### Supply
- Id (int)
- Name (string)

#### Volunteer
- Id (int)
- UserId (string)
- User (ApplicationUser)
- JobId (int)
- Job (Job)
- DisasterId (int)
- Disaster (Disaster)

#### VolunteerJob
- JobId (int)
- Job (Job)
- DisasterId (int)
- Disaster (Disaster)
- Positions (int)

---

### Presistence

#### Context
- Configurations
	- ContributionConfiguration (EntityTypeConfiguration&lt;Contribution&gt;)
	- DisasterConfiguration (EntityTypeConfiguration&lt;Disaster&gt;)
	- DonateSupplyConfiguration (EntityTypeConfiguration&lt;DonateSupply&gt;)
	- DonationConfiguration (EntityTypeConfiguration&lt;Donation&gt;)
	- JobConfiguration (EntityTypeConfiguration&lt;Job&gt;)
	- SupplyConfiguration (EntityTypeConfiguration&lt;Supply&gt;)
	- VolunteerConfiguration (EntityTypeConfiguration&lt;Volunteer&gt;)
	- VolunteerJobConfiguration (EntityTypeConfiguration&lt;VolunteerJob&gt;)
- DisasterRecoveryContext (IdentityDbContext&lt;ApplicationUser&gt;)

#### Repositories
- DisasterRepository (Repository, IDisasterRepository, IRepository)
- JobRepository (Repository, IJobRepository, IRepository)
- SupplyRepository (Repository, ISupplyRepository, IRepository)
- Repository (IRepository)

#### UnitOfWork (IUnitOfWork)

---

### Services

- DisasterManager (Manager, ISupplyManager, IManager)
- JobManager (Manager, ISupplyManager, IManager)
- SupplyManager (Manager, ISupplyManager, IManager)

---

### Web

#### Management (area)

- DisasterContoller (Contoller)
	- Create (DisasterViewModel)
	- Details (Disaster)
	- Edit (DisasterViewModel)
	- Index (IEnumerable&lt;Disaster&gt;)
	- Delete (Disaster)
	
- JobContoller (Contoller)
	- Create (JobViewModel)
	- Details (Job)
	- Edit (JobViewModel)
	- Index (IEnumerable&lt;Job&gt;)
	- Delete (Job)
	
- SupplyContoller (Contoller)
	- Create (SupplyViewModel)
	- Details (Supply)
	- Edit (SupplyViewModel)
	- Index (IEnumerable&lt;Supply&gt;)
	- Delete (Supply)
