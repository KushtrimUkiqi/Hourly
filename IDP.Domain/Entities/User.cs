namespace IDP.Domain.Entities
{
    using IDP.Common.BaseEntities;
    //using System.ComponentModel.DataAnnotations;

    public class User : BaseIdEntity, IConcurrencyAware
    {
         
        public string Subject { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public bool Active { get; set; }

        public string? Email { get; set; }

        public string? SecurityCode { get; set; }

        public DateTime? SecurityCodeExpirationDate { get; set; }

        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        public ICollection<UserClaim> Claims { get; set; } = new List<UserClaim>();

        public ICollection<UserLogin> Logins { get; set; } = new List<UserLogin>();

        public ICollection<UserSecret> Secrets { get; set; } = new List<UserSecret>();

    }

}
