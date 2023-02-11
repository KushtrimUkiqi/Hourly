namespace IDP.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;

    public class UserSecret : IConcurrencyAware
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Secret { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public User User { get; set; }
 
        public string ConcurrencyStamp { get; set ; } = Guid.NewGuid().ToString();
    }
}
