using System.ComponentModel.DataAnnotations;

namespace Cotrucking.Domain.Entities
{
    public  abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now; 
        public DateTime ModifiedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}
