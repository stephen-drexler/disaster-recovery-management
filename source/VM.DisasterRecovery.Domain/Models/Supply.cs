
using VM.DisasterRecovery.Domain.Contracts;

namespace VM.DisasterRecovery.Domain.Models
{
    public class Supply : IUpdate<Supply>, IUniqueIdentity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Update(Supply supply)
        {
            Name = supply.Name;
        }
    }
}
