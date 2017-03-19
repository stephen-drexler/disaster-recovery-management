## Disaster Recovery Management

With the barrage of recent major disasters, including floods, earthquakes, tsunamis, tornados, and forest fires, the need for communication and organization of relief efforts becomes more apparent. Disaster Recovery Management is designed to help organize resources and volunteers to provide aid to neighbors near and far, who have been recently displaced by A major catastrophe.

### Projects:
- Common
- Domain
- Persistence 
- Services
- Web 

5 Tier solution architecture to maintain separation of concerns and insure future extendibility for a mid-sized project
 
### Domain

#### User
- UserId
- Occupation

#### Disaster
- Id
- Title
- Summary
- Context
- Location
- SmallImage
- LargeImage
- AltImageText
- Expenses
- Donations
- Jobs
- Supplies
- Published
- Deleted

#### Donation
- Id
- UserId
- DisasterId
- Amount

#### Job
- Id
- Title
- Description

#### DisasterJob
- Id
- DisasterId
- JobId
- Positions
- Volunteers

#### Volunteer
- Id
- UserId
- DisasterJobId

#### Supply
- Id
- Name

#### DisasterSupply
- Id
- SupplyId
- Quantity
- Contributions

#### Contribution
- Id
- UserId
- DisasterSupplyid
- Quantity
