namespace IDP.Domain.Entities
{
    using IDP.Common.BaseEntities;

    public class Role : BaseIdEntity
    {

        public string Name { get; set; } = string.Empty;

        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();

        public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
