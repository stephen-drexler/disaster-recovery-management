## Disaster Recovery Management

With the barrage of recent major disasters, including floods, earthquakes, tsunamis, tornados, and forest fires, the need for communication and organization of relief efforts becomes more apparent. Disaster Recovery Management is designed to help organize resources and volunteers to provide aid to neighbors near and far, who have been recently displaced by A major catastrophe.

### Solution

Disaster Recovery Management will consist of a 5 tier architecture to maintain separation of concerns and insure future extendibility.
 
- Common
- Domain
- Persistence 
- Services
- Web 

---

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
- Contributions (HashSet&lt;Contribution&gt;)
- Jobs (HashSet&lt;VolunteerJob&gt;)
- Supplies (HashSet&lt;DonateSupply&gt;)
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
- Volunteers (HashSet&lt;Volunteer&gt;)

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
- Donations (HashSet&lt;Donation&gt;)

#### Donation
- Id (int)
- IdentityId (string)
- DonateSupplyid (int)
- Quantity (int)
