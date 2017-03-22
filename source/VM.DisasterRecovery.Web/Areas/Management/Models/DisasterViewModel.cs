
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using VM.DisasterRecovery.Domain.Models;

namespace VM.DisasterRecovery.Web.Areas.Management.Models
{
    [Bind(Include = "Id, Title, Summary, Content, Location, SmallImageUrl, LargeImageUrl, AlternateImageText, EstimatedExpense, Published")]
    public class DisasterViewModel
    {
        public int Id { get; set; }

        [Required]      
        [StringLength(255)]  
        public string Title { get; set; }

        [Required]
        [StringLength(5000)]
        public string Summary { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [StringLength(255)]
        public string Location { get; set; }

        [StringLength(2000)]
        public string SmallImageUrl { get; set; }

        [StringLength(2000)]
        public string LargeImageUrl { get; set; }

        [StringLength(255)]
        public string AlternateImageText { get; set; }

        [Required]
        public decimal EstimatedExpense { get; set; }

        public bool Published { get; set; }

        public DisasterViewModel() { }

        public DisasterViewModel(Disaster disaster)
        {
            Id = disaster.Id;
            Title = disaster.Title;
            Summary = disaster.Summary;
            Content = disaster.Content;
            Location = disaster.Location;
            SmallImageUrl = disaster.SmallImageUrl;
            LargeImageUrl = disaster.LargeImageUrl;
            AlternateImageText = disaster.AlternateImageText;
            EstimatedExpense = disaster.EstimatedExpense;
            Published = disaster.Published;
        }

        public static DisasterViewModel Initialize()
        {
            return new DisasterViewModel();
        }

        public static DisasterViewModel Initialize(Disaster disaster)
        {
            return new DisasterViewModel(disaster);
        }

        public Disaster ConvertToDisaster()
        {
            var disaster = new Disaster();
            disaster.Id = Id;
            disaster.Title = Title;
            disaster.Summary = Summary;
            disaster.Content = Content;
            disaster.Location = Location;
            disaster.SmallImageUrl = SmallImageUrl;
            disaster.LargeImageUrl = LargeImageUrl;
            disaster.AlternateImageText = AlternateImageText;
            disaster.EstimatedExpense = EstimatedExpense;

            if (Published)
            {
                disaster.Publish();
            }
            else
            {
                disaster.UnPublish();
            }

            return disaster;
        }
    }
}