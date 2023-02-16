namespace IDP.Domain.Entities
{
    using IDP.Common.BaseEntities;

    public class UserRole : BaseIdEntity
    {

        public int UserId { get; set; }

        public int RoleId { get; set; }

        public virtual User? User { get; set; }

        public virtual Role? Role { get; set;}
    }
}
