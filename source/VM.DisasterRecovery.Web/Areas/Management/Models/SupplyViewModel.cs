using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using VM.DisasterRecovery.Domain.Models;

namespace VM.DisasterRecovery.Web.Areas.Management.Models
{
    [Bind(Include = "Id, Name")]
    public class SupplyViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public SupplyViewModel() { }

        public SupplyViewModel(Supply supply)
        {
            Id = supply.Id;
            Name = supply.Name;
        }

        public static SupplyViewModel Initialize()
        {
            return new SupplyViewModel();
        }

        public static SupplyViewModel Initialize(Supply supply)
        {
            return new SupplyViewModel(supply);
        }

        public Supply ConvertToSupply()
        {
            return new Supply
            {
                Id = Id,
                Name = Name
            };
        }
    }
}