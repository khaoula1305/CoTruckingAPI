using Cotrucking.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Cotrucking.Infrastructure.Entities
{
    public class AssignmentDataModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid TransporterId { get; set; }
        public virtual TransporterDataModel Transporter { get; set; }
        public Guid VehicleId { get; set; }
        public virtual VehicleDataModel Vehicle { get; set; }
        public DateTime AssignmentStartDate { get; set; }
        public DateTime? AssignmentEndDate { get; set; } 
        public AssignmentStatus Status { get; set; }
    }
}
