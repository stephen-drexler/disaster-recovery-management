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

#### ApplicationUser (Microsoft.AspNet.Identity.EntityFramework.IdentityUser)
- Id (string)
- . . .
- UserName (string)
- Occupation (string)

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

#### Contribution
- Id (int)
- UserId (string)
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
- Volunteers (ICollection&lt;Volunteer&gt;)

#### Volunteer
- Id (int)
- UserId (string)
- DisasterId (int)
- VolunteerJobId (int)

#### Supply
- Id (int)
- Name (string)

#### DonateSupply
- Id (int)
- SupplyId (int)
- DisasterId (string)
- Quantity (int)
- Donations (ICollection&lt;Donation&gt;)

#### Donation
- Id (int)
- UserId (string)
- DisasterId (string)
- DonateSupplyId (int)
- Quantity (int)
