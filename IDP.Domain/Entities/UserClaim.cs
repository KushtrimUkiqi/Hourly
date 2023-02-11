namespace IDP.Domain.Entities
{
    using IDP.Common.BaseEntities;

    public class UserClaim : BaseIdEntity,IConcurrencyAware
    {

        public string Type { get; set; }

        public string Value { get; set; }

        public string ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
