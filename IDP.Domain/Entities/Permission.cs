namespace IDP.Domain.Entities
{
    using IDP.Common.BaseEntities;

    public class Permission : BaseIdEntity
    {

        public string Name { get; set; } = string.Empty;

        public int RoleId { get; set; }

        public virtual Role? Role { get; set; }
    }
}
