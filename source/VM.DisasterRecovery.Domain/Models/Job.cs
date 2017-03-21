
using VM.DisasterRecovery.Domain.Contracts;

namespace VM.DisasterRecovery.Domain.Models
{
    public class Job : IUpdate<Job>, IUniqueIdentity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public void Update(Job job)
        {
            Title = job.Title;
            Description = job.Description;
        }
    }
}
