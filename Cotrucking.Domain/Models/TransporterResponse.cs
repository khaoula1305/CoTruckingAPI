using Cotrucking.Domain.Entities;
using Cotrucking.Domain.Enums;

namespace Cotrucking.Domain.Models
{
    public class TransporterResponse
    {
        public Guid Id { get; set; }
        public string? LicenseNumber { get; set; }
        public AvailabilityStatus? AvailabilityStatus { get; set; }
        public Guid UserId { get; set; }
        public Guid? CompanyId { get; set; }
    }

    public class TransporterInput
    {
        public string? LicenseNumber { get; set; }
        public AvailabilityStatus? AvailabilityStatus { get; set; }
        public Guid? CompanyId { get; set; }
    }

    public class TransporterSearch
    {
        public Guid? CompanyId { get; set; }
    }

    public class TransporterExport
    {
        public string? LicenseNumber { get; set; }
        public AvailabilityStatus? AvailabilityStatus { get; set; }
    }
}
