using Cotrucking.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cotrucking.Infrastructure.Entities
{
    public class AssignmentDataModel : BaseEntity
    {
        public Guid DriverId { get; set; }
        public virtual DriverDataModel Driver { get; set; }
        public Guid VehiculeId { get; set; }
        public virtual VehiculeDataModel Vehicule { get; set; }
        public DateTime AssignmentStartDate { get; set; }
        public DateTime? AssignmentEndDate { get; set; } 
        public AssignmentStatus Status { get; set; }
    }
}
