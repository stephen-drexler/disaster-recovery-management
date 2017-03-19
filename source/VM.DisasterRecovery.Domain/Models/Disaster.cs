using System.Collections.Generic;

namespace VM.DisasterRecovery.Domain.Models
{
    public class Disaster
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
            Deleted = false;
        }

        private void Publish(bool publish)
        {
            Published = publish;
        }
    }
}
