## Disaster Recovery Management

With the barrage of recent major disasters, including floods, earthquakes, tsunamis, tornados, and forest fires, the need for communication and organization of relief efforts becomes more apparent. Disaster Recovery Management is designed to help organize resources and volunteers to provide aid to neighbors near and far, who have been recently displaced by A major catastrophe.

### Solution

Disaster Recovery Management will contain a 5 Tier architecture to maintain separation of concerns and insure future extendibility.
 
- Common
- Domain
- Persistence 
- Services
- Web 

### Domain

#### Identity (Microsoft.AspNet.Identity.EntityFramework.IdentityUser)
- Id (string)
- . . .
- Occupation (string)

#### Disaster
- Id (int)
- Title (string)
- Summary (string)
- Context (string)
- Location (string)
- SmallImage (string)
- LargeImage (string)
- AltImageText (string)
- Expense (decimal)  
- Contributions (HashSet<Contribution>)
- Jobs (HashSet<VolunteerJob>)
- Supplies (HashSet<DonateSupply>)
- Published (bool)
- Deleted (bool)

#### Contribution
- Id (int)
- IdentityId (string)
- DisasterId (int)
- Amount (decimal)

#### Job
- Id (int)
- Title (string)
- Description (string)

#### VolunteerJob
- Id (int)
- JobId (int)
- DisasterId (int)
- Positions (int)
- Volunteers (HashSet<Volunteer>)

#### Volunteer
- Id (int)
- IdentityId (string)
- DisasterJobId (int)

#### Supply
- Id (int)
- Name (string)

#### DonateSupply
- Id (int)
- SupplyId (int)
- DisasterId (string)
- Quantity (int)
- Donations (HashSet<Donation>)

#### Donation
- Id (int)
- IdentityId (string)
- DonateSupplyid (int)
- Quantity (int)
