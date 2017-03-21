using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.DisasterRecovery.Domain.Contracts
{
    public interface IUniqueIdentity
    {
        int Id { get; set; }
    }
}
