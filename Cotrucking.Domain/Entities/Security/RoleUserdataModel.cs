    namespace Cotrucking.Domain.Entities.Security;
    public class UserRoleDataModel: IdentityUserRole<Guid>
    {
        public override Guid UserId { get; set; }
        public virtual UserDataModel User { get; set; }

        public override Guid RoleId { get; set; }
        public virtual RoleDataModel Role { get; set; }

        [ForeignKey("doamin_id")]
        public virtual Guid DomainId { get; set; }
        public virtual DomainDataModel Domain { get; set; }
    }