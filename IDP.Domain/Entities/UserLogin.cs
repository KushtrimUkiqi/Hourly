namespace IDP.Domain.Entities
{
    using IDP.Common.BaseEntities;
    using System.ComponentModel.DataAnnotations;
 
    public class UserLogin: BaseIdEntity, IConcurrencyAware
    {
        public string Provider { get; set; }

        public string ProviderIdentityKey { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
    }
}
