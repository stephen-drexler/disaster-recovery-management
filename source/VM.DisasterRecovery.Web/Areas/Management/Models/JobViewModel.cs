
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using VM.DisasterRecovery.Domain.Models;

namespace VM.DisasterRecovery.Web.Areas.Management.Models
{
    [Bind(Include = "Id, Title, Description")]
    public class JobViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(5000)]
        public string Description { get; set; }

        public JobViewModel() { }

        public JobViewModel(Job job)
        {
            Id = job.Id;
            Title = job.Title;
            Description = job.Description;
        }

        public static JobViewModel Initialize()
        {
            return new JobViewModel();
        }

        public static JobViewModel Initialize(Job job)
        {
            return new JobViewModel(job);
        }

        public Job ConvertToJob()
        {
            return new Job
            {
                Id = Id,
                Title = Title,
                Description = Description
            };
        }
    }
}