using System.Collections.Generic;
using System.Net.NetworkInformation;
using VM.DisasterRecovery.Domain.Contracts;

namespace VM.DisasterRecovery.Domain.Models
{
    public class Disaster : IUpdate<Disaster>, IPublish<Disaster>, IDelete<Disaster>, IUniqueIdentity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public string Location { get; set; }

        public string SmallImageUrl { get; set; }

        public string LargeImageUrl { get; set; }

        public string AlternateImageText { get; set; }

        public decimal EstimatedExpense { get; set; }

        public ICollection<Contribution> Contributions { get; set; }

        public ICollection<VolunteerJob> Jobs { get; set; }

        public ICollection<Volunteer> Volunteers { get; set; }

        public ICollection<DonateSupply> Supplies { get; set; }

        public ICollection<Donation> Donations { get; set; }

        public bool Published { get; private set; }

        public bool Deleted { get; private set; }

        public Disaster()
        {
            Contributions = new List<Contribution>();
            Jobs = new List<VolunteerJob>();
            Volunteers = new List<Volunteer>();
            Supplies = new List<DonateSupply>();
            Donations = new List<Donation>();
        }

        public void Update(Disaster disaster)
        {
            Title = disaster.Title;
            Summary = disaster.Summary;
            Content = disaster.Content;
            Location = disaster.Location;
            SmallImageUrl = disaster.SmallImageUrl;
            LargeImageUrl = disaster.LargeImageUrl;
            AlternateImageText = disaster.AlternateImageText;
            EstimatedExpense = disaster.EstimatedExpense;
        }

        public void Publish()
        {
            Publish(true);
        }

        public void UnPublish()
        {
            Publish(false);
        }

        public void Delete()
        {
            Deleted = true;
        }

        private void Publish(bool publish)
        {
            Published = publish;
        }
    }
}
