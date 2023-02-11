namespace IDP.Domain.Entities
{
    using IDP.Common.BaseEntities;
    using System.ComponentModel.DataAnnotations;

    public class UserSecret : BaseIdEntity,IConcurrencyAware
    {
        public string Name { get; set; }

        public string Secret { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
 
        public string ConcurrencyStamp { get; set ; } = Guid.NewGuid().ToString();
    }
}
